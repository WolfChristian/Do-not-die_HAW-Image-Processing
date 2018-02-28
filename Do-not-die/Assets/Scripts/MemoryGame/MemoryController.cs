using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// The MemoryController will spawn the memory tiles at random locations and make sure you get the right feedback when tapping on the tiles to finish the game.
public class MemoryController : MonoBehaviour
{


    private bool firstClick = false;
    private bool secondClick = false;
    public List<GameObject> tappedTiles;
    private int points = 0;
    [SerializeField] private GameObject g1, g2, g3, g4, g5, g6; // Prefab references.
    private GameObject main;
    public List<GameObject> spawnMemoryFields;
    private int diff;
    private float timer;
    private float timerstart;
    private GameObject slider;
    public List<Vector3> positionList;
    private GameObject n1, n2, n3, n4, n5, n6; // Usable tiles for script.
    public GameObject[] usableGameTiles;
    private int j = 0;

    public bool FirstClick
    {
        get
        {
            return firstClick;
        }

        set
        {
            firstClick = value;
        }
    }

    public bool SecondClick
    {
        get
        {
            return secondClick;
        }

        set
        {
            secondClick = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        main = GameObject.Find("MainController");
        slider = GameObject.Find("TimeBar");
        usableGameTiles = new GameObject[] { n1, n2, n3, n4, n5, n6 };
        
        // Add prefabs to list
        spawnMemoryFields.Add(g1);
        spawnMemoryFields.Add(g2);
        spawnMemoryFields.Add(g3);
        spawnMemoryFields.Add(g4);
        spawnMemoryFields.Add(g5);
        spawnMemoryFields.Add(g6);

        // Add possible positions to list
        positionList.Add(new Vector3(-3, 0, 0));
        positionList.Add(new Vector3(0, 0, 0));
        positionList.Add(new Vector3(3, 0, 0));
        positionList.Add(new Vector3(-3, -2, 0));
        positionList.Add(new Vector3(0, -2, 0));
        positionList.Add(new Vector3(3, -2, 0));

        // Shuffle list for spawn
        for (int i = 0; i < spawnMemoryFields.Count; i++)
        {
            GameObject temp = spawnMemoryFields[i];
            int randomIndex = UnityEngine.Random.Range(i, spawnMemoryFields.Count);
            spawnMemoryFields[i] = spawnMemoryFields[randomIndex];
            spawnMemoryFields[randomIndex] = temp;
        }

        // Instantiate Prefabs into level, save them into usable tiles
        foreach (GameObject memories in spawnMemoryFields)
        {
            GameObject memoryTile = Instantiate(memories, positionList[j], Quaternion.identity);
            usableGameTiles[j] = memoryTile;
            j++;

        }

         
        // Control difficulty changes
        diff = main.GetComponent<MainController>().difficulty;
        if (diff < 5)
        {
            timerstart = 12f;

        }
        else if (diff < 10)
        {
            timerstart = 9f;

        }
        else
        {
            timerstart = 7f;
        }

        timer = timerstart;
        slider.GetComponent<Slider>().maxValue = timerstart;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        timer = timer - Time.deltaTime;
        slider.GetComponent<Slider>().value = timer;


        // Checks if the second tile was clicked and if the tiles have the same type. When they have the same type, the tiles are deleted, a point is added and the user can click again 
        //When they are not the same, the pictures will vanish and the user can click again
        if (SecondClick == true)
        {
            if (tappedTiles[0].GetComponent<OnClick>().Type == tappedTiles[1].GetComponent<OnClick>().Type)
            {
                foreach (GameObject news in usableGameTiles)
                {
                    news.GetComponent<OnClick>().CanBeClicked = false;
                }


                FirstClick = false;
                SecondClick = false;

                StartCoroutine(RightPair());

            }
            else
            {
                foreach (GameObject news in usableGameTiles)
                {
                    news.GetComponent<OnClick>().CanBeClicked = false;
                }
                FirstClick = false;
                SecondClick = false;
                StartCoroutine(WrongPair());
            }

        }

        // Win and lose conditions
        if (points >= 3)
        {
            main.GetComponent<MainController>().LoadScene();
        }

        if (timer <= 0)
        {
            main.GetComponent<MainController>().Loselife();
        }
    }

    // Subroutine for waiting when wrong pair was found.
    private IEnumerator WrongPair()
    {

        yield return new WaitForSeconds(0.3f);

        tappedTiles[0].GetComponent<OnClick>().CanBeClicked = true;
        tappedTiles[1].GetComponent<OnClick>().CanBeClicked = true;
        tappedTiles[0].transform.GetChild(0).gameObject.SetActive(false);
        tappedTiles[1].transform.GetChild(0).gameObject.SetActive(false);
        tappedTiles.Clear();
        foreach (GameObject news in usableGameTiles)
        {
            news.GetComponent<OnClick>().CanBeClicked = true;
        }

    }

    // Subroutine for waiting when right pair was found.
    private IEnumerator RightPair()
    {
        points++;
        yield return new WaitForSeconds(0.3f);

        tappedTiles[0].SetActive(false);
        tappedTiles[1].SetActive(false);

        tappedTiles.Clear();
        
        foreach (GameObject news in usableGameTiles)
        {
            news.GetComponent<OnClick>().CanBeClicked = true;
        }

    }
}
