using UnityEngine;
using System.Collections;

public class SwordControl : MonoBehaviour {

    protected int swingDirection;
    protected bool swinging;

    public float swingSpeed;

	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if (Input.GetKeyDown("space"))
            swing();
        transform.Rotate(-Vector3.forward * swingSpeed * swingDirection);
	}


    protected void swing()
    {
        StartCoroutine(Swing());
    }

    IEnumerator Swing()
    {
        if (!swinging)
        {
            swinging = true;
            yield return new WaitForEndOfFrame();
            swingDirection = 1;
            yield return new WaitForSeconds(2 / swingSpeed);
            swingDirection = -1;
            yield return new WaitForSeconds(2 / swingSpeed);
            swingDirection = 0;
            swinging = false;
        }
        else
            yield return null;
    }
    void OnTriggerEnter(Collider other)
    {
        other.gameObject.BroadcastMessage("Hit");
    }
}
