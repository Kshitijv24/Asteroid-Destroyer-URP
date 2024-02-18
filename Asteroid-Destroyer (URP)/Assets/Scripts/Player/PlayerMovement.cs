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
    Vector2 movementDirection;
    Vector2 mouseScreenPosition;
    Vector2 facingDirecion;
    Vector3 mouseWorldPosition;
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
        mouseScreenPosition = value.Get<Vector2>();
        mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);
        //transform.LookAt(new Vector3(mouseWorldPosition.x, 0, mouseWorldPosition.z));
    }

    private void MovePlayer()
    {
        Vector3 movement = new Vector3(movementDirection.x, 0f, movementDirection.y);
        rb.AddForce(movement * forceMagnitude, ForceMode.Force);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
    }

    private void LookAtMouse()
    {
        //facingDirecion = mouseWorldPosition - transform.position;
        //float angle = MathF.Atan2(facingDirecion.y, facingDirecion.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(new Vector3(angle, 0, angle));
        transform.LookAt(new Vector3(mouseWorldPosition.x, 0, mouseWorldPosition.z));
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
