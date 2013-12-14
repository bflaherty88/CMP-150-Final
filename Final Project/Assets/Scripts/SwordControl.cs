using UnityEngine;
using System.Collections;

public class SwordControl : Weapon
{

    protected bool swinging, waiting, wasDown;
    public CustomInput input;
    public float attackSpeed = 1;

	void Start ()
    {
        if (input == null)
            input = GetInput(gameObject);

        baseDamage = new Damage(10f, "Physical", 10);
	}
	
	// Update is called once per frame
	void Update () 
    {
        animation["Down"].speed = attackSpeed;
        animation["Up"].speed = attackSpeed;
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
        Debug.Log("TriggerEnter");
        if (swinging)
        {
            other.gameObject.BroadcastMessage("Hit", baseDamage, SendMessageOptions.DontRequireReceiver);
        }
    }
    
    void swing()
    {
        if (!waiting)
            animation.Play("Down");
    }
}
