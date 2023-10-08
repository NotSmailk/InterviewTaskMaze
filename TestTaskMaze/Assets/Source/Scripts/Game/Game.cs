using Assets.Source.Script;
using Assets.Source.Scripts.Factories;
using Assets.Source.Scripts.UI;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private GameData _data;
        [SerializeField] private GameCamera _camera;
        [SerializeField] private Transform _playerContent;
        [SerializeField] private Transform _keysContent;
        [SerializeField] private Transform _doorsContent;
        [SerializeField] private Transform _wallsContent;
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
            _ui = gameObject.AddComponent<GameUI>().Init(Restart);
            _playerFactory = new PlayerFactory(_data.PlayerPrefab, _playerContent);
            _keysFactory = new KeyFactory(_data.KeyPrefab, _keysContent);
            _doorsFactory = new DoorFactory(_data.DoorPrefab, _doorsContent);
            _wallsFactory = new WallFactory(_data.WallData.WallPrefab, _wallsContent, _data.WallData);

            _connectionConfig.Init(_doorsFactory, _wallsFactory); 
            _player = _playerFactory.Get().Init(_ui.Interactable);
            _player.transform.position = _rooms[0].transform.position;
            _camera.Init();

            foreach (var room in _rooms)
                room.Init(_keysFactory, _wallsFactory, Victory, Defeat);            
        }

        private void Update()
        {
            if (_gameEnded)
                return;

            _player.GameUpdate();
            _camera.GameUpdate(_player.transform);
        }

        private void Victory()
        {
            _ui.GameResult("You ecaped the maze");
            _player.Stop();
            _gameEnded = true;
        }

        private void Defeat()
        {
            _ui.GameResult("You lost in the maze");
            _player.Stop();
            _gameEnded = true;
        }

        private void Restart()
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