using Project.UI;
using UnityEngine;

namespace Project.Player
{
    public class PlayerMotion : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public float rotationSpeed = 10f;
        
        [SerializeField] private Rigidbody _playerRigidbody;
        [SerializeField] private Transform _playerTransform;

        private JoystickController _joystick;

        private Vector3 _movement;


        public void Init(JoystickController joystickController)
        {
            _joystick = joystickController;
        }
        void Update()
        {
            HandleMovementInput();
            RotatePlayer();
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        void HandleMovementInput()
        {
            float horizontalInput = _joystick.Horizontal();
            float verticalInput = _joystick.Vertical();

            _movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        }

        void MovePlayer()
        {
            _playerRigidbody.AddForce(_movement * moveSpeed);
        }

        void RotatePlayer()
        {
            if (_movement != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(_movement, Vector3.up);
                _playerTransform.rotation = Quaternion.RotateTowards(_playerTransform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
