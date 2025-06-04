using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    private Camera camera;
    [SerializeField] private float xBounds;
    [SerializeField] private float yBounds;

    void Start()
    {
        camera = GetComponent<Camera>();
    }

    public void MoveCamera(Vector2 value)
    {
        Debug.Log(camera.ScreenToWorldPoint(value));
        transform.Translate(value);
        if (transform.position.x > xBounds)
        {
            transform.Translate(Vector2.right * (xBounds - transform.position.x));
        }
        if (transform.position.x < -xBounds)
        {
            transform.Translate(Vector2.left * (xBounds + transform.position.x));
        }
        if (transform.position.y > yBounds)
        {
            transform.Translate(Vector2.up * (yBounds - transform.position.y));
        }
        if (transform.position.y < -yBounds)
        {
            transform.Translate(Vector2.down * (yBounds + transform.position.y));
        }
    }
}
