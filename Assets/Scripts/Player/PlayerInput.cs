using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        public float HorizontalInput { get; private set; }
        public float VerticalInput { get; private set; }
        public float MouseX { get; private set; }
        public float MouseY { get; private set; }
        public bool JumpInput { get; private set; }
        public bool SprintInput { get; private set; }
        public bool AttackInput { get; private set; }

        private void Update()
        {
            HorizontalInput = Input.GetAxis("Horizontal");
            VerticalInput = Input.GetAxis("Vertical");
            MouseX = Input.GetAxis("Mouse X");
            MouseY = Input.GetAxis("Mouse Y");
            JumpInput = Input.GetKeyDown(KeyCode.Space);
            SprintInput = Input.GetKey(KeyCode.LeftShift);
            AttackInput = Input.GetMouseButtonDown(0);
        }
    }
}
