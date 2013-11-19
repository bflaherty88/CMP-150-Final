using UnityEngine;
using System.Collections;

public class SwordControl : MonoBehaviour 
{

    protected bool swinging, waiting, wasDown;

    public float damage = 10;
    public string damageType = "Physical";
    public CustomInput input;

	void Start ()
    {
        if (input == null)
            GetInput(gameObject);
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
            other.gameObject.BroadcastMessage("Hit", new Damage(damage, damageType), SendMessageOptions.RequireReceiver);
        }
    }
    
    void swing()
    {
        if (!waiting)
            animation.Play("Down");
    }

    void GetInput(GameObject gObject)
    {
        input = gObject.GetComponent<CustomInput>();
        if (input == null)
        {
            if (gObject.transform.parent.gameObject != null)
                GetInput(gObject.transform.parent.gameObject);
            else
                Debug.LogError("No CustomInput script on hierarchy.");
        }
    }
}
