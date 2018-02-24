using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/*
 * Interacts with MainController
 * Spawns level depending on difficulty
 */
public class ButtonController : MonoBehaviour {

    private GameObject Main;
    private GameObject Slider;
    public Text textfield;
    public Canvas canvas;
    public GameObject buttonV1;//Spawnable button 1
    public GameObject buttonV2;//Spawnable button 2
    private GameObject button;
    private float Timer = 100;
    private int diff;
    private bool isAlternative = false;//Indicator for alternative task
    /*Level generation
     *Sets Timer depending on difficulty
     *Spawns one of two possible buttons
     *Sets text in the Textfield
     */
    void Start () {
        Main = GameObject.Find("MainController");
        Slider = GameObject.Find("TimeBar");
        diff = Main.GetComponent<MainController>().difficulty;
        
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
        
        Slider.GetComponent<Slider>().maxValue = Timer;

    }
	 /*
      *Counts down the time and sets the value of the slider.
      *Calls winGame() or loseGame() after the time is over.
      */
	void FixedUpdate () {

        Timer = Timer - Time.deltaTime;
        Slider.GetComponent<Slider>().value = Timer;
        if (Timer < 0 && isAlternative == false)
        {
            winGame();
        }
        else if(Timer<0) {

            loseGame();
        }

    }
    //Calls the next level with the LoadScene() function of the MainController.
    private void winGame() {
        Main.GetComponent<MainController>().LoadScene();
    }
    //Calls the next level with the loselife() function of the MainController.
    private void loseGame() {       
        Main.GetComponent<MainController>().loselife();
    }
}
