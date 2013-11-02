using UnityEngine;
using System.Collections;

public class ShieldControl : MonoBehaviour {


	void Start ()
    {
        animation["Up"].speed = -1;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (animation["Up"].time < 0)
                animation["Up"].time = 0;
            animation["Up"].speed = 1;
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            if (animation["Up"].time > animation["Up"].length)
                animation["Up"].time = animation["Up"].length;
            animation["Up"].speed = -1;
        }
        animation.Play("Up");
        Debug.Log(animation["Up"].time);
	}
}
