using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    private GameObject Main;
    private float Timerstart = 0f;
    private float Timer = 100;
    private GameObject Slider;
    private int score = 0;
    private int diff;

    [SerializeField] private GameObject startPointPrefap;
    [SerializeField] private GameObject endPointPrefap;
    [SerializeField] private GameObject movingPointPrefap;
    private GameObject[] startPoint;
    private GameObject[] endPoint;
    private GameObject[] movingPointPoint;
    private Vector2 startSpawnPosition = new Vector2(-5f, -3f);
    private Vector2 endSpawnPosition = new Vector2(5f, -3f);
    private int spawnNumber = 3;
    private int[] randomizedList; //assign a random position to the points
    private Color[] colorList = new Color[4];
    private int count = 0;


    void Start()
    {
        Main = GameObject.Find("MainController");
        Slider = GameObject.Find("TimeBar");
        diff = Main.GetComponent<MainController>().difficulty;
        //changes the max timer and the number of points depending on the difficulty
        if (diff < 5)
        {
            Timerstart = 8f;
            spawnNumber = 2;
        }
        else if (diff > 10)
        {
            Timerstart = 4f;
        }
        else
        {
            Timerstart = 8f;
            spawnNumber = 3;
        }
        Timer = Timerstart;
        Slider.GetComponent<Slider>().maxValue = Timerstart;

        //defines the possible colors
        colorList[0] = Color.blue;
        colorList[1] = Color.green;
        colorList[2] = Color.red;
        colorList[3] = Color.yellow;

        //randomization of randomizedList
        randomizedList = new int[spawnNumber];
        int[] listCopy = new int[spawnNumber];
        for (int i = 0; i < spawnNumber; i++)
        {
            randomizedList[i] = i;
            listCopy[i] = i;
        }
        for (int i = 0; i < spawnNumber; i++)
        {
            int rnd = Random.Range(0, spawnNumber - 1);
            randomizedList[i] = randomizedList[rnd];
            randomizedList[rnd] = listCopy[i];
            listCopy[rnd] = listCopy[i];
            listCopy[i] = randomizedList[i];
        }
        // end of randomization

        startPoint = new GameObject[spawnNumber];
        for (int i = 0; i < spawnNumber; i++) //instantiate, position, name the startpoints
        {
            startPoint[randomizedList[i]] = (GameObject)Instantiate(startPointPrefap, startSpawnPosition, Quaternion.identity);
            startSpawnPosition = startSpawnPosition + new Vector2(0f, 2.5f);
            startPoint[randomizedList[i]].name = "" + randomizedList[i];
        }
        movingPointPoint = new GameObject[spawnNumber];
        for (int i = 0; i < spawnNumber; i++) //instantiate, position, name the associated movable points
        {
            movingPointPoint[randomizedList[i]] = (GameObject)Instantiate(movingPointPrefap, startSpawnPosition, Quaternion.identity);
            startSpawnPosition = startSpawnPosition + new Vector2(0f, 0f);
            movingPointPoint[randomizedList[i]].name = "" + randomizedList[i];
        }

        endPoint = new GameObject[spawnNumber];
        for (int i = 0; i < spawnNumber; i++) //instantiate, position, name the endpoints
        {
            endPoint[i] = (GameObject)Instantiate(endPointPrefap, endSpawnPosition, Quaternion.identity);
            endSpawnPosition = endSpawnPosition + new Vector2(0f, 2.5f);
            endPoint[i].name = "" + i;
        }
    }
    public Color getColor(int name) //returns the color for the corresponding name, used in ChangeColor
    {
        return colorList[name];
    }
    public Vector2 getStartVector(int name) //returns the position for the corresponding STARTPOINT for the movable points, used in MoveByTouch
    {
        return startPoint[name].transform.position;
    }
    public Vector2 getEndVector(int name) //returns the position for the corresponding ENDPOINT for the movable points, used in MoveByTouch
    {
        return endPoint[name].transform.position;
    }
    public Vector2 getMovingPointVector(int name) //returns the position of the MOVABLE POINT, used in MoveByTouch
    {
        return movingPointPoint[name].transform.position;
    }
    public string getName(int name) // assigns the end point to the movable point
    {
        return endPoint[name].name;
    }
    public void countConnections() //is called after each successful connection
    {
        count++;
        if (count == spawnNumber) //win condition
        {
            Main.GetComponent<MainController>().LoadScene();
        }
    }
    void FixedUpdate() //takes care of the timer and the lose condition
    {
        Timer = Timer - Time.deltaTime;
        Slider.GetComponent<Slider>().value = Timer;

        if (Timer < 0) //lose condition
        {
            Main.GetComponent<MainController>().Loselife();
        }
    }
}
