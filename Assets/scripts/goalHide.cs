using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalHide : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("player").GetComponent<player>().score < 5)
        {
            gameObject.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
	}
}
