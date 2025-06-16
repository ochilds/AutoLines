using System.Collections.Generic;
using UnityEngine;

public class MachineScriptTemplate : MonoBehaviour
{
    [SerializeField] private MainLogicScript mainLogicScript;
    [SerializeField] private List<Bag> input = new();
    [SerializeField] private List<Bag> output = new();
    [SerializeField] private int inputSize;
    [SerializeField] private int outputSize;
    [SerializeField] private float processingTime;
    public int machineType;
    [SerializeField] private List<MachineScriptTemplate> connectedInputMachines;
    [SerializeField] private MachineScriptTemplate connectedOutputMachine = null;
    private int inputMachineIndex;
    private int outputMachineIndex = 0;
    private float lastTimeProcessing;
    public int inputAmount = 0;
    public int outputAmount = 0;

    void Update()
    {
        inputAmount = input.Count;
        outputAmount = output.Count;
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

    public bool InputObject(Bag bag)
    {
        // Only add bag if there is room in input
        if (input.Count < inputSize)
        {
            input.Add(bag);
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
                    output.Add(new());
                    return true;
                // Output block
                case 10:
                    mainLogicScript.OutputBag(input[0]);
                    input.RemoveAt(0);
                    return true;
                // Belt
                case 11 or 12 or 13 or 14 or 15 or 16 or 17 or 18:
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


    public bool ConnectedToOutput()
    {
        if (connectedOutputMachine != null)
        {
            return true;
        }
        return false;
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
                processingTime = 1;
                // Create new empty bag for control
                InputObject(new Bag());
                break;
            // Output block
            case 10:
                inputSize = 1;
                outputSize = 1;
                processingTime = 0.05f;
                break;
            // Belt
            case 11 or 12 or 13 or 14 or 15 or 16 or 17 or 18:
                inputSize = 1;
                outputSize = 1;
                processingTime = 0.1f;
                break;
        }
    }
}
