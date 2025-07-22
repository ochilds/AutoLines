using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleSetup
{
    public Vector2Int puzzleSize;
    public Dictionary<Vector2Int, int> setup;
    public PuzzleSetup(Dictionary<Vector2Int, int> setup, Vector2Int puzzleSize)
    {
        this.setup = setup;
        this.puzzleSize = puzzleSize;
    }
}

public class SceneManagerScript : MonoBehaviour
{

    private Dictionary<PuzzleSetup, string> setupLookup;
    private PuzzleSetup DEBUGPUZZLE = new(new() { { new(5, 5), 9 } }, new(10, 10));
    [SerializeField]
    private GameObject mainMenuFolder;
    [SerializeField]
    private GameObject levelSelectFolder;

    void Awake()
    {
        DontDestroyOnLoad(this);
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
        SceneManager.LoadScene("Main Menu");
        mainMenuFolder.SetActive(true);
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
    }

    public void LoadDebugPuzzle()
    {
        StartCoroutine(LoadPuzzleStage(DEBUGPUZZLE));
    }
}
