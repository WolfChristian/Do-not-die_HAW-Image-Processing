using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {
    private GameObject Main;
    [SerializeField] private int mode;
    //Searches for the MainController
    void Start () {
        Main = GameObject.Find("MainController");
    }
    //Wins or Loses game if you push the button 
    void OnMouseDown()
    {
        switch (mode)
        {
            case 1:
                Main.GetComponent<MainController>().LoadScene();
                
                break;
            case 2:
                Main.GetComponent<MainController>().Loselife();
                
                break;

        }
    }
    
}
