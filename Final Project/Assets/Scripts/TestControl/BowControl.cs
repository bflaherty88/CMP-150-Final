using UnityEngine;
using System.Collections;

public class BowControl : MonoBehaviour {

    public Transform arrow, specialArrow;
    public GameObject bow;

    protected bool firing, released;
    protected GameObject tempArrow;

	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if (Input.GetButtonDown("Fire1") && !firing)
            draw();
        else if(Input.GetButtonDown("Fire2") && !firing)
            drawSpecial();

        released = (Input.GetButtonUp("Fire1") || Input.GetButtonUp("Fire2")) && firing ? true : released;

        if (released && !bow.animation["Draw"].enabled)
            release();

	}

    void draw()
    {
        firing = true;
        tempArrow = ((Transform)Instantiate(arrow, transform.position, transform.rotation)).gameObject;
        tempArrow.transform.parent = transform;
        bow.animation.Play("Draw");
        tempArrow.BroadcastMessage("Draw");
    }

    void drawSpecial()
    {
        firing = true;
        tempArrow = ((Transform)Instantiate(specialArrow, transform.position, transform.rotation)).gameObject;
        tempArrow.transform.parent = transform;
        bow.animation.Play("Draw");
        tempArrow.BroadcastMessage("Draw");
    }

    void release()
    {
        released = false;
        firing = false;
        bow.animation.Play("Release");
        tempArrow.BroadcastMessage("Release");
    }
}
