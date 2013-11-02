using UnityEngine;
using System.Collections;

public class FindAim : MonoBehaviour 
{

    public Vector3 aim;
	
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        aim = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -transform.position.z));
	}
}
