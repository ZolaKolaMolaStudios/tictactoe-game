using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HardAI : MonoBehaviour
{    
    //Serialize gridspaces
    public Text[] gridButtons;
    int Score;
    String AISide,activeSide;
    
    void Awake()
    {
      
    }
    
    void Update()
    {
    
    }
    
    int Minimax(Text gridSpace, int depth, String AIPlayer)
    {
        return Score;
    }
    
    void setMove()
    {
    
    }
    
    void CheckEmptyCells()
    {
    
    }
    
    int CheckWinCondition()   // return score if won
    {
      for(int i = 0; i < 3; i++)
      {   
          for(int j = 0; j < 3; j++)
          {     //Horizontal win    
                if(i == 0)
                {
                    if((gridButtons[i + 3*j] == gridButtons[i + 3*j + 1]) &&(gridButtons[i + 3*j + 1] == gridButtons[i + 3*j + 2])) // Take with a grain of salt
                    {
                        EndCondition();
                    }
                }
                //Vertical win
                
                else if((i + 3j) <= 9)
                {
                    if((gridButtons[i + 3*j] == gridButtons[i + 3*j + 3]) &&(gridButtons[i + 3*j + 3] == gridButtons[i + 3*j + 6])) //Review Stat
                    {
                        EndCondition();        
                    }
                }
                
               //Diagonal win
               else if(gridButtons[0] == gridButtons[4] && gridButtons[4] == gridButtons[8])
               {
                    EndCondition();
               }
               else if(gridButtons[2] == gridButtons[4] && gridButtons[4] == gridButtons[6])
               {
                    EndCondition();
               }
          }   
      }
    }
    
    void EndCondition()
    {
        if(AISide != activeSide)
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
}
