using Assets.Source.Scripts.Utils;
using UnityEngine;

namespace Assets.Source.Scripts
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class Key : MonoBehaviour, IInteractable
    {
        private SpriteRenderer _renderer;
        private Room _link;
        private ColorType _color;

        public ColorType Color => _color;

        public Key Init(ColorType color, Room link)
        {
            _link = link;
            _color = color;
            _renderer = GetComponent<SpriteRenderer>();
            RendererExtra.SetColor(_renderer, "_Color", Constants.Colors[color]);

            return this;
        }

        public void Use()
        {
            _link.Reclaim(_color);
            Destroy(gameObject);
        }
    }
}