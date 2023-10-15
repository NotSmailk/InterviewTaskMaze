using Assets.Source.Scripts;
using Assets.Source.Scripts.Utils;
using System.Drawing;
using UnityEngine;

namespace Assets.Source.Script
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent (typeof(BoxCollider2D))]
    public class Door : MonoBehaviour
    {
        private SpriteRenderer _renderer;
        private ColorType _color;
        private BoxCollider2D _boxCollider;

        public void Init(ColorType color)
        {
            _color = color;
            _boxCollider = GetComponent<BoxCollider2D>();
            _renderer = GetComponent<SpriteRenderer>();
            RendererExtra.SetColor(_renderer, "_Color", Constants.Colors[color]);
        }

        public void UpdateCollision(ColorType color)
        {
            _boxCollider.isTrigger = _color.Equals(color);

            if (_boxCollider.isTrigger)
                RendererExtra.SetColor(_renderer, "_Color", Constants.Colors[ColorType.Default]);
        }

        public void ResetCollision()
        {
            _boxCollider.isTrigger = false;
            RendererExtra.SetColor(_renderer, "_Color", Constants.Colors[_color]);
        }
    }
}
