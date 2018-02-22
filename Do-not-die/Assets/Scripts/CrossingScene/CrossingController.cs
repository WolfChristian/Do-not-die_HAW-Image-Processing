using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossingController : MonoBehaviour {
    public Text gamerule;
    public Text difficulty;
    public Text life;

    public GameObject mainController;

    public string[] ruleTexts = new string[] {"Wische nach links und rechts und weiche den Meteoriten aus!","Befolge den Anweisungen auf dem Bildschirm!","Finde die gleichen Memory-Teile!",
        "Neige dein Smartphone, um die Kugel ins Ziel zu befördern!","Drücke auf den Bildschirm, um über die Hindernisse zu springen!","Drehe die Fläche fünf mal!","Ziehe den Müll in die richtigen Tonnen!" };


	// Use this for initialization
	void Start () {
        mainController = GameObject.Find("MainController");
        
        //Schwierigkeitstext

        int diff = mainController.GetComponent<MainController>().difficulty;
        if(diff < 5)
        {
            difficulty.text = "Schwierigkeitsstufe: 1";
        }
        else if(diff < 10)
        {
            difficulty.text = "Schwierigkeitsstufe: 2";
        }
        else
        {
            difficulty.text = "Schwierigkeitsstufe: 3";
        }

        // Lebenstext

        int lifeCount = mainController.GetComponent<MainController>().life;
        life.text = "Du hast noch " + lifeCount + " Leben";

        //Regeltext

        int nextLevel = mainController.GetComponent<MainController>().rand;
        switch (nextLevel)
        {
            case 3:
                gamerule.text = ruleTexts[0];
                break;
            case 4:
                gamerule.text = ruleTexts[1];
                break;
            case 5:
                gamerule.text = ruleTexts[2];
                break;
            case 6:
                gamerule.text = ruleTexts[3];
                break;
            case 7:
                gamerule.text = ruleTexts[4];
                break;
            case 8:
                gamerule.text = ruleTexts[5];
                break;
            case 9:
                gamerule.text = ruleTexts[6];
                break;
        }



        

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
