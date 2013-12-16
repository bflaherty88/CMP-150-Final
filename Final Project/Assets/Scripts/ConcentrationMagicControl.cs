using UnityEngine;
using System.Collections;

public class ConcentrationMagicControl : Weapon 
{
    
    public ParticleSystem particles;
    public CustomInput input;

    protected bool firing;

	void Start () 
    {
        if (input == null)
            input = GetInput(gameObject);
        leftDamage = new Damage(1f, "Frost", Vector3.zero);
	}
	
	// Update is called once per frame
	void Update () 
    {
        firing = input.GetState(input.fire1);
        particles.enableEmission = firing;
	}

    void OnTriggerStay (Collider other)
    {
        Debug.Log("Freeze");
        if (firing)
            other.gameObject.BroadcastMessage("Hit", leftDamage, SendMessageOptions.DontRequireReceiver);
    }
}
