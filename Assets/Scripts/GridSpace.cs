using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{   
    public Button button;
    public Text buttonText;

    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGameControllerReference (GameController controller)
    {
        gameController = controller;
    }

    public void SetSpace()
    {   
        if(gameController.returnTurn())
        {
            buttonText.text = gameController.GetPlayerSide();
            button.interactable = false;
            gameController.EndTurn();
        }
    }
}
