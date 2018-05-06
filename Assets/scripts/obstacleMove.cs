using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleMove : MonoBehaviour {

    private float movef;
    private float moveb;
    private int count;

	// Use this for initialization
	void Start () {
        movef = 0.08f;
        moveb = -0.08f;
	}
	
	// Update is called once per frame
	void Update () {

        //handles back and forth movement
        if (count < 100)
        {
            transform.Translate(movef, 0, 0);
            count++;
        }
        
        if(count >= 100)
        {
            transform.Translate(moveb, 0, 0);
            count++;
        }

        if(count >= 200)
        {
            count = 0;
        }
    }
}
