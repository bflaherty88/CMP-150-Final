using UnityEngine;
using System.Collections;

public class ShieldControl : MonoBehaviour {


	void Start ()
    {
        animation["Down"].time = animation["Down"].length;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (animation["Down"].time > animation["Down"].length)
                animation["Down"].time = animation["Down"].length;
            animation["Down"].speed = -1;
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            if (animation["Down"].time < 0)
                animation["Down"].time = 0;
            animation["Down"].speed = 1;
        }
        animation.Play("Down");
	}
}
