using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

    public static bool controllerMode = false;
    public static int PlayerCount
    {
        get { return playerCount; }
        set { playerCount = (value <= 4 && value > 0) ? value : playerCount; }
    }

    protected static int playerCount;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	}
}
