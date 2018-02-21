using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour {

    public int type;
    public GameObject memoryController;
    public bool canBeClicked = true;
	// Use this for initialization
	void Start () {
        memoryController = GameObject.Find("MemoryController");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        if (canBeClicked)
        {
            Debug.Log("CLICKED");
            this.transform.GetChild(0).gameObject.SetActive(true);
            if (memoryController.GetComponent<MemoryController>().firstClick == false)
            {
                memoryController.GetComponent<MemoryController>().firstClick = true;
                memoryController.GetComponent<MemoryController>().clickedFields.Add(this.gameObject);
                canBeClicked = false;

            }
            else
            {
                memoryController.GetComponent<MemoryController>().clickedFields.Add(this.gameObject);
                memoryController.GetComponent<MemoryController>().secondClick = true;
            }
        }
        
        
    }

    
}
