using UnityEngine;

namespace Assets.Source.Scripts
{
    [RequireComponent(typeof(Camera))]
    public class GameCamera : MonoBehaviour
    {
        private Camera _camera;

        public GameCamera Init()
        {
            _camera = GetComponent<Camera>();

            return this;
        }

        public void GameUpdate(Transform target)
        {
            var pos = target.position;
            pos.z = _camera.transform.position.z;
            _camera.transform.position = pos;
        }
    }
}
