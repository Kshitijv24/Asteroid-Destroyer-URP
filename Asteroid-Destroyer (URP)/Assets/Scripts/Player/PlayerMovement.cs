using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

[SelectionBase]
public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance { get; private set; }

    [SerializeField] float forceMagnitude = 10;
    [SerializeField] float maxVelocity = 6;
    [SerializeField] float rotationSpeed = 10;
    [SerializeField] float lookSpeed = 5;

    Rigidbody rb;
    Vector2 movementDirection;
    Vector2 lookDirection;
    Camera mainCamera;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("There are more than one " + this.GetType() + " Instances", this);
            return;
        }

        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    public void Start()
    {
        EnhancedTouchSupport.Enable();
        //playerInput.actions["Move"].performed += HandleMove;
        //playerInput.actions["Move"].canceled += HandleMove;
    }

    public void HandleMove(InputAction.CallbackContext input)
    {
        //if (playerInput.currentControlScheme != "Gamepad")
        //{
        //    return;
        //}
        //var dir = input.ReadValue<Vector2>();
        //OnActionMove.Invoke(dir);
    }

    private void Update()
    {
        KeepPlayerOnScreen();
        LookAtMouse();
        //RotateToFaceVelocity();
    }

    private void FixedUpdate()
    {
        if (movementDirection == Vector2.zero) return;

        MovePlayer();
    }

    private void OnMove(InputValue value)
    {
        movementDirection = value.Get<Vector2>();
        movementDirection.Normalize();
    }

    private void OnLook(InputValue value)
    {
        lookDirection = value.Get<Vector2>();
        lookDirection.Normalize();
    }

    private void MovePlayer()
    {
        Vector3 movement = new Vector3(movementDirection.x, 0f, movementDirection.y);
        rb.AddForce(movement * forceMagnitude, ForceMode.Force);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
    }

    private void LookAtMouse()
    {
        if(lookDirection == Vector2.zero) return;

        Vector3 direction = new Vector3(lookDirection.x, 0, lookDirection.y);

        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, lookSpeed * Time.deltaTime);
        }
    }

    public float GetPlayerForceMagnitude() => forceMagnitude;

    public void SetPlayerForceMagnitude(float forceMagnitude) => this.forceMagnitude = forceMagnitude;

    private void KeepPlayerOnScreen()
    {
        Vector3 newPosition = transform.position;
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        if(viewportPosition.x > 1)
        {
            newPosition.x = -newPosition.x + 0.1f;
        }
        else if(viewportPosition.x < 0)
        {
            newPosition.x = -newPosition.x - 0.1f;
        }
        else if(viewportPosition.y > 1)
        {
            newPosition.z = -newPosition.z + 0.1f;
        }
        else if(viewportPosition.y < 0)
        {
            newPosition.z = -newPosition.z - 0.1f;
        }

        transform.position = newPosition;
    }

    private void RotateToFaceVelocity()
    {
        if (rb.velocity == Vector3.zero) return;

        Quaternion targetRotation = Quaternion.LookRotation(rb.velocity, Vector3.up);
        
        transform.rotation = Quaternion.Lerp(
            transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
