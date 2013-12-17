using UnityEngine;
using System.Collections;

public class SwordControl : Weapon
{

    protected bool swinging, waiting;
    public CustomInput input;
    public float attackSpeed = 1;

	void Start ()
    {
        if (input == null)
            input = GetInput(gameObject);

        leftDamage = new Damage(10f, "Physical", new Vector3(10, 10));
        rightDamage = new Damage(10f, "Physical", new Vector3(-10, 10));
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

        if (animation["Down"].time >= animation["Down"].length)
        {
            animation.Play("Up");
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (swinging)
        {
            if (transform.position.x < other.transform.position.x)
                other.gameObject.BroadcastMessage("Hit", leftDamage, SendMessageOptions.DontRequireReceiver);
            else
                other.gameObject.BroadcastMessage("Hit", rightDamage, SendMessageOptions.DontRequireReceiver);
        }
    }
    
    void swing()
    {
        if (!waiting)
            animation.Play("Down");
    }
}
