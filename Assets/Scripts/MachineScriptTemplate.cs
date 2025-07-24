using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class MachineScriptTemplate : MonoBehaviour
{
    [SerializeField] private MainLogicScript mainLogicScript;
    [SerializeField] private List<BagAnimatorController> input = new();
    [SerializeField] private List<BagAnimatorController> output = new();
    [SerializeField] private int inputSize;
    [SerializeField] private int outputSize;
    [SerializeField] private float processingTime;
    public int machineType;
    [SerializeField] private List<MachineScriptTemplate> connectedInputMachines;
    [SerializeField] private MachineScriptTemplate connectedOutputMachine = null;
    private int inputMachineIndex;
    private int outputMachineIndex = 0;
    private float lastTimeProcessing;
    [SerializeField] private Vector2Int position;
    private int inputSide;
    private int outputSide;
    [SerializeField] private GameObject bagPrefab;
    private bool paused = false;

    void Update()
    {
        if (!paused)
        {
            // If there is at least one bag in input try processes it
            if (input.Count > 0)
            {
                lastTimeProcessing += Time.deltaTime;
                if (lastTimeProcessing >= processingTime)
                {
                    if (ProcessObject())
                    {
                        lastTimeProcessing = 0f;
                    }
                }
            }
            // Try to output object
            OutputObject();
        }
    }

    public void UpdatePosition(Vector2Int newPos)
    {
        position = new Vector2Int(newPos.y, newPos.x);
    }

    public void SetBagPrefab(GameObject prefab)
    {
        bagPrefab = prefab;
    }

    public bool InputObject(BagAnimatorController bag)
    {
        // Only add bag if there is room
        if (input.Count + output.Count < inputSize)
        {
            input.Add(bag);
            bag.transform.position = new Vector3(position.x, position.y, -1);
            bag.SetPosition(position);
            return true;
        }
        return false;
    }

    public bool ProcessObject()
    {
        // Check to make sure there is room in output
        if (output.Count < outputSize)
        {
            switch (machineType)
            {
                // Input block
                case 9:
                    GameObject newBag = Instantiate(bagPrefab);
                    newBag.transform.position = new Vector3(position.x, position.y, -1);
                    BagAnimatorController script = newBag.GetComponent<BagAnimatorController>();
                    output.Add(script);
                    script.SetMainLogicScript(mainLogicScript);
                    return true;
                // Output block
                case 10:
                    mainLogicScript.OutputBag(input[0]);
                    input.RemoveAt(0);
                    return true;
                // Belt
                case 11 or 12 or 13 or 14 or 15 or 16 or 17 or 18 or 19 or 20 or 21 or 22:
                    if (input.Count > 0)
                    {
                        output.Add(input[0]);
                        input.RemoveAt(0);
                    }
                    return true;
            }
        }
        return false;
    }

    public bool OutputObject()
    {
        // Make sure there is a bag to output
        if (output.Count == 0)
        {
            return false;
        }
        if (!ConnectedToOutput())
        {
            return false;
        }
        if (connectedOutputMachine.InputObject(output[0]))
        {
            Debug.Log("Outputted object from machine type " + machineType);
            output.RemoveAt(0);
            outputMachineIndex += 1;
            return true;
        }
        return false;
    }

    public void SetMainLogicScript(MainLogicScript script)
    {
        mainLogicScript = script;
    }

    public void ConnectOutputMachine(MachineScriptTemplate machine)
    {
        connectedOutputMachine = machine;
    }

    public Vector3 GetAnimationIndex()
    {
        return new Vector3(inputSide, outputSide, processingTime);
    }

    public bool ConnectedToOutput()
    {
        if (connectedOutputMachine != null)
        {
            return true;
        }
        return false;
    }

    public void PauseGame()
    {
        paused = !paused;
    }

    public void SetMachineType(int type)
    {
        machineType = type;
        switch (machineType)
        {
            // Input block
            case 9:
                inputSize = 1;
                outputSize = 1;
                processingTime = 3;
                // Create new empty bag for control
                input.Add(new());
                break;
            // Output block
            case 10:
                inputSize = 1;
                outputSize = 1;
                processingTime = 0.005f;
                break;
            // Belt
            case 11 or 12 or 13 or 14 or 15 or 16 or 17 or 18 or 19 or 20 or 21 or 22:
                inputSize = 1;
                outputSize = 1;
                processingTime = 0.5f;
                break;
        }
        switch (machineType)
        {
            case 10:
                inputSide = 0;
                outputSide = 2;
                break;
            case 11:
                inputSide = 3;
                outputSide = 1;
                break;
            case 12:
                inputSide = 0;
                outputSide = 2;
                break;
            case 13:
                inputSide = 1;
                outputSide = 3;
                break;
            case 14:
                inputSide = 2;
                outputSide = 0;
                break;
            case 15:
                inputSide = 3;
                outputSide = 0;
                break;
            case 16:
                inputSide = 0;
                outputSide = 1;
                break;
            case 17:
                inputSide = 1;
                outputSide = 2;
                break;
            case 18:
                inputSide = 2;
                outputSide = 3;
                break;
            case 19:
                inputSide = 3;
                outputSide = 2;
                break;
            case 20:
                inputSide = 0;
                outputSide = 3;
                break;
            case 21:
                inputSide = 1;
                outputSide = 0;
                break;
            case 22:
                inputSide = 2;
                outputSide = 1;
                break;
        }
    }
}
