using UnityEngine;
using System.Collections;

public class ArrowControl : MonoBehaviour {

    public float speed, length, damage, effectDamage;
    public GameObject arrow;
    public string damageType, effectType;

    protected bool released, flying;
    protected RaycastHit hit;

	void Start () 
    {
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
                hit.collider.gameObject.BroadcastMessage("Hit", new Damage(damage, damageType), SendMessageOptions.DontRequireReceiver);
                if (effectDamage != 0)
                    hit.collider.gameObject.BroadcastMessage("Hit", new Damage(effectDamage, effectType, 0f), SendMessageOptions.DontRequireReceiver);
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
