using UnityEngine;

public class TextboxManager : MonoBehaviour
{
    [SerializeField] private MainLogicScript mainLogicScript;
    public int level;
    [SerializeField] private int textboxCount = 0;
    private bool textboxOpen = false;

    void SpawnTextbox(Vector3 position, string text)
    {
        mainLogicScript.SpawnTextbox(position, text);
        textboxOpen = true;
    }

    public void IncreaseTextboxCount()
    {
        textboxCount += 1;
        textboxOpen = false;
    }

    void Update()
    {
        if (!textboxOpen)
        {
            if (level == 1)
            {
                if (textboxCount == 0)
                {
                    SpawnTextbox(new Vector2(-5.2f, 3.6f), "WELCOME TO THE AIRPORT - THE PLACE THAT YOU WILL LOVE BUT HATE \n (PRESS ENTER TO CONTINUE)");
                }
                if (textboxCount == 1)
                {
                    SpawnTextbox(new Vector2(-5.2f, 3.6f), "YOU'LL NOTICE THE MACHINE ABOVE AND BELOW ME");
                }
                if (textboxCount == 2)
                {
                    SpawnTextbox(new Vector2(-5.2f, 3.6f), "BAGS ARE GOING TO START COMING OUT OF THE TOP ONE");
                }
                if (textboxCount == 3)
                {
                    SpawnTextbox(new Vector2(-5.2f, 3.6f), "YOUR JOB IS TO GET THEM TO THE BOTTOM ONE NO MATTER WHAT");
                }
                if (textboxCount == 4)
                {
                    SpawnTextbox(new Vector2(-5.2f, 3.6f), "YOU CAN USE LEFT CLICK TO PLACE A MACHINE AND 'R' TO ROTATE THE MACHINE");
                }
                if (textboxCount == 5)
                {
                    SpawnTextbox(new Vector2(-5.2f, 3.6f), "IF YOU MESS UP YOU CAN PRESS 'Q' TO RESTART THE LEVEL");
                }
                if (textboxCount == 6 && mainLogicScript.GetOutputtedBagsCount() > 1)
                {
                    SpawnTextbox(new Vector2(-5.2f, 3.6f), "GOOD JOB");
                }
                if (textboxCount == 7)
                {
                    SpawnTextbox(new Vector2(-5.2f, 3.6f), "ONCE FIVE BAGS HAVE BEEN PUT INTO EACH OUTPUT THE LEVEL WILL END");
                }
                if (textboxCount == 8 && mainLogicScript.finished)
                {
                    SpawnTextbox(new Vector2(-5.2f, 3.6f), "LEVEL COMPLETE\nPRESS ENTER TO CONTINUE");
                }
                if (textboxCount == 9)
                {
                    mainLogicScript.NextStage();
                    textboxCount = -1;
                }
            }
            if (level == 2)
            {
                if (textboxCount == 0)
                {
                    SpawnTextbox(new Vector2(-5.2f, 3.6f), "THIS NEXT PUZZLE REQUIRES A NEW MACHINE");
                }
                if (textboxCount == 1)
                {
                    SpawnTextbox(new Vector2(-5.2f, 3.6f), "ALL THE MACHINES YOU CAN PLACE CAN BE SEEN ON THE MENU ON THE RIGHT");
                }
                if (textboxCount == 2)
                {
                    SpawnTextbox(new Vector2(-5.2f, 3.6f), "TO SWITCH MACHINE SIMPLY LEFT CLICK THE MACHINE YOU WANT TO USE");
                }
                if (textboxCount == 3 && mainLogicScript.finished)
                {
                    SpawnTextbox(new Vector2(-5.2f, 3.6f), "LEVEL COMPLETE\nPRESS ENTER TO CONTINUE");
                }
                if (textboxCount == 4)
                {
                    mainLogicScript.NextStage();
                    textboxCount = -1;
                }
            }
            if (level == 3)
            {
                if (textboxCount == 0)
                {
                    SpawnTextbox(new Vector2(-5.2f, 3.6f), "LOOKS AS THOUGH THE RENOVATORS MADE SOME MISTAKES");
                }
                if (textboxCount == 1)
                {
                    SpawnTextbox(new Vector2(-5.2f, 3.6f), "UNFORTUNATLY WE DON'T REALLY HAVE A WAY OF REMOVING THOSE");
                }
                if (textboxCount == 2)
                {
                    SpawnTextbox(new Vector2(-5.2f, 3.6f), "JUST TRY AND WORK AROUND THEM");
                }
                if (textboxCount == 3 && mainLogicScript.finished)
                {
                    SpawnTextbox(new Vector2(-5.2f, 3.6f), "LEVEL COMPLETE\nPRESS ENTER TO CONTINUE");
                }
                if (textboxCount == 4)
                {
                    mainLogicScript.NextStage();
                    textboxCount = -1;
                }
            }
            if (level == 4)
            {
                if (textboxCount == 0)
                {
                    SpawnTextbox(new Vector2(-5.2f, 3.6f), "OH, I SEEM TO HAVE LOST MY PLACE");
                }
                if (textboxCount == 1)
                {
                    SpawnTextbox(new Vector2(-5.2f, 3.6f), "TELL YOU WHAT TRY USE RIGHT CLICK AND THE SCROLL WHEEL TO FIND WHERE YOU NEED TO WORK");
                }
                if (textboxCount == 2 && mainLogicScript.finished)
                {
                    SpawnTextbox(new Vector2(0f, 3.6f), "TUTORIAL COMPLETE\nPRESS ENTER TO CONTINUE");
                }
                if (textboxCount == 3)
                {
                    mainLogicScript.NextStage();
                    textboxCount = -1;
                }
            }
        }
    }
}
