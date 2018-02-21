using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DragController : MonoBehaviour
{
    public GameObject Main;
    public GameObject Slider;
    public GameObject item1, item2, item3, item4;
    float Timer = 100;
    int diff;
    public int food, recycle=0;
    private  Random rng = new Random();
    public List<Vector2> positions;
    public List<GameObject> items;
    // Use this for initialization
    void Start()
    {
        Main = GameObject.Find("MainController");
        Slider = GameObject.Find("TimeBar");
        diff = Main.GetComponent<MainController>().difficulty;
        positions.Add(new Vector2(-3,0));
        positions.Add(new Vector2(3, 0));
        positions.Add(new Vector2(1, 0));
        positions.Add(new Vector2(-1, 0));
        Shuffle(positions);

        items.Add(item1);
        items.Add(item2);
        items.Add(item3);
        items.Add(item4);

        for (int i = 0; i < positions.Count; i++) {
            Instantiate(items[i], positions[i], Quaternion.identity);
        }



        if (diff < 5) {
            Timer = 8f;

        }
        else
        {
            Timer = 7f;
        }

        Slider.GetComponent<Slider>().maxValue = Timer;
    }

    void FixedUpdate()
    {
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
    public void loseGame()
    {

        Main.GetComponent<MainController>().loselife();

    }
    public void spawnObject() {
        Instantiate(item1, new Vector3(0, 0, 0), Quaternion.identity);
    }
    public void Shuffle(List<Vector2> alpha) {
        for (int i = 0; i < alpha.Count; i++)
        {
            Vector2 temp = alpha[i];
            int randomIndex = Random.Range(i, alpha.Count);
            alpha[i] = alpha[randomIndex];
            alpha[randomIndex] = temp;
        }
    }
}
