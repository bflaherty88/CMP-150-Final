using UnityEngine;
using System.Collections;

public class SwordControl : MonoBehaviour 
{

    protected bool swinging, waiting, wasDown;

    public float damage = 10;
    public string damageType = "Physical";

	void Start ()
    {
         
	}
	
	// Update is called once per frame
	void Update () 
    {
        waiting = (animation["Down"].enabled || animation["Up"].enabled);
        if (Input.GetButtonDown("Fire1"))
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
            other.gameObject.BroadcastMessage("Hit", new Damage(damage, damageType), SendMessageOptions.RequireReceiver);
            Debug.Log("Sword Hit");
        }
    }
    
    void swing()
    {
        if (!waiting)
            animation.Play("Down");
    }

    
}
