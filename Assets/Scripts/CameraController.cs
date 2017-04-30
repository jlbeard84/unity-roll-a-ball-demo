using UnityEngine;

namespace Assets.Scripts
{
    public class CameraController : MonoBehaviour
    {
        public GameObject Player;

        private Vector3 _offset;

        public void Start()
        {
            _offset = transform.position - Player.transform.position;
        }

        public void LateUpdate()
        {
            transform.position = Player.transform.position + _offset;
        }
    }
}