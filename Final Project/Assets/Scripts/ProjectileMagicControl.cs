using UnityEngine;
using System.Collections;

public class ProjectileMagicControl : MonoBehaviour 
{
    protected bool waiting;

    public Transform projectile;
    public float fireRate;

	// Use this for initialization
	void Start () 
    {
	    if (fireRate == 0f)
            fireRate = 1;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetButtonDown("Fire2"))
            fire();
	}

    void fire()
    {
        StartCoroutine(Fire());
    }

    IEnumerator Fire()
    {
        if (!waiting)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            waiting = true;
            yield return new WaitForSeconds(1 / fireRate);
            waiting = false;
        }
        else
            yield return null;
    }
}
