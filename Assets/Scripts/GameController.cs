﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{   
    public Text[] buttonList;  // Referencing gridspaces
    string playerSide; //Player selecting X or O
    public GameObject gameOverPanel;
    public Text gameOverText;
    int moveCount; // To check draw conditions
    public GameObject restartButton;
    public Text ShowActiveSide;
    public GameObject selectSidePanel;
    public Animator SideSelectAnimator;
    bool playerTurn;
    AI ai;  //Referencing AI Script
    public MenuSelect select; //Referencing MainMenu Script
    string Gamemode;

    // Start is called before the first frame update
    void Start()
    {
        playerTurn = true;  
        ai = GetComponent<AI>(); 
    }

    void Awake ()
    {   
        selectSidePanel.SetActive(true);
        SetGameControllerReferenceOnButtons();
        gameOverPanel.SetActive(false);
        moveCount = 0;
        restartButton.SetActive(false);
    }

    void Update()
    {
        ShowActiveSide.text = playerSide;
    }

    void SetGameControllerReferenceOnButtons ()
    {
        for (int i = 0; i < buttonList.Length; i++)

        {            
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public string GetPlayerSide ()
    {
        return playerSide;
    }

    public int EndTurn ()
    {   

        moveCount++;
        if (buttonList [0].text == ShowActiveSide.text && buttonList [1].text == ShowActiveSide.text && buttonList [2].text == ShowActiveSide.text)
        {
            GameOver(ShowActiveSide.text);
            return 0;
        }

        else if (buttonList [3].text == ShowActiveSide.text && buttonList [4].text == ShowActiveSide.text && buttonList [5].text == ShowActiveSide.text)
        {
            GameOver(ShowActiveSide.text);
            return 0;
        }

        else if (buttonList [6].text == ShowActiveSide.text && buttonList [7].text == ShowActiveSide.text && buttonList [8].text == ShowActiveSide.text)
        {
            GameOver(ShowActiveSide.text);
            return 0;
        }

        else if (buttonList [0].text == ShowActiveSide.text && buttonList [3].text == ShowActiveSide.text && buttonList [6].text == ShowActiveSide.text)
        {
            GameOver(ShowActiveSide.text);
            return 0;
        }

        else if (buttonList [1].text == ShowActiveSide.text && buttonList [4].text == ShowActiveSide.text && buttonList [7].text == ShowActiveSide.text)
        {
            GameOver(ShowActiveSide.text);
            return 0;
        }

        else if (buttonList [2].text == ShowActiveSide.text && buttonList [5].text == ShowActiveSide.text && buttonList [8].text == ShowActiveSide.text)
        {
            GameOver(ShowActiveSide.text);
            return 0;
        }

        else if (buttonList [0].text == ShowActiveSide.text && buttonList [4].text == ShowActiveSide.text && buttonList [8].text == ShowActiveSide.text)
        {
            GameOver(ShowActiveSide.text);
            return 0;
        }

        else if (buttonList [2].text == ShowActiveSide.text && buttonList [4].text == ShowActiveSide.text && buttonList [6].text == ShowActiveSide.text)
        {
            GameOver(ShowActiveSide.text);
            return 0;
        }

        else if (moveCount >= 9)
        {
            GameOver("draw");
            return 0;
        }

        ChangeSides();
        return 0;

    }

    void GameOver (string winningPlayer)
    {
        SetBoardInteractable(false);

        //Disabling AI due to stackoverflowexception at game end. doesnt work
        //ai.enabled = false;

        gameOverPanel.SetActive(true);
        if(winningPlayer == "draw")
            SetGameOverText("It's a draw");
        else
            SetGameOverText (ShowActiveSide.text + " Wins!");
        restartButton.SetActive(true);

    }
    void SetGameOverText (string value)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = value;
    }

    public void ChangeSides ()
    {   
        //ShowActiveSide.text = (ShowActiveSide.text == "X") ? "O" : "X" ;
        
        if(Gamemode == "EasyAI" || Gamemode == "HardAI")
        {
            if(playerTurn)
            {   
                playerTurn = false;
                ai.PlayTurn();
            }
            else
            {
                playerTurn = true;
            }

        }
        else
        {
            playerSide = (playerSide == "X") ? "O" : "X" ;   
        }
    }

    public void RestartGame ()
    {    
        selectSidePanel.SetActive(true);
        moveCount = 0;
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        SetBoardInteractable(true);
        playerTurn = true;
        //Enabling AI
        //ai.enabled = true;

        for (int i = 0; i < buttonList.Length; i++)
        
        {
            buttonList [i].text = "";
        }
    }

    void SetBoardInteractable (bool toggle)
    {
        for (int i = 0; i < buttonList.Length; i++)
        
        {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }

    public void SetPlayerSide(string selectedPlayerSide)
    {
        playerSide = selectedPlayerSide;
        AfterSideSelect();
        //selectSidePanel.SetActive(false);
    }


    void AfterSideSelect()
    {   
        SideSelectAnimator.SetTrigger("StartSideSelected");
        Invoke("nullFunc",0.7f);
        //Debug.Log("Function works !! You now have different problems");
    }

    void nullFunc(){ selectSidePanel.SetActive(false); }   // For Invoke method..........    God works in mysterious ways

    public bool returnTurn()
    {
        return playerTurn;
    }

    public void ReturnGamemode(string gamemode)
    {
        Gamemode = gamemode;
        select.AfterGamemodeSelect();
    }

    public string GetGamemode()  // For the AI Script
    {
        return Gamemode;
    }
}

   

