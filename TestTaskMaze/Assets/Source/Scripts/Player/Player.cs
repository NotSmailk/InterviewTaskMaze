using Assets.Source.Scripts.Collision;
using Assets.Source.Scripts.Utils;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Source.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _speed = 3f;

        private Rigidbody2D _rb;
        private SpriteRenderer _renderer;
        private PlayerInputService _input;
        private UnityEvent<bool> _onInteract = new UnityEvent<bool>();
        private TriggerBox _box;
        private Room _cur;
        private bool _interact;

        public Player Init(UnityAction<bool> onInteract)
        {
            _rb = GetComponent<Rigidbody2D>();
            _renderer = GetComponent<SpriteRenderer>();
            SetColor(ColorType.Default);
            _input = new PlayerInputService();
            _onInteract.AddListener(onInteract);
            _box = gameObject.AddComponent<TriggerBox>();
            _box.AddOnStay(InteractableStay);
            _box.AddOnEnter(InteractableEnter);
            _box.AddOnExit(InteractableExit);

            return this;
        }

        public void GameUpdate()
        {
            var moveVector = new Vector2(_input.HorizontalAxis, _input.VerticalAxis);
            _rb.velocity = moveVector * _speed;
            _interact = _input.Interact;
        }

        public void SetColor(ColorType type)
        {
            RendererExtra.SetColor(_renderer, "_Color", Constants.Colors[type]);
        }

        public void Stop()
        {
            _rb.velocity = Vector2.zero;
        }

        public void InteractableEnter(Collider2D collision)
        {
            if (collision.TryGetComponent(out IInteractable interactable))
                _onInteract.Invoke(true);

            if (collision.TryGetComponent(out Room room))
            {
                _cur?.ResetDoors();
                _cur = room;
            }                
        }

        public void InteractableExit(Collider2D collision)
        {
            if (collision.TryGetComponent(out IInteractable interactable))
                _onInteract.Invoke(false);
        }

        public void InteractableStay(Collider2D collision)
        {
            if (_interact && collision.TryGetComponent(out IInteractable interactable))
            {
                interactable.Use();
                SetColor(interactable.Color);
            }
        }
    }
}
