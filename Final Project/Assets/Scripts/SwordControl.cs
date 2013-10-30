using UnityEngine;
using System.Collections;

public class SwordControl : MonoBehaviour 
{

    protected bool swinging, waiting;
    protected Vector3 startAngle;

    public float damage = 10;
    public string damageType = "Physical";

	void Start ()
    {
         
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
            animation.Play();
        
	}

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.BroadcastMessage("Hit", new Damage(damage, damageType));
    }
    /*
    void swing()
    {
        StartCoroutine(Swing());
    }

    IEnumerator Swing()
    {
        if (!waiting)
        {
            waiting = true;
            swinging = true;
            yield return new WaitForSeconds(1 / swingSpeed);
            swinging = false;
        }
        else
            yield return null;

    }
    */
}
