using UnityEngine;
using System.Collections;

public class ArrowControl : MonoBehaviour {

    public float speed, length, damage;
    public GameObject arrow;
    public string damageType;

    protected bool flying;
    protected RaycastHit hit;

	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update () 
    {
        flying = !arrow.animation["Default Take"].enabled;
        if (flying)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Physics.Raycast(transform.position, transform.forward, out hit, length) && !hit.collider.isTrigger)
        {
            hit.collider.gameObject.BroadcastMessage("Hit", new Damage(damage, damageType), SendMessageOptions.DontRequireReceiver);
            Destroy(this.gameObject);
        }
	}
}
