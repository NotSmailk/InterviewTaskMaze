using Assets.Source.Scripts.Collision;
using Assets.Source.Scripts.Signals;
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

        public Player Init()
        {
            _rb = GetComponent<Rigidbody2D>();
            _renderer = GetComponent<SpriteRenderer>();
            SetColor(ColorType.Default);
            _input = new PlayerInputService();
            _box = gameObject.AddComponent<TriggerBox>();
            _box.AddOnStay(InteractableStay);
            _box.AddOnEnter(InteractableEnter);
            _box.AddOnExit(InteractableExit);
            EventBus.Instance.Subscribe<VictorySignal>(Victory);
            EventBus.Instance.Subscribe<DefeatSignal>(Defeat);

            return this;
        }

        private void OnDestroy()
        {
            EventBus.Instance.UnSubscribe<VictorySignal>(Victory);
            EventBus.Instance.UnSubscribe<DefeatSignal>(Defeat);
        }

        public void Victory(VictorySignal signal)
        {
            _rb.velocity = Vector2.zero;
        }

        public void Defeat(DefeatSignal signal)
        {
            _rb.velocity = Vector2.zero;
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

        public void InteractableEnter(Collider2D collision)
        {
            if (collision.TryGetComponent(out IInteractable interactable))
                EventBus.Instance.Invoke(new InteractSignal(true));

            if (collision.TryGetComponent(out Room room))
            {
                _cur?.ResetDoors();
                _cur = room;
            }                
        }

        public void InteractableExit(Collider2D collision)
        {
            if (collision.TryGetComponent(out IInteractable interactable))
                EventBus.Instance.Invoke(new InteractSignal(false));
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
