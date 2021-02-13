using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{   
    public Text[] buttonList;
    private string playerSide;
    public GameObject gameOverPanel;
    public Text gameOverText;
    private int moveCount;
    public GameObject restartButton;
    public Text ShowActiveSide;
    public GameObject selectSidePanel;
    public Animator SideSelectAnimator;
    bool playerTurn;
    AI ai;

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
        for (int i = 0; i < 3; i++)

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
        for (int i = 0; i < 3; i++)
            for(int j = 0; j < 3; j++)
            {
                ;
            }
        
        if (moveCount >= 9)
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
        ShowActiveSide.text = (ShowActiveSide.text == "X") ? "O" : "X" ;
        playerTurn = (playerTurn == true) ? false : true;
        if(!playerTurn)
            ai.PlayTurn();
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

        for (int i = 0; i < 3; i++)
        
        {
            buttonList [i,j].text = "";
        }
    }

    void SetBoardInteractable (bool toggle)
    {
        for (int i = 0; i < 3; i++)
        
        {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }

    public void SetPlayerSideX()
    {
        playerSide = "X";
        AfterSideSelect();
        //selectSidePanel.SetActive(false);
    }

    public void SetPlayerSideY()
    {
        playerSide = "O";
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
    
  
}

   

