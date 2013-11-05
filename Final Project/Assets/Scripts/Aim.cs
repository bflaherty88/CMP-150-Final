using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour {

    public GameObject mainCam;
    public XInput xInput;
    protected FindAim aimFinder;

	void Start () 
    {
        if (mainCam == null)
            mainCam = GameObject.FindGameObjectWithTag("MainCamera");
        aimFinder = mainCam.GetComponent<FindAim>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!InputController.controllerMode)
	        transform.LookAt(new Vector3(aimFinder.aim.x, aimFinder.aim.y, transform.position.z));
        else if (Mathf.Pow(xInput.RStickLoc.x, 2) + Mathf.Pow(xInput.RStickLoc.x, 2f) > 0.5f)
            transform.LookAt(new Vector3(xInput.RStickLoc.x + transform.position.x, xInput.RStickLoc.y + transform.position.y, transform.position.z));
	}
}
