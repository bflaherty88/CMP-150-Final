using UnityEngine;
using System.Collections;

public class CharacterControl : Character {

    CharacterController controller;
    Vector3 moveVec;
    public CustomInput input;
    public float drag = 1;

    float moveSpeed;
    protected static bool paused;
    float DeltaTime { get { return Time.deltaTime; } }

    public bool Paused { get { return paused; } }

	void Start () 
    {
        controller = GetComponent<CharacterController>();
        if (input == null)
            input = GetInput(gameObject);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (input.GetDown(input.start))
            pause();
        if (Time.deltaTime != 0)
        {
            if (controller.isGrounded)
            {
                if (input.GetState(input.right))
                {
                    moveSpeed += acceleration;
                }
                if (input.GetState(input.left))
                    moveSpeed -= acceleration;

                if (moveSpeed != 0)
                    moveSpeed -= moveSpeed * drag;

                if (input.GetDown(input.jump))
                {
                    moveVec.y += jumpHeight;
                }
                else
                    moveVec.y = 0;
            }

            moveVec -= Vector3.up * gravity;

            if (moveSpeed > maxSpeed)
                moveSpeed = maxSpeed;
            else if (moveSpeed < -maxSpeed)
                moveSpeed = -maxSpeed;

            moveVec.x = moveSpeed;

            
            moveVec += transform.InverseTransformDirection(knockback);
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
}
