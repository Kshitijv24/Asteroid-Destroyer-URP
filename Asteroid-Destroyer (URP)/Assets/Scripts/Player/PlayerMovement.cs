using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[SelectionBase]
public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance { get; private set; }

    [SerializeField] float forceMagnitude = 10;
    [SerializeField] float maxVelocity = 6;
    [SerializeField] float rotationSpeed = 10;

    Rigidbody rb;
    Vector3 movementDirection;
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
        }

        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        ProcessInput();
        KeepPlayerOnScreen();
        RotateToFaceVelocity();
    }

    private void FixedUpdate()
    {
        if (movementDirection == Vector3.zero) return;

        rb.AddForce(movementDirection * forceMagnitude, ForceMode.Force);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
    }

    public float GetPlayerForceMagnitude() => forceMagnitude;

    public Vector3 GetPlayerPosition() => transform.position;

    public Quaternion GetPlayerRotation() => transform.rotation;

    public void SetPlayerForceMagnitude(float forceMagnitude) => this.forceMagnitude = forceMagnitude;

    private void ProcessInput()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();

            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);

            movementDirection = worldPosition - transform.position;
            movementDirection.y = 0f;
            movementDirection.Normalize();
        }
        else
        {
            movementDirection = Vector3.zero;
        }
    }

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
