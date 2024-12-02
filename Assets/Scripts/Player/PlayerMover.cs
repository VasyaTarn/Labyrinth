using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody), typeof(PlayerInput))]
    public class PlayerMover : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _walkSpeed;
        [SerializeField] private float _sprintSpeed;
        private float speed;
        
        [Header("Jump Settings")]
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _maxGroundAngle;
        
        [Header("Rotation Settings")]
        [SerializeField] private CinemachineVirtualCameraBase _camera;
        [SerializeField] private float _mouseSensitivity;
        [SerializeField] private float _yRotationRange;

        [Header("UI")]
        [SerializeField] private Image staminaUI;

        [Header("Stamina")]
        [SerializeField] private float maxStamina;
        private float currentStamina;
        [SerializeField] private float staminaRegenRate;
        [SerializeField] private float staminaDrainRate;
        [SerializeField] private float regenDelay;
        private bool isDraining;
        private float regenTimer;

        private float _verticalRotation;
        private bool _isGrounded;

        [HideInInspector] public bool moveStatus = false;

        private void Start()
        {
            currentStamina = maxStamina;
        }

        private void FixedUpdate()
        {
            if (moveStatus)
            {
                Move();
            }
        }

        private void Update()
        {
            if(isDraining)
            {
                DrainStamina();
            }
            else
            {
                RegenStamina();
            }

            UpdateStaminaUI();

            if (moveStatus && Time.timeScale != 0f)
            {
                Rotate();
            }

            //Jump();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.CompareTag("Orb"))
            {
                GameManager.Instance.finishGame();
            }
        }

        private void OnCollisionStay(Collision other)
        {
            var minYNormal = _maxGroundAngle * Mathf.Deg2Rad;

            foreach (var contact in other.contacts)
            {
                if (contact.normal.y <= minYNormal)
                {
                    _isGrounded = false;
                    return;
                }   
            }
            
            _isGrounded = true;
        }

        private void OnCollisionExit(Collision other)
        {
            _isGrounded = false;
        }

        private void Jump()
        {
            if (_playerInput.JumpInput && _isGrounded)
            {
                _rigidbody.AddForce(_jumpForce * Vector3.up, ForceMode.Impulse);
            }
        }

        private void Rotate()
        {
            var horizontalRotation = _playerInput.MouseX * _mouseSensitivity;
            transform.Rotate(0f, horizontalRotation, 0f);
            
            _verticalRotation -= _playerInput.MouseY * _mouseSensitivity;
            _verticalRotation = Mathf.Clamp(_verticalRotation, -_yRotationRange, _yRotationRange);
            _camera.transform.localRotation = Quaternion.Euler(_verticalRotation, 0f, 0f);
        }

        private void Move()
        {
            if (_playerInput.SprintInput && currentStamina > 0)
            {
                UseStamina(true);
                speed = _sprintSpeed;

            }
            else
            {
                UseStamina(false);
                speed = _walkSpeed;
            }
            

            var movementVector = new Vector3(_playerInput.HorizontalInput, 0, _playerInput.VerticalInput) 
                                 * (speed * Time.fixedDeltaTime);

            _rigidbody.MovePosition(_rigidbody.position + transform.TransformDirection(movementVector));
        }

        public void UseStamina(bool use)
        {
            isDraining = use;

            if (use)
            {
                regenTimer = 0f; 
            }
        }

        private void DrainStamina()
        {
            if (currentStamina > 0)
            {
                currentStamina -= staminaDrainRate * Time.deltaTime;
                currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
            }
        }

        private void RegenStamina()
        {
            if (currentStamina < maxStamina)
            {
                regenTimer += Time.deltaTime;
                if (regenTimer >= regenDelay)
                {
                    currentStamina += staminaRegenRate * Time.deltaTime;
                    currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
                }
            }
        }

        private void UpdateStaminaUI()
        {
            if (staminaUI != null)
            {
                staminaUI.fillAmount = currentStamina / maxStamina;
            }
        }
    }
}
