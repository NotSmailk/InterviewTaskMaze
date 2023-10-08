using UnityEngine;

namespace Assets.Source.Scripts
{
    public class PlayerInputService
    {
        public float HorizontalAxis => Input.GetAxis("Horizontal");
        public float VerticalAxis => Input.GetAxis("Vertical");
        public bool Interact => Input.GetKey(KeyCode.E);
    }
}
