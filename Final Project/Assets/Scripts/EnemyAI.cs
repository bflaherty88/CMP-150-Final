using UnityEngine;
using System.Collections;
using System;

public class EnemyAI : Character
{
 
    public CharacterController controller;

    protected bool awake, jump;
    protected Vector3 moveVector;
    protected float moveSpeed;

    GameObject[] players;

    // Use this for initialization
    void Start()
    {
        if (controller == null)
            controller = gameObject.GetComponent<CharacterController>();
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            if (players[0].transform.position.x > transform.position.x)
                moveSpeed += acceleration;
            else
                moveSpeed -= acceleration;
            if (jump)
            {
                moveVector += Vector3.up * 40;
                jump = false;
            }
        }

        moveVector += Vector3.down * gravity;
        if (moveSpeed > maxSpeed)
            moveSpeed = maxSpeed;
        else if (moveSpeed < -maxSpeed)
            moveSpeed = -maxSpeed;

        moveVector.x = moveSpeed;


        moveVector += knockback;
        knockback = Vector3.zero;

        controller.Move(moveVector * Time.deltaTime);
        if (health <= 0)
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Jump")
            jump = true;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Jump")
            jump = false;
    }

}