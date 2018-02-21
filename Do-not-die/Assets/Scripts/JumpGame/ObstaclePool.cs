using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour {

    public GameObject obstaclePrefab;

    private int obstaclePoolSize = 4;
    private float spawnRate = 0.5f;
    private GameObject[] obstacle;
    private Vector2 objectPoolPosition = new Vector2(10f, 10f);
    private float timeSinceLastSpawned;
    private float spawnYPosition = -2f;
    private int currentObstacle = 0;


	// Use this for initialization
	void Start () {
        obstacle = new GameObject[obstaclePoolSize];
        for (int i = 0; i<obstaclePoolSize; i++)
        {
            obstacle[i] = (GameObject)Instantiate (obstaclePrefab, objectPoolPosition, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        timeSinceLastSpawned += Time.deltaTime;

        if (!(currentObstacle >= obstaclePoolSize))
        {
                if (timeSinceLastSpawned >= spawnRate)
            {
                float randm = Random.Range(8, 14);
                spawnRate = (randm / 10);
                Debug.Log(spawnRate);
                timeSinceLastSpawned = 0;
                obstacle[currentObstacle].transform.position = new Vector2(10, spawnYPosition);
                currentObstacle++;
   
            } 
        }
	}
}
