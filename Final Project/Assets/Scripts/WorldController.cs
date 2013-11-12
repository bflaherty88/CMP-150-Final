using UnityEngine;
using System.Collections;

public class WorldController : MonoBehaviour {

    public int playerCount;    

	void Start () 
    {
        InputController.PlayerCount = playerCount;
	}
	
	// Update is called once per frame
	void Update () 
    {
        InputController.PlayerCount = playerCount;
	}
}
