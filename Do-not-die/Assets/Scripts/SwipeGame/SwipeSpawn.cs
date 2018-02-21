using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeSpawn : MonoBehaviour {

    public GameObject spawnObject;
    private float timer;
    public float timerStart;
    private int diff;
    public GameObject main;
    // Use this for initialization
    void Start () {
        
        main = GameObject.Find("MainController");
        diff = main.GetComponent<MainController>().difficulty;

        if (diff < 5)
        {
            timerStart = 1f;

        }
        else if(diff < 10)
        {
            timerStart = 0.5f;

        }
        else
        {
            timerStart = 0.5f;
            this.gameObject.transform.localScale += new Vector3(0.1F, 0, 0);
        }
        timer = timerStart;



    }

    // Update is called once per frame
    void FixedUpdate () {
        timer = timer - Time.deltaTime;

        if(timer <= 0)
        {
            timer = timerStart;

            GameObject clone = Instantiate(spawnObject, new Vector3(Random.Range(-3,4),4,0), Quaternion.identity);
            
        }


	}
}
