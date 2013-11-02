using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour 
{

    public GameObject mainCam;

    protected FindAim camAim;

    void Start()
    {
        if (mainCam == null)
            mainCam = GameObject.FindGameObjectWithTag("MainCamera");
        camAim = mainCam.GetComponent<FindAim>();
    }

    void Update()
    {
        transform.LookAt(new Vector3(camAim.aim.x, transform.position.y, transform.position.z));
    }
	
}
