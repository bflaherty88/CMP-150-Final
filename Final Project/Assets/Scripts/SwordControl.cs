using UnityEngine;
using System.Collections;

public class SwordControl : Weapon
{

    protected bool swinging, waiting, wasDown;
    public CustomInput input;

	void Start ()
    {
        if (input == null)
            input = GetInput(gameObject);
	}
	
	// Update is called once per frame
	void Update () 
    {
        waiting = (animation["Down"].enabled || animation["Up"].enabled);
        if (input.GetDown(input.fire1))
            swing();

        swinging = animation["Down"].enabled;

        if (!animation["Down"].enabled && wasDown)
        {
            animation.Play("Up");
            wasDown = false;
        }

        wasDown = animation["Down"].enabled;
	}

    void OnTriggerEnter(Collider other)
    {
        if (swinging)
        {
            other.gameObject.BroadcastMessage("Hit", baseDamage, SendMessageOptions.RequireReceiver);
        }
    }
    
    void swing()
    {
        if (!waiting)
            animation.Play("Down");
    }
}
