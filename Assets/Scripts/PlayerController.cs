using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        private const string VerticalAxisInputName = "Vertical";
        private const string HorizontalAxisInputName = "Horizontal";
        private const string PickupTag = "Pickup";
        private const string CountDisplayText = "Count: ";
        private const string YouWinText = "You Win!";
        private const float DefaultYAxisMovement = 0.0f;
        private const int TotalNumberOfPickups = 8;

        public Text CountText;
        public Text WinText;
        public float Speed;

        private Rigidbody _rigidbody;
        private int _count;

        // Use this for initialization
        public void Start ()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _count = 0;
            SetCountText();
            WinText.text = string.Empty;
        }
	
        public void FixedUpdate()
        {
            var moveHorizontal = Input.GetAxis(HorizontalAxisInputName);
            var moveVertical = Input.GetAxis(VerticalAxisInputName);

            var movement = new Vector3(
                moveHorizontal,
                DefaultYAxisMovement,
                moveVertical);

            _rigidbody.AddForce(movement * Speed);
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(PickupTag))
            {
                other.gameObject.SetActive(false);
                _count++;
                SetCountText();
            }
        }

        private void SetCountText()
        {
            CountText.text = CountDisplayText + _count;

            if (_count >= TotalNumberOfPickups)
            {
                WinText.text = YouWinText;
            }
        }
    }
}
