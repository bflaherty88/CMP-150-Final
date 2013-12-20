using UnityEngine;
using System.Collections;

public class JumpTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        if (tag != "Jump")
            tag = "Jump";

        renderer.enabled = false;
	}
}
