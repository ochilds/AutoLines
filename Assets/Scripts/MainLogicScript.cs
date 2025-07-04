using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainLogicScript : MonoBehaviour
{
    private int[,] gridValues;
    private Vector2 gridDimensions;
    [SerializeField] private Vector2 gridOffset;
    [SerializeField] private GameObject cellRenderingParent;
    [SerializeField] private GameObject cellRenderingSpritePrefab;
    [SerializeField] private Sprite[] cellRenderingSprites;
    [SerializeField] private GameObject machineLogicParent;
    [SerializeField] private GameObject machineLogicPrefab;
    [SerializeField] private List<BagAnimatorController> outputtedBags = new();
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private float cameraSensitivity = 1;
    [SerializeField] private float zoomSensitivty = 10;
    [SerializeField] private GameObject cursorRenderer;
    [SerializeField] private int cursorSpriteIndex;
    [SerializeField] private int[] validCursorSpriteIndexes;
    private Dictionary<int, int[]> machineOutputDirection = new();
    private Dictionary<Vector2Int, MachineScriptTemplate> machineScriptLookup = new();
    private int FUNCTIONSPRITECUTOFF = 8;
    private Controls controls;
    [SerializeField] private int bagsRequiredToEndStage;
    private bool finished = false;
    [SerializeField] private GameObject bagPrefab;

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

    public Vector2Int WorldPositionToGridPosition(Vector2 position)
    {
        return new Vector2Int((int)(position.y - gridOffset.y), (int)(position.x - gridOffset.x));
    }

    // Changed cell value at inputed position to inputed value if the cell is empty
    public void EditEmptyCellValue(int x, int y, int value, bool render = false)
    {
        if (gridValues[x, y] == 0)
        {
            gridValues[x, y] = value;
            if (value > FUNCTIONSPRITECUTOFF)
            {
                InitializeMachineLogic(value, x, y);
            }
            if (render)
            {
                RenderGrid();
            }
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

    // Generate the correct script when a machine is required
    public void InitializeMachineLogic(int machineType, int xPos, int yPos)
    {
        GameObject machine = Instantiate(machineLogicPrefab, machineLogicParent.transform);
        MachineScriptTemplate script = machine.GetComponent<MachineScriptTemplate>();
        script.SetMachineType(machineType);
        script.SetMainLogicScript(GetComponent<MainLogicScript>());
        script.UpdatePosition(new Vector2Int((int)(xPos + gridOffset.y), (int)(yPos + gridOffset.x)));
        script.SetBagPrefab(bagPrefab);
        machineScriptLookup.Add(new(xPos, yPos), script);
        Debug.Log("Added new key to machine script lookup " + new Vector2Int(xPos, yPos));
        TryConnectAllMachines();
    }

    public void TryConnectAllMachines()
    {
        foreach (KeyValuePair<Vector2Int, MachineScriptTemplate> machinePosPair in machineScriptLookup)
        {
            MachineScriptTemplate machine = machinePosPair.Value;
            if (!machine.ConnectedToOutput())
            {
                Vector2Int pos = machinePosPair.Key;
                int[] outputDirection = machineOutputDirection[machine.machineType];
                if (gridValues[pos.x + outputDirection[0], pos.y + outputDirection[1]] > FUNCTIONSPRITECUTOFF)
                {
                    machine.ConnectOutputMachine(machineScriptLookup[new Vector2Int(pos.x + outputDirection[0], pos.y + outputDirection[1])]);
                }
            }
        }
    }

    public Vector3 GetMachineAnimationAtPosition(Vector2Int pos)
    {
        MachineScriptTemplate machine = machineScriptLookup[WorldPositionToGridPosition(pos)];
        return machine.GetAnimationIndex();
    }

    public void OutputBag(BagAnimatorController bag)
    {
        Debug.Log("Outputted Bag");
        outputtedBags.Add(bag);
        Destroy(bag.gameObject);
    }

    public void MoveCursor()
    {
        Vector2 mousePosition = (Vector2)mainCamera.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
        Vector2 roundedMousePosition = new Vector2(Mathf.Round(mousePosition.x), Mathf.Round(mousePosition.y));
        cursorRenderer.GetComponent<CursorControl>().SetPosition(roundedMousePosition);
    }

    public void SetCursorSprite()
    {
        cursorRenderer.GetComponent<CursorControl>().ChangeSprite(cellRenderingSprites[cursorSpriteIndex]);
    }

    public void PlaceMachineOnGrid(InputAction.CallbackContext context)
    {
        Vector2 mousePosition = (Vector2)mainCamera.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
        Vector2 roundedMousePosition = new Vector2(Mathf.Round(mousePosition.x), Mathf.Round(mousePosition.y));
        Vector2Int gridMousePosition = WorldPositionToGridPosition(roundedMousePosition);
        EditEmptyCellValue(gridMousePosition.x, gridMousePosition.y, cursorSpriteIndex, true);
    }

    public void UpdateCursorSprite(int newSpriteIndex)
    {
        cursorSpriteIndex = newSpriteIndex;
        SetCursorSprite();
    }

    public void NextMachineOnCursor(InputAction.CallbackContext context)
    {
        int currentValidIndex = Array.IndexOf(validCursorSpriteIndexes, cursorSpriteIndex);
        if (currentValidIndex > validCursorSpriteIndexes.Count() - 2)
        {
            UpdateCursorSprite(validCursorSpriteIndexes[0]);
            return;
        }
        UpdateCursorSprite(validCursorSpriteIndexes[currentValidIndex + 1]);
    }

    public void PreviousMachineOnCursor(InputAction.CallbackContext context)
    {
        int currentValidIndex = Array.IndexOf(validCursorSpriteIndexes, cursorSpriteIndex);
        if (currentValidIndex == 0)
        {
            UpdateCursorSprite(validCursorSpriteIndexes[validCursorSpriteIndexes.Count() - 1]);
            return;
        }
        UpdateCursorSprite(validCursorSpriteIndexes[currentValidIndex - 1]);
    }

    void InitializeOutputDirections()
    {
        int[] down = { -1, 0 };
        int[] right = { 0, 1 };
        int[] up = { 1, 0 };
        int[] left = { 0, -1 };
        machineOutputDirection.Add(9, down);
        machineOutputDirection.Add(10, down);
        machineOutputDirection.Add(11, right);
        machineOutputDirection.Add(12, down);
        machineOutputDirection.Add(13, left);
        machineOutputDirection.Add(14, up);
        machineOutputDirection.Add(15, up);
        machineOutputDirection.Add(16, right);
        machineOutputDirection.Add(17, down);
        machineOutputDirection.Add(18, left);
        machineOutputDirection.Add(19, down);
        machineOutputDirection.Add(20, left);
        machineOutputDirection.Add(21, up);
        machineOutputDirection.Add(22, right);
    }

    void Start()
    {
        InitializeGridValues(25, 35);
        mainCamera.GetComponent<CameraLogic>().SetCameraBounds(gridDimensions / 2);
        RenderGrid();
        // Initilize input objects
        controls = new();
        controls.DefaultGameplay.Enable();
        controls.DefaultGameplay.PlaceMachine.performed += PlaceMachineOnGrid;
        controls.DefaultGameplay.NextMachine.performed += NextMachineOnCursor;
        controls.DefaultGameplay.PreviousMachine.performed += PreviousMachineOnCursor;
        SetCursorSprite();
        InitializeOutputDirections();
        // Debug
    }

    void FixedUpdate()
    {
        MoveCursor();
    }

    void Update()
    {
        mainCamera.GetComponent<CameraLogic>().ZoomCamera(controls.DefaultGameplay.ZoomCamera.ReadValue<Vector2>().y * zoomSensitivty);
        if (outputtedBags.Count > bagsRequiredToEndStage)
        {
            finished = true;
        }
    }
}
