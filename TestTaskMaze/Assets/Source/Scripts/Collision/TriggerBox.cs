using UnityEngine;
using UnityEngine.Events;

namespace Assets.Source.Scripts.Collision
{
    public class TriggerBox : MonoBehaviour
    {
        private UnityEvent<Collider2D> _onEnter = new UnityEvent<Collider2D>();
        private UnityEvent<Collider2D> _onStay = new UnityEvent<Collider2D>();
        private UnityEvent<Collider2D> _onExit = new UnityEvent<Collider2D>();

        public void AddOnEnter(UnityAction<Collider2D> action)
        {
            _onEnter.AddListener(action);
        }

        public void AddOnStay(UnityAction<Collider2D> action)
        {
            _onStay.AddListener(action);
        }

        public void AddOnExit(UnityAction<Collider2D> action)
        {
            _onExit.AddListener(action);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _onEnter.Invoke(collision);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            _onExit.Invoke(collision);
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            _onStay.Invoke(collision);
        }
    }
}