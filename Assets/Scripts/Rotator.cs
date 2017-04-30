using UnityEngine;

namespace Assets.Scripts
{
    public class Rotator : MonoBehaviour
    {
        private readonly Vector3 _defaultRotation = new Vector3(15, 30, 45);

        public void Update()
        {
            transform.Rotate(_defaultRotation * Time.deltaTime);
        }
    }
}
