using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class CameraLogic : MonoBehaviour
{
    private Camera camera;
    [SerializeField] private float xBounds;
    [SerializeField] private float yBounds;
    private Vector2 positionOfMouseWhenMovementStart;
    private Controls controls;
    private bool mouseMovementActive = false;

    void Start()
    {
        // Get camera
        camera = GetComponent<Camera>();
        // Enable Input
        controls = new();
        controls.TestingMouseCamera.Enable();
        controls.TestingMouseCamera.ActivateMouseMovement.started += ActivateCameraMovement;
        controls.TestingMouseCamera.ActivateMouseMovement.canceled += DeactivateCameraMovement;
    }

    public void MoveCamera(Vector2 value)
    {
        // Move the camera
        transform.Translate(value);
        // Snap back in bound if outside of bounds
        if (transform.position.x > xBounds - 9)
        {
            transform.Translate(Vector2.right * (xBounds - 9 - transform.position.x));
        }
        if (transform.position.x < -xBounds + 9)
        {
            transform.Translate(Vector2.left * (xBounds - 9 + transform.position.x));
        }
        if (transform.position.y > yBounds)
        {
            transform.Translate(Vector2.up * (yBounds - transform.position.y));
        }
        if (transform.position.y < -yBounds + 10)
        {
            transform.Translate(Vector2.down * (yBounds - 10 + transform.position.y));
        }
    }

    public void SetCameraBounds(Vector2 bounds)
    {
        // Set the bounds (The dimesions are flipped)
        yBounds = bounds.x;
        xBounds = bounds.y;
    }

    public void ActivateCameraMovement(InputAction.CallbackContext context)
    {
        mouseMovementActive = true;
        positionOfMouseWhenMovementStart = camera.ScreenToWorldPoint(Input.mousePosition);
    }

    public void DeactivateCameraMovement(InputAction.CallbackContext context)
    {
        mouseMovementActive = false;
    }

    void Update()
    {
        if (mouseMovementActive)
        {
            Vector2 mousePosition = (Vector2)camera.ScreenToWorldPoint(Input.mousePosition);
            MoveCamera(positionOfMouseWhenMovementStart - mousePosition);
        }
    }
}
