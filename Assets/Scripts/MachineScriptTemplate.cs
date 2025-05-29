using System.Collections.Generic;
using UnityEngine;

public class MachineScriptTemplate : MonoBehaviour
{
    [SerializeField] private MainLogicScript mainLogicScript;
    [SerializeField] private List<Bag> input;
    [SerializeField] private List<Bag> output;
    [SerializeField] private int inputSize;
    [SerializeField] private int outputSize;
    [SerializeField] private float processingTime;
    [SerializeField] private int machineType;
    [SerializeField] private List<MachineScriptTemplate> connectedInputMachines;
    [SerializeField] private List<MachineScriptTemplate> connectedOutputMachines;
    private int inputMachineIndex; 
    private int outputMachineIndex = 0;
    private float lastTimeProcessing;

    void Update()
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
            return false;
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
        for (int i = outputMachineIndex; i != outputMachineIndex - 1; i++)
        {
            if (i < connectedOutputMachines.Count)
            {
                i = 0;
            }
            MachineScriptTemplate machineToOutputTo = connectedOutputMachines[i];
            if (machineToOutputTo.InputObject(output[0]))
            {
                output.RemoveAt(0);
                outputMachineIndex += 1;
                return true;
            }
        }
        return false;
    }
}
