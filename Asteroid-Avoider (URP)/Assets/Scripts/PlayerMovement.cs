using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private void Update()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            Debug.Log(touchPosition);

            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);
            Debug.Log(worldPosition);
        }
    }
}
