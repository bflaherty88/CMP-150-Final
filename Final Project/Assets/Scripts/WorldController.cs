using UnityEngine;
using System.Collections;

public class WorldController : MonoBehaviour {

    public bool useController;
    public int playerCount;    

	void Start () 
    {
        InputController.PlayerCount = playerCount;
	}
	
	// Update is called once per frame
	void Update () 
    {
        InputController.controllerMode = useController;
        InputController.PlayerCount = playerCount;
	}
}
