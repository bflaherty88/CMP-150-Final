using UnityEngine;
using System.Collections;
using System;

public class BrandonsEnemyAI : Character
{
 
    public CharacterController controller;
    public float alertClose = 10, alertFar = 20, attackDistance = 2;

    protected bool awake, asleep, jump, attacking;
    protected Vector3 moveVector;
    protected float moveSpeed, knockbackSpeed, jumpBoost;

    GameObject[] players;
    protected GameObject player;

    // Use this for initialization
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        if (controller == null)
            controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    protected void Update()
    {
        if ((int)Time.time % 5 == 0)
            players = GameObject.FindGameObjectsWithTag("Player");

        asleep = true;
        attacking = false;

        foreach (GameObject player in players)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (!awake && distance < alertClose)
            {
                awake = true;
                this.player = player;
            }

            if (awake && distance < alertFar)
                asleep = false;

            if (!attacking && awake && Mathf.Abs(transform.position.x - player.transform.position.x) < attackDistance)
                attacking = true;
        }

        awake = awake && !asleep;

        knockbackSpeed += knockback.x;

            if (controller.isGrounded)
            {
                moveVector.y = 0;
                if (awake && !attacking)
                {
                    if (player.transform.position.x > transform.position.x)
                    {
                        moveSpeed += acceleration;
                        transform.LookAt(transform.position + Vector3.right);
                    }
                    else
                    {
                        moveSpeed -= acceleration;
                        transform.LookAt(transform.position - Vector3.right);
                    }
                }

                if (jump)
                {
                    moveVector.y += jumpHeight;
                    if (moveSpeed != 0)
                        jumpBoost += jumpHeight / 5 * Mathf.Sign(moveSpeed);
                    jump = false;
                }

                if (moveSpeed > drag || moveSpeed < -drag)
                    moveSpeed -= moveSpeed * drag;
                else if (moveSpeed != 0)
                    moveSpeed = 0;

                if (knockbackSpeed > drag || knockbackSpeed < -drag)
                    knockbackSpeed -= knockbackSpeed * drag;
                else if (knockbackSpeed != 0)
                    knockbackSpeed = 0;

                if (jumpBoost > drag || jumpBoost < -drag)
                    jumpBoost -= jumpBoost * drag;
                else if (jumpBoost != 0)
                    jumpBoost = 0;
            }

            moveVector.y += knockback.y;
            knockback = Vector3.zero;

            moveVector += Vector3.down * gravity * Time.deltaTime;
            if (moveVector.y < terminalVelocity)
                moveVector.y = terminalVelocity;

            if (moveSpeed > maxSpeed)
                moveSpeed = maxSpeed;
            else if (moveSpeed < -maxSpeed)
                moveSpeed = -maxSpeed;

            moveVector.x = moveSpeed + knockbackSpeed + jumpBoost;

            controller.Move(moveVector * Time.deltaTime);
            if (attacking && Time.timeScale != 0)
                Attack();

        if (health <= 0)
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Jump")
        {
            jump = true;
        }
    }

    protected virtual void Attack()
    {
        Debug.Log("Attack!");
    }
}