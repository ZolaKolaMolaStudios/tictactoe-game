using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSelect : MonoBehaviour
{   
    public GameObject menuPanel;
    public Animator menuPanelAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AfterGamemodeSelect()
    {   
        menuPanelAnimator.SetTrigger("gameModeSelected");
        Invoke("nullFunc",0.7f);
        //Debug.Log("Function works !! You now have different problems");
    }

    void nullFunc(){ menuPanel.SetActive(false); }   // For Invoke method..........    God works in mysterious ways
}
