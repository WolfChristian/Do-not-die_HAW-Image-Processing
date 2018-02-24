using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectThePoints : MonoBehaviour {

    public GameObject gameObject1;
    public GameObject gameObject2;


    private LineRenderer line;
	// Use this for initialization
	void Start () {
        line = this.gameObject.AddComponent<LineRenderer>();
        line.startWidth = 0.5f;
        line.endWidth = 0.5f;
        line.SetVertexCount(2);
	}
	// Update is called once per frame
	void FixedUpdate () {
		if(gameObject1 != null && gameObject2 != null)
        {
            line.SetPosition(0, gameObject1.transform.position);
            line.SetPosition(1, gameObject2.transform.position);
        }
	}
}
