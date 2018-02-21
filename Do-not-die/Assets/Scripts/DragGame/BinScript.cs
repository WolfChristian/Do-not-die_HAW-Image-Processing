using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinScript : MonoBehaviour {
    //Sets either Food or Recyclebnin
    public int mode;
    public GameObject dragController;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (mode) {
            case 1:
            if (collision.tag == "Food") {
                    dragController.GetComponent<DragController>().food++;
            }
            else if(collision.tag == "Recycle"){
                    dragController.GetComponent<DragController>().loseGame();
                }
                break;
        case 2:
                if (collision.tag == "Recycle")
                {
                    dragController.GetComponent<DragController>().recycle++;
                }
                else if (collision.tag == "Food")
                {
                    dragController.GetComponent<DragController>().loseGame();
                }
                break;
        }
        Destroy(collision.gameObject);
    }
    
}
