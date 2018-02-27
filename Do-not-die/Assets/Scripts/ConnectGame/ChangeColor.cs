using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private int nameInInt;
    private GameObject Controller;

    void Start()
    {
        nameInInt = System.Convert.ToInt32(this.gameObject.name);
        Controller = GameObject.Find("GameController");
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Controller.GetComponent<GameController>().getColor(nameInInt); ;
    }

}
