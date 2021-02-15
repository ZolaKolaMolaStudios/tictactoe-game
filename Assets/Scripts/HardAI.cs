using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HardAI : MonoBehaviour
{    
    //Serialize gridspaces
    public Text[] gridButtons;
    int Score;
    String AISide;
    
    void Awake()
    {
      
    }
    
    void Update()
    {
    
    }
    
    void Minimax()
    {
    
    }
    
    void WinCondition()
    {
      for(int i = 0; i < 3; i++)
      {   
          for(int j = 0; j < 3; j++)
          {
              if((gridButtons[i + 3*j] == gridButtons[i + 3*j + 1]) &&(gridButtons[i + 3*j + 1] == gridButtons[i + 3*j + 2])) // Take with a grain of salt
          }
             
      }
    }
    
    void GetAiSide()
    {
        //Code getting Ai side here
    }
}
