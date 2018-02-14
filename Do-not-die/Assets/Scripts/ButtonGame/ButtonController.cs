using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonController : MonoBehaviour {

    public GameObject Main;
    public Text textfield;
    public Canvas canvas;
    public GameObject buttonV1;//Spawnable button 1
    public GameObject buttonV2;//Spawnable button 2
    private GameObject button;
    float Timer = 100;
    int diff;
    bool isAlternative = false;//Indicator for alternative task

    void Start () {
        Main = GameObject.Find("MainController");

        //diff = Main.GetComponent<MainController>().difficulty;
        diff = 1;
        if (diff < 5)
        {
            Timer = 5f;
            button =Instantiate(buttonV1, new Vector3(0, 0, 0), Quaternion.identity);
            button.transform.SetParent(canvas.transform,false);
            textfield.text = "Do not press the Red Button";
        }
        else
        {
            Timer = 3f;
            //%30 percent chance to spawn a alternative task
            if (Random.value > 0.3)
            {
                button = Instantiate(buttonV2, new Vector3(0, 0, 0), Quaternion.identity);
                button.transform.SetParent(canvas.transform, false);
                textfield.text = "Do press the Red Button";
                isAlternative = true;
            }
            else
            {
                button = Instantiate(buttonV1, new Vector3(0, 0, 0), Quaternion.identity);
                button.transform.SetParent(canvas.transform, false);
                textfield.text = "Do not press the Red Button";
            }
        }

    }
	
	void FixedUpdate () {

        Timer = Timer - Time.deltaTime;

        if (Timer < 0 && isAlternative == false)
        {

            winGame();
        }
        else if(Timer<0) {

            loseGame();
        }

    }
    //Wins game 
    public void winGame() {
        Main.GetComponent<MainController>().LoadScene();
    }
    //Loses Game
    public void loseGame() {
       
        Main.GetComponent<MainController>().loselife();

    }
}
