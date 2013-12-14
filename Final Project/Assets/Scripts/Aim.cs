using UnityEngine;
using System.Collections;

public class Aim : Controllable {

    public CustomInput input;

	void Start () 
    {
        if (input == null)
            input = GetInput(gameObject);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Time.timeScale != 0)
        {
            if (!InputController.controllerMode)
                transform.LookAt(new Vector3(input.AimVector.x, input.AimVector.y, transform.position.z));
            else if (Mathf.Pow(input.AimVector.x, 2) + Mathf.Pow(input.AimVector.x, 2f) > 0.5f)
                transform.LookAt(new Vector3(input.AimVector.x + transform.position.x, input.AimVector.y + transform.position.y, transform.position.z));
        }
	}
}
