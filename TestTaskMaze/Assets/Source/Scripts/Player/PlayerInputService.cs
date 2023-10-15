using UnityEngine;

namespace Assets.Source.Scripts
{
    public class PlayerInputService
    {
        public float HorizontalAxis => Input.GetAxis(Constants.InputInfo.HORIZONTAL);
        public float VerticalAxis => Input.GetAxis(Constants.InputInfo.VERTICAL);
        public bool Interact => Input.GetKey(Constants.InputInfo.InteractKey);
    }
}
