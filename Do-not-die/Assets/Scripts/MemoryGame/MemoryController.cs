using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryController : MonoBehaviour {


    public bool firstClick = false;
    public bool secondClick = false;
    public List<GameObject> clickedFields;
    public int right = 0;
    public GameObject g1, g2, g3, g4, g5, g6;
    private GameObject main;
    public int diff;
    public float timer;
    public float timerstart;
    public GameObject slider;

    // Use this for initialization
    void Start () {
        main = GameObject.Find("MainController");
        slider = GameObject.Find("TimeBar");

        diff = main.GetComponent<MainController>().difficulty;
        if (diff < 5)
        {
            timerstart = 8f;

        }
        else
        {
            timerstart = 5f;

        }

        timer = timerstart;
        slider.GetComponent<Slider>().maxValue = timerstart;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        timer = timer - Time.deltaTime;
        slider.GetComponent<Slider>().value = timer;

        if (secondClick == true)
        {
            if (clickedFields[0].GetComponent<OnClick>().type == clickedFields[1].GetComponent<OnClick>().type)
            {
                g1.GetComponent<OnClick>().canBeClicked = false;
                g2.GetComponent<OnClick>().canBeClicked = false;
                g3.GetComponent<OnClick>().canBeClicked = false;
                g4.GetComponent<OnClick>().canBeClicked = false;
                g5.GetComponent<OnClick>().canBeClicked = false;
                g6.GetComponent<OnClick>().canBeClicked = false;
                firstClick = false;
                secondClick = false;

                StartCoroutine(RightPair());

            }
            else
            {
                g1.GetComponent<OnClick>().canBeClicked = false;
                g2.GetComponent<OnClick>().canBeClicked = false;
                g3.GetComponent<OnClick>().canBeClicked = false;
                g4.GetComponent<OnClick>().canBeClicked = false;
                g5.GetComponent<OnClick>().canBeClicked = false;
                g6.GetComponent<OnClick>().canBeClicked = false;
                firstClick = false;
                secondClick = false;
                StartCoroutine(WrongPair());
            }

        }

        if(right >= 3)
        {
            main.GetComponent<MainController>().LoadScene();
        }

        if(timer <= 0)
        {
            main.GetComponent<MainController>().loselife();
        }
	}

    private IEnumerator WrongPair()
    {

        yield return new WaitForSeconds(0.5f);

        clickedFields[0].GetComponent<OnClick>().canBeClicked = true;
        clickedFields[1].GetComponent<OnClick>().canBeClicked = true;
        clickedFields[0].transform.GetChild(0).gameObject.SetActive(false);
        clickedFields[1].transform.GetChild(0).gameObject.SetActive(false);

        

        clickedFields.Clear();
        g1.GetComponent<OnClick>().canBeClicked = true;
        g2.GetComponent<OnClick>().canBeClicked = true;
        g3.GetComponent<OnClick>().canBeClicked = true;
        g4.GetComponent<OnClick>().canBeClicked = true;
        g5.GetComponent<OnClick>().canBeClicked = true;
        g6.GetComponent<OnClick>().canBeClicked = true;

    }

    private IEnumerator RightPair()
    {
        yield return new WaitForSeconds(0.5f);

        Debug.Log("SUCCESS");
        clickedFields[0].SetActive(false);
        clickedFields[1].SetActive(false);
        
        clickedFields.Clear();
        right++;
        g1.GetComponent<OnClick>().canBeClicked = true;
        g2.GetComponent<OnClick>().canBeClicked = true;
        g3.GetComponent<OnClick>().canBeClicked = true;
        g4.GetComponent<OnClick>().canBeClicked = true;
        g5.GetComponent<OnClick>().canBeClicked = true;
        g6.GetComponent<OnClick>().canBeClicked = true;

    }
}
