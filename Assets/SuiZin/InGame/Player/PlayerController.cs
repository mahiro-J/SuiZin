using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using Alchemy.Inspector;
using R3;

namespace SuiZin.InGame
{
    public class PlayerController : MonoBehaviour
    {
        private Vector3 _moveVec;
        private Vector2 _rotatePower; // 1か-1の値を取る
        
        [TabGroup("Speed","Now Speed")][ReadOnly][HideLabel]
        public float speed;
        [TabGroup("Speed","Normal Speed")][HideLabel]
        [SerializeField] private float normalSpeed = 10f;
        [TabGroup("Speed","Max Speed")][HideLabel]
        [SerializeField] private float maxSpeed = 50;

        
        private bool _isSprint;

        private PlayerInput _inputs;
        private Transform _myTransform; 
        
        [HideLabel][SerializeField]
        private Transform eyeTransform;
        
        private Rigidbody _rb;
        [TabGroup("Rotation","Eye Rotation Speed")][HideLabel]
        [SerializeField] private float eyeRotationSpeed = 100f;
        [TabGroup("Rotation","Body Rotation Speed")][HideLabel]
        [SerializeField] private float rotationSpeed = 100f;
        [TabGroup("Jump","Jump Force")][HideLabel]
        [SerializeField] private float jumpForce = 10f;
        [TabGroup("Jump","Jump Check Height")][HideLabel]
        [SerializeField] private float jumpCheckHeight = 6.0f;

        private float _currentPitch = 0f;
        
        
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _myTransform = transform;
            _inputs = new PlayerInput();
            

            _inputs.Player.Move.performed += OnMove;
            _inputs.Player.Move.canceled += OnMove;
            _inputs.Player.Rotate.performed += OnRotate;
            _inputs.Player.Rotate.canceled += OnRotate;
            _inputs.Player.Sprint.started += OnSprint;
            _inputs.Player.Sprint.canceled += OnSprint;
            
            speed = normalSpeed;
            _isSprint = false;

            _inputs.Player.Jump.started += OnJump;
            _inputs.Enable();

            PlayerInputController.IsInputable
                .Subscribe(inputable =>
                {
                    if (inputable) _inputs.Enable();
                    else _inputs.Disable();
                })
                .AddTo(this);

        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            Move(_moveVec,speed);
            Rotate(_rotatePower);
        }

        void Move(Vector3 movement, float movespeed)
        {
            var vec = (_myTransform.forward*movement.y + _myTransform.right*movement.x).normalized * (movespeed);
            vec.y = _rb.linearVelocity.y;
            _rb.linearVelocity = vec;
        }
        void Rotate(Vector2 rotatePower)
        {
            if(rotatePower.x==0 && rotatePower.y==0) return;
            if(!eyeTransform)return;
            //Y軸回転
            float yRotation = rotatePower.x * rotationSpeed * Time.deltaTime;
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(0,yRotation , 0));
            _rb.MoveRotation(_rb.rotation* deltaRotation);
            
            //X軸回転
            float xRotation = rotatePower.y * eyeRotationSpeed * Time.deltaTime;
            _currentPitch -= xRotation;
            _currentPitch = Mathf.Clamp(_currentPitch, -80f, 80f);
            eyeTransform.localRotation = Quaternion.Euler(_currentPitch,0f,0f);
        }

        bool OnGroundCheck()
        {
            RaycastHit hit;
            if (Physics.Raycast(_myTransform.position, Vector3.down, out hit, jumpCheckHeight, LayerMask.GetMask("Ground")))
            {
                if (hit.collider !=null)
                    return true;
            }
            return false;
        }
        public void OnMove(InputAction.CallbackContext context)
        {
            _moveVec = context.ReadValue<Vector2>();
        }
        public void OnJump(InputAction.CallbackContext context)
        {
            if (!OnGroundCheck()) return;
                _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        public void OnRotate(InputAction.CallbackContext context)
        {
            //1なら右回転 -1なら左回転
            _rotatePower = context.ReadValue<Vector2>();
        }

        public void OnSprint(InputAction.CallbackContext context)
        {
            _isSprint = context.ReadValueAsButton();
            speed = _isSprint ? maxSpeed : normalSpeed;
        }
        private void OnDestroy()
        {
            if (_inputs != null)
            {
                _inputs.Player.Move.performed -= OnMove;
                _inputs.Player.Move.canceled -= OnMove;
                _inputs.Player.Rotate.performed -= OnRotate;
                _inputs.Player.Rotate.canceled -= OnRotate;
                _inputs.Player.Jump.started -= OnJump;
                _inputs.Player.Sprint.started -= OnSprint;
                _inputs.Player.Sprint.canceled -= OnSprint;
                _inputs.Disable();
            }
        }
        
        public void InputDisable()
        {
            _inputs.Disable();
        }
        
        public void InputEnable()
        {
            _inputs.Enable();
        }
    }
    
}
