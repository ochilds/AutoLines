using UnityEngine;

public class CursorControl : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    void Awake()
    {
        // Initalize sprite renderer
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeSprite(Sprite newSprite)
    {
        // Update sprite
        spriteRenderer.sprite = newSprite;
    }

    public void SetPosition(Vector2 position)
    {
        // Set position
        transform.position = position;
    }
}
