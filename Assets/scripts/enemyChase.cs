using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyChase : MonoBehaviour
{
    public Transform player;
    public Animator anim;
    public float walkingDistance = 10.0f;    //how close player must be to start chasing
    private Vector3 defaultPos;
    private Quaternion defaultRot;

    void Start()
    {
        anim = GetComponent<Animator>();
        defaultPos = transform.position;
        defaultRot = transform.rotation;
    }

    void Update()
    {
        transform.LookAt(player);   //make sure to look at the player at all times
        float distance = Vector3.Distance(transform.position, player.position); //distance from player
        //player close enough to chase
        if (distance < walkingDistance)
        {
            anim.SetBool("isChasing", true);    //setting flag to start animation
            transform.position += transform.forward * 4 * Time.deltaTime;
        }

        //is not chasing
        else
        {
            anim.SetBool("isChasing", false);
        }
    }

    //hitting player
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            anim.SetBool("isChasing", false);
            transform.position = defaultPos;
            transform.rotation = defaultRot;
        }

        //falling to death
        if(col.gameObject.name == "deathZone")
        {
            anim.SetBool("isChasing", false);
            transform.position = defaultPos;
            transform.rotation = defaultRot;
        }
    }
}
