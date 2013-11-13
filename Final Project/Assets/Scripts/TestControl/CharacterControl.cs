using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class CharacterControl : Character {

    CharacterController controller;
    Vector3 calcVec, moveVec;
    public CustomInput input;

	void Start () 
    {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        Debug.Log(InputController.controllerMode);
        if (controller.isGrounded)
        {
            if (input.GetState(input.right))
            {
                Debug.Log("Something");
                calcVec += Vector3.right * moveSpeed;
            }
            else if (input.GetState(input.left))
                calcVec -= Vector3.left * moveSpeed;
            else
                calcVec.x = 0;

            if (input.GetDown(input.jump))
                calcVec += Vector3.up * jumpHeight;
        }
        else
            calcVec -= Vector3.up * Time.deltaTime;

        calcVec += knockback;
        knockback = Vector3.zero;

        moveVec = transform.InverseTransformDirection(calcVec);
        controller.Move(moveVec);
	}
}
