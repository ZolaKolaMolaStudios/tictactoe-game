using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HardAI : MonoBehaviour
{
    //Serialize gridspaces
    public Text[] gridButtons;
    int Score;

    //Get the buttons
    private GameController gameController;

    void Awake()
    {
        gameController = GetComponent<GameController>();  // To be edited out if not used
    }

    void Update()
    {

    }

    void MakeMove()
    { }

    void Minimax()
    { }

    int CheckWinCondition()   // return score if won
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                //Vertical win
                if (i == 0)
                {
                    if ((gridButtons[i + 3 * j] == gridButtons[i + 3 * j + 1]) && (gridButtons[i + 3 * j + 1] == gridButtons[i + 3 * j + 2])) // Take with a grain of salt
                    {
                        Score = EndCondition();
                    }
                }

                //Horizontal win
                else if ((i + 3*j) <= 9)
                {
                    if ((gridButtons[i + 3 * j] == gridButtons[i + 3 * j + 3]) && (gridButtons[i + 3 * j + 3] == gridButtons[i + 3 * j + 6])) //Review Stat
                    {
                        Score = EndCondition();
                    }
                }

               //Diagonal win
                else if (gridButtons[0] == gridButtons[4] && gridButtons[4] == gridButtons[8])
                {
                    Score = EndCondition();
                }
                else if (gridButtons[2] == gridButtons[4] && gridButtons[4] == gridButtons[6])
                {
                    Score = EndCondition();
                }
            }
        }
    }


    string GetComputerSide()
    {
        string getPlayerSide = gameController.GetPlayerSide();
        if (getPlayerSide == "X")
            return "O";
        else
            return "X";
    }


    void EndCondition()
    {
        if (AISide != activeSide)
        {
            return 10;
        }
        else
        {
            return -10;
        }
    }

    void GetAiSide()
    {
        //Code getting Ai side here
    }

    void GetSpaceIfEmpty()
    {
        if (buttonList[value].GetComponentInParent<Button>().interactable == true)
        {
            buttonList[value].text = GetComputerSide();
            buttonList[value].GetComponentInParent<Button>().interactable = false;
            gameController.EndTurn();
        }
        else
        {
            GetSpaceIfEmpty();
        }
    }
}

