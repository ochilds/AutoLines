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
                if (textboxCount == 6 && mainLogicScript.GetOutputtedBagsCount() > 2)
                {
                    SpawnTextbox(new Vector2(-5.2f, 3.6f), "GOOD JOB");
                }
                if (textboxCount == 7)
                {
                    SpawnTextbox(new Vector2(-5.2f, 3.6f), "ONCE TEN BAGS HAVE BEEN PUT INTO EACH OUTPUT THE LEVEL WILL END");
                }
            }
        }
    }
}
