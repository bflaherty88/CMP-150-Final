using UnityEngine;
using System.Collections;

public class WorldController : MonoBehaviour {

    public bool useController;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        InputController.controllerMode = useController;
	}
}
