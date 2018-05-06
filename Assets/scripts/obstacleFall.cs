using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleFall : MonoBehaviour {

    private float moveUp;
    private float moveDown;
    private int count;
    private Vector3 defaultPos;
    private int stayState = 0; //3 states, 0 = off, 1 = on, 2 = just got off

    // Use this for initialization
    void Start () {
        moveUp = 0.1f;
        moveDown = -0.1f;
        count = 0;
        defaultPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(stayState == 1)
        {
            count++;
            if (count > 100)    //falls after set amount of time
            {
                transform.Translate(0, moveDown, 0);
            }
        }

        if(stayState == 2)
        {
            count++;
            if (count > 200)
            {
                if(transform.position != defaultPos)    //returning back to original position
                {
                    transform.Translate(0, moveUp, 0);
                }

                if(transform.position == defaultPos)    //resetting state once back in original position
                {
                    count = 0;
                    stayState = 0;
                }
            }
            
            //force falling once player leaves
            else
            {
                transform.Translate(0, moveDown, 0);
            }
        }

	}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            stayState = 1;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            stayState = 2;
            count = 0;
        }
    }
}
