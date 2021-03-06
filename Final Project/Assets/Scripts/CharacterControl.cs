using UnityEngine;
using System.Collections;

public class CharacterControl : Character {

    CharacterController controller;
    Vector3 moveVec;
    public CustomInput input;

    float moveSpeed, knockbackSpeed, jumpBoost;
    protected static bool paused;
    public static bool[] completed = new bool[4], dead = new bool[4];
    
    float DeltaTime { get { return Time.deltaTime; } }

    public bool Paused { get { return paused; } }

	void Start () 
    {
        controller = GetComponent<CharacterController>();
        if (input == null)
            input = GetInput(gameObject);

        completed[input.playerNumber - 1] = false;
        dead[input.playerNumber - 1] = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (input.GetDown(input.start))
            pause();

        knockbackSpeed += knockback.x;

        if (Time.deltaTime != 0)
        {
            if (controller.isGrounded)
            {
                moveVec.y = 0;
                if (input.GetState(input.right))
                {
                    moveSpeed += acceleration;
                }
                if (input.GetState(input.left))
                    moveSpeed -= acceleration;

                if (moveSpeed > drag || moveSpeed < -drag)
                    moveSpeed -= moveSpeed * drag;
                else
                    moveSpeed = 0;

                if (input.GetDown(input.jump))
                {
                    moveVec.y += jumpHeight;
                    if (moveSpeed != 0)
                        jumpBoost += jumpHeight / 5 * Mathf.Sign(moveSpeed);
                }

                if (knockbackSpeed > drag || knockbackSpeed < -drag)
                    knockbackSpeed -= knockbackSpeed * drag;
                else if (knockbackSpeed != 0)
                    knockbackSpeed = 0;

                if (jumpBoost > drag || jumpBoost < -drag)
                    jumpBoost -= jumpBoost * drag;
                else if (jumpBoost != 0)
                    jumpBoost = 0;
            }

            moveVec -= Vector3.up * gravity * Time.deltaTime;
            if (moveVec.y < terminalVelocity)
                moveVec.y = terminalVelocity;

            if (moveSpeed > maxSpeed)
                moveSpeed = maxSpeed;
            else if (moveSpeed < -maxSpeed)
                moveSpeed = -maxSpeed;

            moveVec.x = moveSpeed + knockbackSpeed + jumpBoost;
            moveVec.y += knockback.y;
            knockback = Vector3.zero;

            controller.Move(moveVec * Time.deltaTime);


            if (input.AimVector.x > transform.position.x)
                transform.LookAt(transform.position + Vector3.right);
            else
                transform.LookAt(transform.position - Vector3.right);
        }

	}

    void OnControllerColliderHit (ControllerColliderHit hit)
    {
        if (Mathf.Abs(hit.point.x - transform.position.x) > controller.radius)
        {
            if (hit.point.x > transform.position.x && moveSpeed > 0)
            {
                moveSpeed = 0;
            }
            else if (hit.point.x < transform.position.x && moveSpeed < 0)
            {
                moveSpeed = 0;
            }
        }
    }

    protected void pause()
    {
        if (paused)
        {
            Time.timeScale = 1;
            paused = false;
        }
        else
        {
            Time.timeScale = 0;
            paused = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            completed[input.playerNumber - 1] = true;
        }
        else if (other.tag == "Floor")
        {
            dead[input.playerNumber - 1] = true;
            Destroy(this);
        }
    }
}
