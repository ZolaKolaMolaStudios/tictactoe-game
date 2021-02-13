using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AI : MonoBehaviour
{   
    //Get grids
    public Text[] buttonList;

    //Button[,] buttonArray;
    //Button[,] activeButtons;

    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {   
        gameController = GetComponent<GameController>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void InitializeGrid()
    // {
    //     for(int i = 0; i < 9;i++)
    //     {   
    //         //Debug.Log("Running");   
    //         for(int j = 0; j < 3; j++)
    //         {   
    //             //Debug.Log("Running 2");   
    //             for(int k = 0; k < 3;k++)
    //             {   
    //                 //Debug.Log("Running 3");
    //                 buttonArray[j,k] = buttonList[i];
    //                 //Debug.Log("Running 4");
    //             }
    //         }
    //     }       
    // }

    // void GetActiveButtons()
    // {
    //     for(int i = 0; i < 3; i++)
    //     {
    //         for(int j = 0; j < 3; j++)
    //         {
    //             if(buttonArray[i,j].interactable == true) 
    //             {
    //                 activeButtons[i,j] = buttonArray[i,j];    
    //             }
    //         }
    //     }
    // }

    public void PlayTurn()
    {
        //AI Goes here I guess
        if(!gameController.returnTurn())
        {   
            //easyai
            int value = Random.Range(0, 8);
            if (buttonList[value].GetComponentInParent<Button>().interactable == true)
            {
                buttonList[value].text = GetComputerSide();
                buttonList[value].GetComponentInParent<Button>().interactable = false;
                gameController.EndTurn();
            }
            else
            {
                PlayTurn();
            }
        }

    }

    string GetComputerSide()
    {   
        string getPlayerSide = gameController.GetPlayerSide();
        if(getPlayerSide == "X")
            return "O";
        else
            return "X";
    }
}
