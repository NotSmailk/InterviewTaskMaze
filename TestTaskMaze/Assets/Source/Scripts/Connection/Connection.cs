using Assets.Source.Script;
using Assets.Source.Scripts.Factories;
using Assets.Source.Scripts.Utils;
using System;
using UnityEngine;

namespace Assets.Source.Scripts
{
    [Serializable]
    public class Connection
    {
        public ColorVector doors;
        public Room room1;
        public Room room2;
        public ConnectionType connectionType;

        private float _offset = 5f;
        private IFactory<Door> _doorFactory;
        private IFactory<Wall> _wallFactory;

        public void CreateDoors(IFactory<Door> doorFactory, IFactory<Wall> wallFactory)
        {
            _doorFactory = doorFactory;
            _wallFactory = wallFactory;
            var pos = Vector2Extra.Middle(room1.transform.position, room2.transform.position);

            var yellow = GetDoorOrWall(ColorType.Yellow, doors.yellow);
            yellow.position = pos;
            var blue = GetDoorOrWall(ColorType.Blue, doors.blue);
            blue.position = pos + Constants.Offest[connectionType] * _offset;
            var green = GetDoorOrWall(ColorType.Green, doors.green);
            green.position = pos - Constants.Offest[connectionType] * _offset;

            _wallFactory.Get().transform.position = pos + Constants.Offest[connectionType] * _offset / 2;
            _wallFactory.Get().transform.position = pos - Constants.Offest[connectionType] * _offset / 2;
        }

        private Transform GetDoorOrWall(ColorType type, bool doorExist)
        {
            if (doorExist)
            {
                var door = _doorFactory.Get();
                door.Init(type);
                door.transform.rotation = Quaternion.Euler(Constants.Rotations[connectionType]);
                room1.AddDoor(door, doors);
                room2.AddDoor(door, doors);
                return door.transform;
            }
            else
            {
                var wall = _wallFactory.Get();
                return wall.transform;
            }
        }
    }
}
