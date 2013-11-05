using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour 
{

    public GameObject mainCam;
    public XInput xInput;

    protected FindAim camAim;

    void Start()
    {
        if (mainCam == null)
            mainCam = GameObject.FindGameObjectWithTag("MainCamera");
        camAim = mainCam.GetComponent<FindAim>();
    }

    void Update()
    {
        if (!InputController.controllerMode)
            transform.LookAt(new Vector3(camAim.aim.x, transform.position.y, transform.position.z));
        else
        {
            if (Input.GetAxis(xInput.rStickX) > 0.25f)
                transform.LookAt(transform.position + Vector3.right);
            else if (Input.GetAxis(xInput.rStickX) < -0.25f)
                transform.LookAt(transform.position - Vector3.right);
        }
    }
	
}
