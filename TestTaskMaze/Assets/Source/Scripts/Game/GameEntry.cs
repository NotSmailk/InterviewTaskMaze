using Assets.Source.Script;
using Assets.Source.Scripts.Factories;
using Assets.Source.Scripts.Signals;
using Assets.Source.Scripts.UI;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts
{
    public class GameEntry : MonoBehaviour
    {
        [SerializeField] private GameData _data;
        [SerializeField] private GameCamera _camera;
        [SerializeField] private List<Room> _rooms;
        [SerializeField] private ConnectionConfig _connectionConfig;

        private IFactory<Player> _playerFactory;
        private IFactory<Key> _keysFactory;
        private IFactory<Door> _doorsFactory;
        private IFactory<Wall> _wallsFactory;
        private Player _player;
        private GameUI _ui;
        private bool _gameEnded;

        private void Awake()
        {
            _ui = gameObject.AddComponent<GameUI>().Init();
            _playerFactory = new PlayerFactory(_data.PlayerPrefab);
            _keysFactory = new KeyFactory(_data.KeyPrefab);
            _doorsFactory = new DoorFactory(_data.DoorPrefab);
            _wallsFactory = new WallFactory(_data.WallData);

            _connectionConfig.Init(_doorsFactory, _wallsFactory); 
            _player = _playerFactory.Get().Init();
            _player.transform.position = _rooms[0].transform.position;
            _camera.Init();

            EventBus.Instance.Subscribe<VictorySignal>(Victory);
            EventBus.Instance.Subscribe<DefeatSignal>(Defeat);
            EventBus.Instance.Subscribe<RestartSignal>(Restart);

            foreach (var room in _rooms)
                room.Init(_keysFactory, _wallsFactory);            
        }

        private void OnDestroy()
        {
            EventBus.Instance.UnSubscribe<VictorySignal>(Victory);
            EventBus.Instance.UnSubscribe<DefeatSignal>(Defeat);
            EventBus.Instance.UnSubscribe<RestartSignal>(Restart);
        }

        private void Update()
        {
            if (_gameEnded)
                return;

            _player.GameUpdate();
            _camera.GameUpdate(_player.transform);
        }

        private void Victory(VictorySignal signal)
        {
            _gameEnded = true;
        }

        private void Defeat(DefeatSignal signal)
        {
            _gameEnded = true;
        }

        private void Restart(RestartSignal signal)
        {
            _keysFactory.ReclaimAll();

            foreach (var room in _rooms)
            {
                room.ResetKeys();
                room.CreateKeys(_keysFactory);
            }

            _player.transform.position = _rooms[0].transform.position;
            _gameEnded = false;
            _ui.HideResult();
        }
    }
}