using Assets.Source.Scripts;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WallData
{
    [SerializeField] private Wall _wallPrefab;
    [SerializeField] private List<Sprite> _walls;

    public Wall WallPrefab => _wallPrefab;
    public Sprite RandomWall => GetWallImage(Random.Range(0, _walls.Count));

    public Sprite GetWallImage(int id)
    {
        return _walls[id];
    }
}