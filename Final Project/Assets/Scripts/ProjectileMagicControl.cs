using UnityEngine;
using System.Collections;

public class ProjectileMagicControl : Weapon
{
    protected bool waiting;

    public Transform projectile;
    public float fireRate;
    public CustomInput input;
	// Use this for initialization
	void Start () 
    {
	    if (fireRate == 0f)
            fireRate = 1;
        if (input == null)
            input = GetInput(gameObject);

        leftDamage = new Damage(baseDamage, attackType, new Vector3(baseKnockback, baseKnockback));
        rightDamage = new Damage(baseDamage, attackType, new Vector3(-baseKnockback, baseKnockback));
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (input.GetDown(input.fire2))
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
            ((Transform)Instantiate(projectile, transform.position, transform.rotation)).parent = transform;
            waiting = true;
            yield return new WaitForSeconds(1 / fireRate);
            waiting = false;
        }
        else
            yield return null;
    }
}
