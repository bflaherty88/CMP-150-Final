using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class CharacterControl : Character {

    CharacterController controller;
    Vector3 moveVec;
    public CustomInput input;
    public float gravity = 1, drag = 1, maxSpeed = 15;

    float moveSpeed;

	void Start () 
    {
        controller = GetComponent<CharacterController>();
        if (input == null)
            input = GetInput(gameObject);
	}
	
	// Update is called once per frame
	void Update () 
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


        moveVec += knockback;
        knockback = Vector3.zero;
        controller.Move(moveVec * Time.deltaTime);
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
}
