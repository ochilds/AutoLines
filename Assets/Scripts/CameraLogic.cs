using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class CameraLogic : MonoBehaviour
{
    private Camera main_camera;
    [SerializeField] private float xBounds;
    [SerializeField] private float yBounds;
    private Vector2 positionOfMouseWhenMovementStart;
    private Controls controls;
    private bool mouseMovementActive = false;
    [SerializeField] float moveSpeed = 1;
    private bool paused = false;

    void Start()
    {
        // Get camera
        main_camera = GetComponent<Camera>();
        // Enable Input
        controls = new();
        controls.DefaultGameplay.Enable();
        controls.DefaultGameplay.ActivateMouseMovement.started += ActivateCameraMovement;
        controls.DefaultGameplay.ActivateMouseMovement.canceled += DeactivateCameraMovement;
    }

    public void MoveCamera(Vector2 value, bool movingWRespectToZoom = false)
    {
        // Move the camera with respect to the zoom
        if (movingWRespectToZoom)
        {
            transform.Translate(main_camera.orthographicSize * moveSpeed * value);

        }
        else
        {
            transform.Translate(value);
        }
        // // Snap back in bound if outside of bounds
        // float cameraHeight = camera.orthographicSize;
        // float cameraWidth = camera.orthographicSize * camera.aspect;
        // if (transform.position.x > xBounds - cameraWidth)
        // {
        //     transform.Translate(Vector2.right * (xBounds - cameraWidth - transform.position.x));
        // }
        // if (transform.position.x < -xBounds + cameraWidth)
        // {
        //     transform.Translate(Vector2.left * (xBounds - cameraWidth + transform.position.x));
        // }
        // if (transform.position.y > yBounds - 5)
        // {
        //     transform.Translate(Vector2.up * (yBounds - 5 - transform.position.y));
        // }
        // if (transform.position.y < -yBounds + cameraHeight + 5)
        // {
        //     transform.Translate(Vector2.down * (yBounds - cameraHeight - 5 + transform.position.y));
        // }
    }

    public void FocusCameraOnPosition(Vector2 position)
    {
        transform.position = position;
        main_camera.orthographicSize = 5;
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
        positionOfMouseWhenMovementStart = main_camera.ScreenToWorldPoint(Input.mousePosition);
    }

    public void DeactivateCameraMovement(InputAction.CallbackContext context)
    {
        mouseMovementActive = false;
    }

    // Add the mouse scroll delta to camera zoom (Scroll is oppisite direct to zoom)
    public void ZoomCamera(float amount)
    {
        main_camera.orthographicSize -= amount;
        if (main_camera.orthographicSize > 50)
        {
            main_camera.orthographicSize = 50;
        }
        if (main_camera.orthographicSize < 0.6f)
        {
            main_camera.orthographicSize = 0.6f;
        }
    }

    public void PauseGame()
    {
        paused = !paused;
    }

    void Update()
    {
        if (!paused)
        {
            if (mouseMovementActive)
            {
                Vector2 mousePosition = (Vector2)main_camera.ScreenToWorldPoint(Input.mousePosition);
                MoveCamera(positionOfMouseWhenMovementStart - mousePosition);
            }
        }
    }
}
