using Assets.Source.Script;
using Assets.Source.Scripts;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Data", menuName = "Data/GameData")]
public class GameData : ScriptableObject
{
    [SerializeField] private Key _keyPrefab;
    [SerializeField] private Door _doorPrefab;
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private WallData _wallData;

    public Key KeyPrefab => _keyPrefab;
    public Door DoorPrefab => _doorPrefab;
    public Player PlayerPrefab => _playerPrefab;
    public WallData WallData => _wallData;
}
