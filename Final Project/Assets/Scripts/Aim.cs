using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour {

    public GameObject mainCam;
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
	    transform.LookAt(new Vector3(aimFinder.aim.x, aimFinder.aim.y, transform.position.z));
	}
}
