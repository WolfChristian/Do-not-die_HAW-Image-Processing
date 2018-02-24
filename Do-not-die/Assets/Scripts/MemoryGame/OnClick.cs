using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The OnClick class messages the MemoryController if the connected tile was clicked.
public class OnClick : MonoBehaviour {

    public int type; 
    private GameObject memoryController;
    public bool canBeClicked = true;
	
    // Use this for initialization
	void Start () {
        memoryController = GameObject.Find("MemoryController");
	}
	
    void OnMouseDown()
    {
        // if the tile is clickable - activate the first click or second click activated in the controller and adds the tile to tapped tiles
        if (canBeClicked)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            if (memoryController.GetComponent<MemoryController>().firstClick == false)
            {
                memoryController.GetComponent<MemoryController>().firstClick = true;
                memoryController.GetComponent<MemoryController>().tappedTiles.Add(this.gameObject);
                canBeClicked = false;

            }
            else
            {
                memoryController.GetComponent<MemoryController>().tappedTiles.Add(this.gameObject);
                memoryController.GetComponent<MemoryController>().secondClick = true;
            }
        }
        
        
    }

    
}
