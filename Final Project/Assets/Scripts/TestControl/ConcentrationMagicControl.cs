using UnityEngine;
using System.Collections;

public class ConcentrationMagicControl : MonoBehaviour {

    public float damage, knockback;
    public string damageType;
    public ParticleSystem particles;

    protected bool firing;
	

	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        firing = Input.GetButton("Fire1");
        particles.enableEmission = firing;
	}

    void OnTriggerStay (Collider other)
    {
        if (firing)
            other.gameObject.BroadcastMessage("Hit", new Damage(damage, damageType, knockback), SendMessageOptions.DontRequireReceiver);
    }
}
