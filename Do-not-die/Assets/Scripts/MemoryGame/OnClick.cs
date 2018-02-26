using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The OnClick class messages the MemoryController if the connected tile was clicked.
public class OnClick : MonoBehaviour {

    [SerializeField] private int type; 
    private GameObject memoryController;
    private bool canBeClicked = true;

    public int Type
    {
        get
        {
            return type;
        }

        set
        {
            type = value;
        }
    }

    public bool CanBeClicked
    {
        get
        {
            return canBeClicked;
        }

        set
        {
            canBeClicked = value;
        }
    }

    // Use this for initialization
    void Start () {
        memoryController = GameObject.Find("MemoryController");
	}
	
    void OnMouseDown()
    {
        // if the tile is clickable - activate the first click or second click activated in the controller and adds the tile to tapped tiles
        if (CanBeClicked)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            if (memoryController.GetComponent<MemoryController>().FirstClick == false)
            {
                memoryController.GetComponent<MemoryController>().FirstClick = true;
                memoryController.GetComponent<MemoryController>().tappedTiles.Add(this.gameObject);
                CanBeClicked = false;

            }
            else
            {
                memoryController.GetComponent<MemoryController>().tappedTiles.Add(this.gameObject);
                memoryController.GetComponent<MemoryController>().SecondClick = true;
            }
        }
        
        
    }

    
}
