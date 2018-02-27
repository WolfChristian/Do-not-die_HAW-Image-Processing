using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DragController : MonoBehaviour
{
    private GameObject Main;
    private GameObject Slider;
    public GameObject item1, item2, item3, item4;
    private float Timer = 100;
    private int diff;
    public int food, recycle=0;
    private  Random rng = new Random();
    public List<Vector2> positions;
    public List<GameObject> items;
    /*Level generation
    *Sets Timer depending on difficulty
    *Spawns trash in random order
    */
    void Start()
    {
        Main = GameObject.Find("MainController");
        Slider = GameObject.Find("TimeBar");
        diff = Main.GetComponent<MainController>().difficulty;
        //Adds fixed positions to the list and shuffles them
        positions.Add(new Vector2(-3,0));
        positions.Add(new Vector2(3, 0));
        positions.Add(new Vector2(1, 0));
        positions.Add(new Vector2(-1, 0));
        Shuffle(positions);

        //Adds selected GameObjects to the list
        items.Add(item1);
        items.Add(item2);
        items.Add(item3);
        items.Add(item4);
        //Spawns trash with random positions
        for (int i = 0; i < positions.Count; i++) {
            Instantiate(items[i], positions[i], Quaternion.identity);
        }

        if (diff < 5) {
            Timer = 8f;
        }
        else if(diff>5&&diff<10)
        {
            Timer = 7f;
        }
        else
        {
            Timer = 6f;

        }
        Slider.GetComponent<Slider>().maxValue = Timer;
    }
    /*
      *Counts down the time and sets the value of the slider.
      *Lose the after the time is over or win the game once food and recycle equal 2.
      */
    void FixedUpdate(){
        Timer = Timer - Time.deltaTime;
        Slider.GetComponent<Slider>().value = Timer;

        if (Timer < 0)
        {
            Main.GetComponent<MainController>().loselife();
        }
        else if (food==2&&recycle==2) {
            Main.GetComponent<MainController>().LoadScene();
        }
    }
    //Lose the game
    public void loseGame()
    {
        Main.GetComponent<MainController>().loselife();
    }
    //Shuffles list randomly
    private void Shuffle(List<Vector2> alpha) {
        for (int i = 0; i < alpha.Count; i++)
        {
            Vector2 temp = alpha[i];
            int randomIndex = Random.Range(i, alpha.Count);
            alpha[i] = alpha[randomIndex];
            alpha[randomIndex] = temp;
        }
    }
}
