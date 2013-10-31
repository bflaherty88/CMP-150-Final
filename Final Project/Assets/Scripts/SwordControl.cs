using UnityEngine;
using System.Collections;

public class SwordControl : MonoBehaviour 
{

    protected bool swinging, waiting;

    public float damage = 10;
    public float swingTime;
    public string damageType = "Physical";

	void Start ()
    {
         
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetButtonDown("Fire1"))
            swing();
        Debug.Log(swinging);
	}

    void OnTriggerEnter(Collider other)
    {
        if (swinging)
            other.gameObject.BroadcastMessage("Hit", new Damage(damage, damageType), SendMessageOptions.DontRequireReceiver);
    }
    
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
            animation.Play();
            yield return new WaitForSeconds(swingTime / 2);
            swinging = false;
            yield return new WaitForSeconds(swingTime / 2);
            waiting = false;
        }
        else
            yield return null;

    }
    
}
