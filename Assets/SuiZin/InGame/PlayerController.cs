using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    private Vector3 _moveVec;
    private float _rotatePower;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 50f;
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float jumpCheckHeight = 6.0f;
    private GameInputs _inputs;
    private Transform _myTransform; 
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _myTransform = transform;
        _inputs = new GameInputs();

        _inputs.Player.Move.performed += OnMove;
        _inputs.Player.Move.canceled += OnMove;
        _inputs.Player.Rotate.performed += OnRotate;
        _inputs.Player.Rotate.canceled += OnRotate;
        
        

        _inputs.Player.Jump.started += OnJump;
        _inputs.Enable();
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
        vec.y = rb.linearVelocity.y;
        // rb.MovePosition(rb.position + movement);
        rb.linearVelocity = vec;
    }
    void Rotate(float rotatePower)
    {
        if(rotatePower==0) return;
        Quaternion deltaRotation = Quaternion.Euler(new Vector3(0f, rotatePower * rotationSpeed, 0f));
        rb.MoveRotation(rb.rotation* deltaRotation);
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
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        Debug.Log("a");
        //1なら右回転 2なら左回転
        _rotatePower = context.ReadValue<float>();
    }
    private void OnDestroy()
    {
        _inputs.Player.Move.performed -= OnMove;
        _inputs.Player.Move.canceled -= OnMove;
        
        _inputs.Player.Jump.started -= OnJump;
        _inputs.Disable();
    }
}
