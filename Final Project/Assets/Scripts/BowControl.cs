using UnityEngine;
using System.Collections;

public class BowControl : MonoBehaviour {

    public Transform arrow, specialArrow;
    public GameObject bow;

    protected bool firing;

	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        firing = bow.animation["Fire"].enabled;
	    if (Input.GetButtonDown("Fire1") && !firing)
            fire();
        else if(Input.GetButtonDown("Fire2") && !firing)
            fireSpecial();
	}

    void fire()
    {
        bow.animation.Play();
        Instantiate(arrow, transform.position, transform.rotation);
    }

    void fireSpecial()
    {
        bow.animation.Play();
        Instantiate(specialArrow, transform.position, transform.rotation);
    }
}
