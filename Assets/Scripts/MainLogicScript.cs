using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class Bag
{
    public Bag()
    {
        
    }
}

public class MainLogicScript : MonoBehaviour
{
    private int[,] gridValues;
    private Vector2 gridDimensions;
    [SerializeField] private Vector2 gridOffset;
    [SerializeField] private GameObject cellRenderingParent;
    [SerializeField] private GameObject cellRenderingSpritePrefab;
    [SerializeField] private Sprite[] cellRenderingSprites;

    // Initialize grid values with empty squares in middle and special edges
    public void InitializeGridValues(int gridHeight, int gridWidth)
    {
        // Calculate offset to centre grid on 0, 0
        gridOffset = new(0.5f - (float)gridHeight / 2, 0.5f - (float)gridWidth / 2);

        gridDimensions = new Vector2(gridWidth, gridHeight);
        // Create grid of correct size
        gridValues = new int[gridWidth, gridHeight];
        // Generate values for corners
        EditEmptyCellValue(0, 0, 1);
        EditEmptyCellValue(gridWidth - 1, 0, 2);
        EditEmptyCellValue(gridWidth - 1, gridHeight - 1, 3);
        EditEmptyCellValue(0, gridHeight - 1, 4);
        // Generate values for edges
        for (int x = 1; x < gridWidth - 1; x++)
        {
            EditEmptyCellValue(x, 0, 5);
            EditEmptyCellValue(x, gridHeight - 1, 6);
        }
        for (int y = 1; y < gridHeight - 1; y++)
        {
            EditEmptyCellValue(0, y, 7);
            EditEmptyCellValue(gridWidth - 1, y, 8);
        }
    }

    // Changed cell value at inputed position to inputed value if the cell is empty
    public void EditEmptyCellValue(int x, int y, int value)
    {
        if (gridValues[x, y] == 0)
        {
            gridValues[x, y] = value;
        }
    }

    // Loop through all cells and render sprites
    public void RenderGrid()
    {
        ClearRenderedCells();
        for (int x = 0; x < gridDimensions.x; x++)
        {
            for (int y = 0; y < gridDimensions.y; y++)
            {
                InitializeCell(y, x, gridValues[x, y]);
            }
        }
    }

    // Delete all existing cells
    public void ClearRenderedCells()
    {
        foreach (Transform child in cellRenderingParent.transform)
        {
            Destroy(child.gameObject);
        }
    }

    // Generates one cell at position and type
    public void InitializeCell(int xPos, int yPos, int spriteIndex)
    {
        GameObject cell = Instantiate(cellRenderingSpritePrefab, new Vector2(xPos, yPos) + gridOffset,
                                    Quaternion.identity, cellRenderingParent.transform);
        cell.GetComponent<SpriteRenderer>().sprite = cellRenderingSprites[spriteIndex];
    }

    void Start()
    {
        InitializeGridValues(50, 70);
        RenderGrid();
    }

    void FixedUpdate()
    {
        // RenderGrid();
    }
}
