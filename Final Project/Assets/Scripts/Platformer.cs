
using UnityEngine;
using System.Collections;
using System;
	
public static class extensions
{
	public static bool Has<T>(this Enum Type, T value)
    {
	try
	{ 
		return(((int)(object)Type & (int)(object)value) == (int)(object)value);
	}
	catch
	{
		return false;
	}
    }
}

[RequireComponent(typeof(CharacterController))]

public class Platformer : MonoBehaviour
{	
	
	
	public Control MoveLeft,
	               MoveRight,
				   Jump;
	               
	
	
	public float  Gravity = 9,
		          Jumpstrength = 20,
			      Movespeed = 30;
	
	public GameObject drawObject; 

	private CollisionFlags prevflags;
	private CharacterController Controller;
	
		
	void Start()
	{
	   Controller = GetComponent<CharacterController>();
		if (Controller == null)
		{
			Debug.LogError("no character controller found on: " + name);
		}
	}
	
	// Update is called once per frame
	void Update() 
	{
		
		Vector3 moveVec = Vector3.zero;
	
		if (MoveLeft.IsActive)
		{
		    moveVec.x -=Movespeed;
			drawObject.transform.rotation = Quaternion.Euler(0,0,0);
		
		}
	
		if (MoveRight.IsActive)
		{
		     moveVec.x +=Movespeed;
			drawObject.transform.rotation = Quaternion.Euler(0,180,0);
		}
		
		if (Jump.IsActive)
		{
		    moveVec.y +=Jumpstrength;
			transform.Translate(Vector3.up * 100 * Time.deltaTime);
						
		}
		
        if(!prevflags.Has(CollisionFlags.CollidedBelow))
		{
		
			moveVec.y -= Gravity;
			
		}
		
   		prevflags = Controller.Move(moveVec*Time.deltaTime);
			
		
	}
	
}
