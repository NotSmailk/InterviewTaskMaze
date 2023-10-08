﻿using Assets.Source.Script;
using Assets.Source.Scripts.Collision;
using Assets.Source.Scripts.Factories;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Source.Scripts
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Room : MonoBehaviour
    {
        [SerializeField] private WallConfig _wallConfig;
        [SerializeField] private ColorVector _keys;
        [SerializeField] private bool _hasExit;

        private BoxCollider2D _collider;
        private ColorVector _keysInit = new ColorVector();
        private float _offset = 3f;
        private float _wallOffset = 5f;
        private List<Door> _doors = new List<Door>();
        private TriggerBox _box;
        private ColorVector _doorsVector = new ColorVector();
        private UnityEvent _victory = new UnityEvent();
        private UnityEvent _defeat = new UnityEvent();

        public bool HasEscape { get; private set; }

        public void Init(IFactory<Key> keyFactory, IFactory<Wall> wallFactory, UnityAction victory, UnityAction defeat)
        {
            _box = gameObject.AddComponent<TriggerBox>();
            _keysInit.yellow = _keys.yellow;
            _keysInit.blue = _keys.blue;
            _keysInit.green = _keys.green;
            _box.AddOnEnter(PlayerEnter);
            _box.AddOnExit(PlayerExit);
            _collider = GetComponent<BoxCollider2D>();
            _collider.isTrigger = true;
            _victory.AddListener(victory);
            _defeat.AddListener(defeat);

            CreateWalls(wallFactory);
            CreateKeys(keyFactory);
        }

        public void AddDoor(Door door, ColorVector vector)
        {
            _doors.Add(door);
            _doorsVector.yellow |= vector.yellow;
            _doorsVector.blue |= vector.blue;
            _doorsVector.green |= vector.green;
        }

        public void ResetKeys()
        {
            _keys.yellow = _keysInit.yellow;
            _keys.blue = _keysInit.blue;
            _keys.green = _keysInit.green;
        }

        public void Reclaim(ColorType type)
        {
            switch (type)
            {
                case ColorType.Yellow:
                    _keys.yellow = false;
                    ResetDoors();
                    DoorsActivity(ColorType.Yellow);
                    break;
                case ColorType.Blue:
                    _keys.blue = false;
                    ResetDoors();
                    DoorsActivity(ColorType.Blue);
                    break;
                case ColorType.Green:
                    _keys.green = false;
                    ResetDoors();
                    DoorsActivity(ColorType.Green);
                    break;
            }
        }

        public void CheckEscape()
        {
            HasEscape = (_keys.yellow && _doorsVector.yellow) ||
                (_keys.blue && _doorsVector.blue) ||
                (_keys.green && _doorsVector.green);
        }

        public void ResetDoors()
        {
            foreach (var door in _doors)
                door.ResetCollision();
        }

        private void PlayerExit(Collider2D collider)
        {
            if (collider.TryGetComponent(out Player player))
                CheckEscape();
        }

        private void PlayerEnter(Collider2D collider)
        {
            if (collider.TryGetComponent(out Player player))
            {
                player.SetColor(ColorType.Default);
                ResetDoors();

                if (_hasExit)
                {
                    _victory.Invoke();
                    return;
                }


                if (!HasEscape)
                    _defeat.Invoke();
            }
        }

        private void DoorsActivity(ColorType type)
        {
            foreach (var door in _doors)
            {
                door.UpdateCollision(type);
            }
        }

        #region CREATE_METHODS

        public void CreateKeys(IFactory<Key> keyFactory)
        {
            var keyPos = transform.position;

            if (_keys.yellow)
                keyFactory.Get().Init(ColorType.Yellow, this).transform.position = keyPos + Vector3.up * _offset;
            if (_keys.blue)
                keyFactory.Get().Init(ColorType.Blue, this).transform.position = keyPos - Vector3.right * _offset - Vector3.up * _offset / 2;
            if (_keys.green)
                keyFactory.Get().Init(ColorType.Green, this).transform.position = keyPos + Vector3.right * _offset - Vector3.up * _offset / 2;

            CheckEscape();
        }

        private void CreateWalls(IFactory<Wall> wallFactory)
        {
            if (_wallConfig.up)
                CreateWallRow(ConnectionType.Vertical, wallFactory, Vector2.up);
            if(_wallConfig.bot)
                CreateWallRow(ConnectionType.Vertical, wallFactory, -Vector2.up);
            if(_wallConfig.left)
                CreateWallRow(ConnectionType.Horizontal, wallFactory, -Vector2.right);
            if(_wallConfig.right)
                CreateWallRow(ConnectionType.Horizontal, wallFactory, Vector2.right);

            CreateAngleWalls(wallFactory);
        }

        private void CreateAngleWalls(IFactory<Wall> wallFactory)
        {
            var offestH = Constants.Offest[ConnectionType.Vertical] * _wallOffset * 1.5f;
            var offestV = Constants.Offest[ConnectionType.Horizontal] * _wallOffset * 1.5f;

            CreateWall(wallFactory, (Vector2)transform.position + offestV + offestH);
            CreateWall(wallFactory, (Vector2)transform.position + offestV - offestH);
            CreateWall(wallFactory, (Vector2)transform.position - offestV + offestH);
            CreateWall(wallFactory, (Vector2)transform.position - offestV - offestH);
        }

        private void CreateWallRow(ConnectionType type, IFactory<Wall> wallFactory, Vector2 vector)
        {
            var pos = (Vector2)transform.position + vector * _wallOffset * transform.localScale.x;
            var offest = Constants.Offest[type] * _wallOffset;

            CreateWall(wallFactory, pos, Quaternion.Euler(Constants.Rotations[type]));
            CreateWall(wallFactory, pos + offest, Quaternion.Euler(Constants.Rotations[type]));
            CreateWall(wallFactory, pos + offest / 2, Quaternion.Euler(Constants.Rotations[type]));
            CreateWall(wallFactory, pos - offest, Quaternion.Euler(Constants.Rotations[type]));
            CreateWall(wallFactory, pos - offest / 2, Quaternion.Euler(Constants.Rotations[type]));
        }

        private void CreateWall(IFactory<Wall> wallFactory, Vector3 pos , Quaternion rot = new Quaternion())
        {
            var wall = wallFactory.Get();
            wall.transform.SetPositionAndRotation(pos, rot);
        }

        #endregion CREATE_METHODS
    }
}
