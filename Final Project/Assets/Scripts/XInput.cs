using UnityEngine;
using System.Collections;

public class XInput : MonoBehaviour 
{
    public string lStickX, lStickY, rStickX, rStickY, lTrigger, rTrigger, aButton, bButton, xButton, yButton;
    public bool lTriggerDown, lTriggerUp, rTriggerDown, rTriggerUp;
    protected bool lTriggerWasDown, rTriggerWasDown;

    public Vector3 LStickLoc
    {
        get { return new Vector3(Input.GetAxis(lStickX), Input.GetAxis(lStickY)); }
    }
    public Vector3 RStickLoc
    {
        get { return new Vector3(Input.GetAxis(rStickX), Input.GetAxis(rStickY)); }
    }
	
	void Start () 
    {
	
	}
	
	
	void Update () 
    {
        lTriggerDown = false;
        lTriggerUp = false;
        rTriggerDown = false;
        rTriggerUp = false;

        lTriggerDown = Input.GetAxis(lTrigger) > 0.5f && !lTriggerWasDown;
        rTriggerDown = Input.GetAxis(rTrigger) > 0.5f && !rTriggerWasDown;

        lTriggerUp = Input.GetAxis(lTrigger) < 0.5f && lTriggerWasDown;
        rTriggerUp = Input.GetAxis(rTrigger) < 0.5f && rTriggerWasDown;

        lTriggerWasDown = Input.GetAxis(lTrigger) > 0.5f;
        rTriggerWasDown = Input.GetAxis(rTrigger) > 0.5f;
	}
}
