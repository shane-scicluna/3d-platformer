using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupMove : MonoBehaviour
{

    private float moveUp;
    private float moveDown;
    private int count;

    // Use this for initialization
    void Start()
    {
        moveUp = 0.006f;
        moveDown = -0.006f;
    }

    // Update is called once per frame
    void Update()
    {

        //handles up and down movement
        if (count < 30)
        {
            transform.Translate(0, moveUp, 0);
            count++;
        }

        if (count >= 30)
        {
            transform.Translate(0, moveDown, 0);
            count++;
        }

        if (count >= 60)
        {
            count = 0;
        }
    }
}
