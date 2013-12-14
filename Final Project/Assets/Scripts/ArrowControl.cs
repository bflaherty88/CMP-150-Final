using UnityEngine;
using System.Collections;

public class ArrowControl : Weapon {

    public float speed, length;
    public GameObject arrow;
    public Damage specialDamage;

    protected bool released, flying;
    protected RaycastHit hit;

	void Start () 
    {
        baseDamage = transform.parent.gameObject.GetComponent<Weapon>().baseDamage;
        specialDamage = new Damage(0f, "Poision");
	}
	
	// Update is called once per frame
	void Update () 
    {
        flying = released && !arrow.animation["Release"].enabled;
        if (flying)
        {
            transform.parent = null;
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if (Physics.Raycast(transform.position, transform.forward, out hit, length) && !hit.collider.isTrigger)
            {
                hit.collider.gameObject.BroadcastMessage("Hit", baseDamage, SendMessageOptions.DontRequireReceiver);
                if (specialDamage.baseDamage != 0)
                    hit.collider.gameObject.BroadcastMessage("Hit", specialDamage, SendMessageOptions.DontRequireReceiver);
                Destroy(this.gameObject);
            }
        }
	}

    void Draw()
    {
        arrow.animation.Play("Draw");
    }

    void Release()
    {
        arrow.animation.Play("Release");
        released = true;
    }
}
