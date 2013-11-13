using UnityEngine;
using System.Collections;

public class Keyboardinput : ControllerInput
{
    public KeyCode activationKey = KeyCode.Space;

    void Update()
    {
        isActive = Input.GetKey(activationKey);
		
    }
}
