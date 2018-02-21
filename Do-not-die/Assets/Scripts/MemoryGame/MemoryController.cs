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
    public List<GameObject> memoryFields;
    public int diff;
    public float timer;
    public float timerstart;
    public GameObject slider;
    public List<Vector3> positionList;
    public GameObject n1, n2, n3, n4, n5, n6;
    public GameObject[] newg;
    public int j = 0;

    // Use this for initialization
    void Start () {
        main = GameObject.Find("MainController");
        slider = GameObject.Find("TimeBar");
        newg = new GameObject[] { n1, n2, n3, n4, n5, n6 };
        memoryFields.Add(g1);
        memoryFields.Add(g2);
        memoryFields.Add(g3);
        memoryFields.Add(g4);
        memoryFields.Add(g5);
        memoryFields.Add(g6);

        positionList.Add(new Vector3(-3, 0, 0));
        positionList.Add(new Vector3(0, 0, 0));
        positionList.Add(new Vector3(3, 0, 0));
        positionList.Add(new Vector3(-3, -2, 0));
        positionList.Add(new Vector3(0, -2, 0));
        positionList.Add(new Vector3(3, -2, 0));

        for (int i = 0; i <memoryFields.Count; i++)
        {
            GameObject temp = memoryFields[i];
            int randomIndex = UnityEngine.Random.Range(i, memoryFields.Count);
            memoryFields[i] = memoryFields[randomIndex];
            memoryFields[randomIndex] = temp;
        }

        foreach (GameObject memories in memoryFields){
            GameObject memoryTile = Instantiate(memories, positionList[j],Quaternion.identity);
            newg[j] = memoryTile;
            j++;

        }



        diff = main.GetComponent<MainController>().difficulty;
        if (diff < 5)
        {
            timerstart = 10f;

        }
        else
        {
            timerstart = 8f;

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
                foreach(GameObject news in newg){
                    news.GetComponent<OnClick>().canBeClicked = false;
                }
                
                
                firstClick = false;
                secondClick = false;

                StartCoroutine(RightPair());

            }
            else
            {
                foreach (GameObject news in newg)
                {
                    news.GetComponent<OnClick>().canBeClicked = false;
                }
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

        yield return new WaitForSeconds(0.3f);

        clickedFields[0].GetComponent<OnClick>().canBeClicked = true;
        clickedFields[1].GetComponent<OnClick>().canBeClicked = true;
        clickedFields[0].transform.GetChild(0).gameObject.SetActive(false);
        clickedFields[1].transform.GetChild(0).gameObject.SetActive(false);

        

        clickedFields.Clear();
        foreach (GameObject news in newg)
        {
            news.GetComponent<OnClick>().canBeClicked = true;
        }

    }

    private IEnumerator RightPair()
    {
        yield return new WaitForSeconds(0.3f);

        Debug.Log("SUCCESS");
        clickedFields[0].SetActive(false);
        clickedFields[1].SetActive(false);
        
        clickedFields.Clear();
        right++;
        foreach (GameObject news in newg)
        {
            news.GetComponent<OnClick>().canBeClicked = true;
        }

    }
}
