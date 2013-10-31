using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
       
	}
    void Hit(Damage testDam)
    {
        Debug.Log("Value: " + testDam.value + "\nType: " + testDam.type);
    }
}
