using UnityEngine;
using System.Collections;

public class BowControl : MonoBehaviour {

    public Transform arrow;
    public GameObject bow;

    protected bool firing;

	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        firing = bow.animation["Default Take"].enabled;
	    if (Input.GetKeyDown("space") && !firing)
            fire();
	}

    void fire()
    {
        bow.animation.Play("Default Take");
        Instantiate(arrow, transform.position, transform.rotation);
    }
}
