using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PuzzleSetup
{
    public Vector2Int puzzleSize;
    public Dictionary<Vector2Int, int> setup;
    public int puzzleIndex;
    public PuzzleSetup(int index, Vector2Int puzzleSize, Dictionary<Vector2Int, int> setup)
    {
        this.setup = setup;
        this.puzzleSize = puzzleSize;
        this.puzzleIndex = index;
    }
}

public class SceneManagerScript : MonoBehaviour
{
    private static SceneManagerScript instance;
    private List<PuzzleSetup> puzzleSetups = new();
    private PuzzleSetup DEBUGPUZZLE = new(-1, new(5, 6), new() { });
    [SerializeField] private GameObject mainMenuFolder;
    [SerializeField] private GameObject levelSelectFolder;
    private int loadedPuzzleIndex = -1;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(this);
    }

    void Start()
    {
        puzzleSetups.Add(new PuzzleSetup(1, new(9, 9), new Dictionary<Vector2Int, int>() { { new(15, 3), 9 },
                                                                                             { new(12, 3), 10 } }));
        puzzleSetups.Add(new PuzzleSetup(2, new(9, 9), new Dictionary<Vector2Int, int>() { { new(15, 3), 9 },
                                                                                             { new(14, 4), 10 } }));
        puzzleSetups.Add(new PuzzleSetup(3, new(9, 9), new Dictionary<Vector2Int, int>() { { new(15, 4), 9 },
                                                                                             { new(12, 6), 10 },
                                                                                             { new(14, 3), 23 },
                                                                                             { new(13, 3), 23 },
                                                                                             { new(14, 5), 23 },
                                                                                             { new(13, 5), 23 } }));
        puzzleSetups.Add(new PuzzleSetup(4, new(9, 9), new Dictionary<Vector2Int, int>() { { new(15, 11), 9 },
                                                                                             { new(10, 11), 10 },
                                                                                             { new(9, 11), 9 },
                                                                                             { new(7, 9), 10 },}));
    }

    public void LoadLevelSelect()
    {
        mainMenuFolder.SetActive(false);
        levelSelectFolder.SetActive(true);
    }

    public void LoadMainMenu()
    {
        levelSelectFolder.SetActive(false);
        mainMenuFolder.SetActive(true);
    }

    public void LoadMainMenuScene()
    {
        loadedPuzzleIndex = -1;
        SceneManager.LoadScene("Main Menu");
        Destroy(gameObject);
    }

    public void StopGame()
    {
        Application.Quit();
    }

    private IEnumerator LoadPuzzleStage(PuzzleSetup puzzle)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync("Gameplay");
        while (!op.isDone) { yield return null; }

        MainLogicScript logicScript = GameObject.FindGameObjectWithTag("MainLogic").GetComponent<MainLogicScript>();
        logicScript.Initialize(puzzle.puzzleSize);
        foreach (KeyValuePair<Vector2Int, int> tile in puzzle.setup)
        {
            logicScript.EditEmptyCellValue(tile.Key.x, tile.Key.y, tile.Value);
        }
        logicScript.RenderGrid();

        TextboxManager textboxManager = GameObject.FindGameObjectWithTag("TextboxManager").GetComponent<TextboxManager>();
        textboxManager.level = puzzle.puzzleIndex;
    }

    public void LoadDebugPuzzle()
    {
        StartCoroutine(LoadPuzzleStage(DEBUGPUZZLE));
    }

    public void LoadPuzzle(int index)
    {
        loadedPuzzleIndex = index;
        StartCoroutine(LoadPuzzleStage(puzzleSetups[index]));
    }

    public void ResetPuzzle(InputAction.CallbackContext context)
    {
        if (loadedPuzzleIndex != -1)
        {
            StartCoroutine(LoadPuzzleStage(puzzleSetups[loadedPuzzleIndex]));
        }
    }

    public void LoadNextPuzzle()
    {
        if (loadedPuzzleIndex == puzzleSetups.Count)
        {
            LoadMainMenuScene();
        }
        else
        {
            LoadPuzzle(loadedPuzzleIndex + 1);
        }
    }
}
