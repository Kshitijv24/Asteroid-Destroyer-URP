using UnityEngine;

public class DestroyOutsideViewport : MonoBehaviour
{
    Camera mainCamera;

    void Start()
    {
        // Get a reference to the main camera
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Check if the object is outside the viewport
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        // Check if the object is outside the viewport (it's no longer visible)
        if (viewportPosition.x < 0 || viewportPosition.x > 1 || viewportPosition.y < 0 || viewportPosition.y > 1)
        {
            gameObject.SetActive(false);
        }
    }
}
