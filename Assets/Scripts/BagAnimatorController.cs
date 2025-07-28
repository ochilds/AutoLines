using System;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class BagAnimatorController : MonoBehaviour
{
    [SerializeField] private Vector2 positionOffset = new(0, 0);
    private Vector2Int integerPosition;
    [SerializeField] private Animator animationController;
    private Dictionary<int, string> animationNameLookup = new();
    private MainLogicScript mainLogicScript;

    void Awake()
    {
        Dictionary<int, string> indexToDirection = new()
        {
            { 0, "Up" },
            { 1, "Right" },
            { 2, "Down" },
            { 3, "Left" }
        };
        for (int start_direction = 0; start_direction <= 3; start_direction++)
        {
            for (int end_direction = 0; end_direction <= 3; end_direction++)
            {
                if (!(start_direction == end_direction))
                {
                    int key = (start_direction * 10) + end_direction;
                    string animationName = indexToDirection[start_direction] + "To" + indexToDirection[end_direction];
                    animationNameLookup.Add(key, animationName);
                }
            }
        }
        animationNameLookup.Add(0, "Break");
    }

    void Start()
    {
        // Vector3 animationData = mainLogicScript.GetMachineAnimationAtPosition(integerPosition);
        // PlayAnimation((int)animationData.x, (int)animationData.y, animationData.z - (2.5f / 60f));
        // transform.position = new Vector3(integerPosition.x + positionOffset.x,
                                        //  integerPosition.y + positionOffset.y, -1);
    }

    void Update()
    {
        // Vector3 animationData = mainLogicScript.GetMachineAnimationAtPosition(integerPosition);
        // PlayAnimation((int)animationData.x, (int)animationData.y, animationData.z - (2.5f / 60f));
        // transform.position = new Vector3(integerPosition.x + positionOffset.x,
                                        //  integerPosition.y + positionOffset.y, -1);
    }

    public void PlayAnimation(int startSide, int endSide, float time)
    {
        int directionKey = (startSide * 10) + endSide;
        Debug.Log(animationNameLookup[directionKey]);
        animationController.Play(animationNameLookup[directionKey], 0);
        // animationController.speed = 1f / time;
    }

    public void SetPosition(Vector2Int new_pos)
    {
        integerPosition = new_pos;
        Vector3 animationData = mainLogicScript.GetMachineAnimationAtPosition(integerPosition);
        PlayAnimation((int)animationData.x, (int)animationData.y, animationData.z - (2.5f / 60f));
        transform.position = new Vector3(integerPosition.x,
                                         integerPosition.y, -1);
    }

    public void SetMainLogicScript(MainLogicScript script)
    {
        mainLogicScript = script;
    }

    public void StopAnimation()
    {
        PlayAnimation(0, 0, 1);
    }
}
