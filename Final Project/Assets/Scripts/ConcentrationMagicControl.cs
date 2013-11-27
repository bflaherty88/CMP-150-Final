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
	}
	
	// Update is called once per frame
	void Update () 
    {
        firing = input.GetState(input.fire1);
        particles.enableEmission = firing;
	}

    void OnTriggerStay (Collider other)
    {
        if (firing)
            other.gameObject.BroadcastMessage("Hit", baseDamage, SendMessageOptions.DontRequireReceiver);
    }
}
