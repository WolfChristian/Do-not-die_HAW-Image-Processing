using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject Main;
    float Timerstart = 0f;
    float Timer = 100;
    public GameObject Slider;
    private int score = 0;

    int diff;

    public GameObject startPointPrefap;
    public GameObject endPointPrefap;
    public GameObject movingPointPrefap;
    public GameObject[] startPoint;
    public GameObject[] endPoint;
    public GameObject[] movingPointPoint;

    private Vector2 startSpawnPosition = new Vector2(-5f, -3f);
    private Vector2 endSpawnPosition = new Vector2(5f, -3f);
    private Vector2 movingPointSpawnPosition = new Vector2(-5f, -3f);
    private int spawnNumber = 3;
    private int[] endPointName;
    private Color[] colorList = new Color[4];
    private int count = 0;

    // Use this for initialization
    void Start () {
        //lonnich Stuff
        Main = GameObject.Find("MainController");
        Slider = GameObject.Find("TimeBar");


        diff = Main.GetComponent<MainController>().difficulty;
        //diff = 2;
        if (diff < 5)
        {
            Timerstart = 10f;
        }
        else
        {
            Timerstart = 5f;
        }

        Timer = Timerstart;
        Slider.GetComponent<Slider>().maxValue = Timerstart;
        //mein Stuff
        colorList[0] = Color.blue;
        colorList[1] = Color.green;
        colorList[2] = Color.red;
        colorList[3] = Color.yellow;

        endPointName = new int[spawnNumber];
        int[] listCopy = new int[spawnNumber];
        for (int i = 0; i < spawnNumber; i++)
        {
            endPointName[i] = i;
            listCopy[i] = i;
        }
        for (int i = 0; i < spawnNumber; i++)
        {
            int rnd = Random.Range(0, spawnNumber - 1);
            endPointName[i] = endPointName[rnd];
            endPointName[rnd] = listCopy[i];
            listCopy[rnd] = listCopy[i];
            listCopy[i] = endPointName[i];
        }
        startPoint = new GameObject[spawnNumber];
        for (int i = 0; i < spawnNumber; i++)
        {
            startPoint[endPointName[i]] = (GameObject)Instantiate(startPointPrefap, startSpawnPosition, Quaternion.identity);
            startSpawnPosition = startSpawnPosition + new Vector2(0f, 2.5f);
            startPoint[endPointName[i]].name = "" + endPointName[i];
        }
        endPoint = new GameObject[spawnNumber];
        for (int i = 0; i < spawnNumber; i++)
        {
            endPoint[i] = (GameObject)Instantiate(endPointPrefap, endSpawnPosition, Quaternion.identity);
            endSpawnPosition = endSpawnPosition + new Vector2(0f, 2.5f);
            endPoint[i].name = "" + i;
        }

        movingPointPoint = new GameObject[spawnNumber];
        for (int i = 0; i < spawnNumber; i++)
        {
            movingPointPoint[endPointName[i]] = (GameObject)Instantiate(movingPointPrefap, movingPointSpawnPosition, Quaternion.identity);
            movingPointSpawnPosition = movingPointSpawnPosition + new Vector2(0f, 2.5f);
            movingPointPoint[endPointName[i]].name = "" + endPointName[i];
        }
    }
    public Color getColor(int name)
    {
        return colorList[name];
    }
    public Vector2 getStartVector(int name)
    {
        return startPoint[name].transform.position;
    }
    public Vector2 getEndVector(int name)
    {
        return endPoint[name].transform.position;
    }
    public Vector2 getMovingPointVector(int name)
    {
        return movingPointPoint[name].transform.position;
    }
    public string getName(int name)
    {
        return endPoint[name].name;
    }
    public void countConnections()
    {
        count++;
        if (count == spawnNumber)
        {
            Main.GetComponent<MainController>().LoadScene();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Timer = Timer - Time.deltaTime;
        Slider.GetComponent<Slider>().value = Timer;

        if (Timer < 0)
        {
            Main.GetComponent<MainController>().loselife();
        }
    }
}
