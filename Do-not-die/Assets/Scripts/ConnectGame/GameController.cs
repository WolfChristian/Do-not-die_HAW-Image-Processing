using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {


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


	// Use this for initialization
	void Start () {
        startPoint = new GameObject[spawnNumber];
        for (int i = 0; i < spawnNumber; i++)
        {
            startPoint[i] = (GameObject)Instantiate(startPointPrefap, startSpawnPosition, Quaternion.identity);
            startSpawnPosition = startSpawnPosition + new Vector2(0f, 2.5f);
            startPoint[i].name = "StartPoint" + i;
        }

        endPoint = new GameObject[spawnNumber];
        for (int i = 0; i < spawnNumber; i++)
        {
            endPoint[i] = (GameObject)Instantiate(endPointPrefap, endSpawnPosition, Quaternion.identity);
            endSpawnPosition = endSpawnPosition + new Vector2(0f, 2.5f);
            endPoint[i].name = "EndPoint" + i;
        }

        movingPointPoint = new GameObject[spawnNumber];
        for (int i = 0; i < spawnNumber; i++)
        {
            movingPointPoint[i] = (GameObject)Instantiate(movingPointPrefap, movingPointSpawnPosition, Quaternion.identity);
            movingPointSpawnPosition = movingPointSpawnPosition + new Vector2(0f, 2.5f);
            movingPointPoint[i].name = "" + i;
        }
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
    // Update is called once per frame
    void Update () {
		
	}
}
