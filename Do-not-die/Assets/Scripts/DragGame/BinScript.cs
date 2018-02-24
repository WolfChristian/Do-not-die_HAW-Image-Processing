using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinScript : MonoBehaviour {
    //Sets either Food or Recyclebnin
    public int mode;
    public GameObject dragController;
	
    /*If an object enters the bin depending on its tag and the 
     *mode of the bin either add one the Food/Recycle-counter or lose the game.  
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (mode) {
        //Mode for foodbin
        case 1:
            if (collision.tag == "Food") {
                    dragController.GetComponent<DragController>().food++;
            }
            else if(collision.tag == "Recycle"){
                    dragController.GetComponent<DragController>().loseGame();
                }
                break;
        //Mode for recyclebin
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
