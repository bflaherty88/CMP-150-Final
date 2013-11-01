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
	    if (Input.GetButtonDown("Fire1") && !firing)
            fire();
	}

    void fire()
    {
        bow.animation.Play();
        Instantiate(arrow, transform.position, transform.rotation);
    }
}
