using UnityEngine;
using System.Collections;

public class Aim : Controllable {

    public GameObject mainCam;
    public CustomInput input;
    protected FindAim aimFinder;

	void Start () 
    {
        if (mainCam == null)
            mainCam = GameObject.FindGameObjectWithTag("MainCamera");
        aimFinder = mainCam.GetComponent<FindAim>();
        if (input == null)
            input = GetInput(gameObject);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!InputController.controllerMode)
	        transform.LookAt(new Vector3(aimFinder.aim.x, aimFinder.aim.y, transform.position.z));
        else if (Mathf.Pow(input.RStickLocation.x, 2) + Mathf.Pow(input.RStickLocation.x, 2f) > 0.5f)
            transform.LookAt(new Vector3(input.RStickLocation.x + transform.position.x, input.RStickLocation.y + transform.position.y, transform.position.z));
	}
}
