using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonController : MonoBehaviour {

    public GameObject Main;
    public Text textfield;
    public GameObject buttonV1;
    public GameObject buttonV2;
    float Timer = 100;
    int diff;

    void Start () {
        Main = GameObject.Find("MainController");

        //diff = Main.GetComponent<MainController>().difficulty;
        diff = 1;
        if (diff < 5)
        {
            Timer = 5f;

            Instantiate(buttonV1, new Vector3(0, 0, 0), Quaternion.identity);
            textfield.text = "Do not press the Red Button";
        }
        else
        {
            Timer = 3f;
            //%30 percent chance
            if (Random.value > 0.3)
            {
                Instantiate(buttonV2, new Vector3(0, 0, 0), Quaternion.identity);
                textfield.text = "Do press the Red Button";
            }
            else
            {
                Instantiate(buttonV1, new Vector3(0, 0, 0), Quaternion.identity);
                textfield.text = "Do not press the Red Button";
            }
        }

    }
	
	void FixedUpdate () {

        Timer = Timer - Time.deltaTime;

        if (Timer < 0)
        {
            Main.GetComponent<MainController>().LoadScene();
        }

    }
}
