using UnityEngine;
using System.Collections;

public class CustomInput : MonoBehaviour 
{
    public KeyCode
        left = KeyCode.A,
        right = KeyCode.D,
        up = KeyCode.W,
        down = KeyCode.S,
        jump = KeyCode.Space,
        fire1 = KeyCode.Mouse0,
        fire2 = KeyCode.Mouse1,
        activate = KeyCode.E;

    public string
        xHorizontal = "Move X",
        xVertical = "Move Y",
        xJump = "A Button",
        xFire1 = "R Trigger",
        xFire2 = "L Trigger",
        xActivate = "X Button";

    public string uHorizontal { get { return controllerString + xHorizontal ; } }
    public string uVertical { get { return controllerString + xVertical; } }
    public string uJump { get { return controllerString + xJump; } }
    public string uFire1 { get { return controllerString + xFire1; } }
    public string uFire2 { get { return controllerString + xFire2; } }
    public string uActivate { get { return controllerString + xActivate; } }

    public int controllerNumber = 1;

    protected string controllerString { get { return "Controller" + controllerNumber + "_"; } }
    protected bool rTriggerWasDown, lTriggerWasDown, horizontalWasRest, verticalWasRest;
    protected Event e;

	void Start () 
    {
        InputController.PlayerCount += 1;
	}
	

	void Update () 
    {

        rTriggerWasDown = Input.GetAxis(controllerString + "R Trigger") > 0.5f;
        lTriggerWasDown = Input.GetAxis(controllerString + "L Trigger") > 0.5f;
        horizontalWasRest = Input.GetAxis(uHorizontal) < 0.25f && Input.GetAxis(uHorizontal) > -0.25f;
        verticalWasRest = Input.GetAxis(uVertical) < 0.25f && Input.GetAxis(uVertical) > -0.25f;

        
        if (InputController.PlayerCount == 1)
        {
            if (Input.anyKeyDown)
            {
                InputController.controllerMode = !(e.isKey || e.isMouse);
            }
        }
        else
            InputController.controllerMode = true;
        

	}

    void OnGUI()
    {
        e = Event.current;
    }

    public bool GetDown(KeyCode key)
    {
        if (!InputController.controllerMode)
            return Input.GetKeyDown(key);
        else
        {
            if (key == left)
                return Input.GetAxis(uHorizontal) > 0.25 && horizontalWasRest;
            else if (key == right)
                return Input.GetAxis(uHorizontal) < -0.25 && horizontalWasRest;
            else if (key == up)
                return Input.GetAxis(uVertical) > 0.25 && verticalWasRest;
            else if (key == down)
                return Input.GetAxis(uVertical) < -0.25 && verticalWasRest;
            else if (key == jump)
                return Input.GetButtonDown(uJump);
            else if (key == fire1)
                return Input.GetButtonDown(uFire1);
            else if (key == fire2)
                return Input.GetButtonDown(uFire2);
            else if (key == activate)
                return Input.GetButtonDown(uActivate);
            else
                return false;
        }
    }

    public bool GetUp(KeyCode key)
    {
        if (!InputController.controllerMode)
            return Input.GetKeyDown(key);
        else
        {
            if (key == left)
                return Input.GetAxis(uHorizontal) > -0.25 && !horizontalWasRest;
            else if (key == right)
                return Input.GetAxis(uHorizontal) < 0.25 && !horizontalWasRest;
            else if (key == up)
                return Input.GetAxis(uVertical) < 0.25 && !verticalWasRest;
            else if (key == down)
                return Input.GetAxis(uVertical) > -0.25 && !verticalWasRest;
            else if (key == jump)
                return Input.GetButtonUp(uJump);
            else if (key == fire1)
                return Input.GetButtonUp(uFire1);
            else if (key == fire2)
                return Input.GetButtonUp(uFire2);
            else if (key == activate)
                return Input.GetButtonUp(uActivate);
            else
                return false;
        }
    }

    public bool GetState(KeyCode key)
    {
        if (!InputController.controllerMode)
            return Input.GetKey(key);
        else
        {
            if (key == left)
                return Input.GetAxis(uHorizontal) > 0.25;
            else if (key == right)
                return Input.GetAxis(uHorizontal) < -0.25;
            else if (key == up)
                return Input.GetAxis(uVertical) > 0.25;
            else if (key == down)
                return Input.GetAxis(uVertical) < -0.25;
            else if (key == jump)
                return Input.GetButton(uJump);
            else if (key == fire1)
                return Input.GetButton(uFire1);
            else if (key == fire2)
                return Input.GetButton(uFire2);
            else if (key == activate)
                return Input.GetButton(uActivate);
            else
                return false;
        }
    }

    public float GetState(string axis)
    {
        return Input.GetAxis(axis);
    }

    public bool GetDown(string axis)
    {
        return Input.GetButtonDown(axis);
    }

    public float GetAxis(string axis)
    {
        return Input.GetAxis(axis);
    }
}
