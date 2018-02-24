using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// The CrossingController will change and show the text in the Crossingscreen between the games depending of which game will come next.
public class CrossingController : MonoBehaviour
{
    [SerializeField] private Text gamerule;
    [SerializeField] private Text difficulty;
    [SerializeField] private Text life;

    private GameObject mainController;

    private string[] ruleTexts = new string[] {"Swipe left and right and dodge the meteors!","Follow the instructions on the screen!","Find the same memory tiles!",
        "Tilt your smartphone to move the ball into the goal zone!","Press the screen to jump over the obstacles!","Spin the Disc!","Drag the trash into the right containers!" };


    // Use this for initialization
    void Start()
    {
        mainController = GameObject.Find("MainController");

        // Changing of Difficultytext

        int diff = mainController.GetComponent<MainController>().difficulty;
        if (diff < 5)
        {
            difficulty.text = "Difficulty level: 1";
        }
        else if (diff < 10)
        {
            difficulty.text = "Difficulty level: 2";
        }
        else
        {
            difficulty.text = "Difficulty level: 3";
        }

        // Changing of Lifetext

        int lifeCount = mainController.GetComponent<MainController>().life;
        life.text = "You have " + lifeCount + "life(s) left";

        // Changing of Ruletext

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

}
