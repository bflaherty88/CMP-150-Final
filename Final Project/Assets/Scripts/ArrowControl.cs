using UnityEngine;
using System.Collections;

public class ArrowControl : Weapon {

    public float speed, length;
    public GameObject arrow;
    public float SpecialDamage;

    protected bool released, flying, decaying;
    protected RaycastHit hit;
    protected Damage specialDamage;

	void Start () 
    {
        if (transform.parent.gameObject.GetComponent<Weapon>() != null)
        {
            leftDamage = transform.parent.gameObject.GetComponent<Weapon>().leftDamage;
            rightDamage = transform.parent.gameObject.GetComponent<Weapon>().rightDamage;
        }
        else
        {
            leftDamage = transform.parent.parent.gameObject.GetComponent<Weapon>().leftDamage;
            rightDamage = transform.parent.parent.gameObject.GetComponent<Weapon>().rightDamage;
        }
        specialDamage = new Damage(0f, "Poision", leftDamage.baseKnockback);
	}
	
	// Update is called once per frame
	void Update () 
    {
        flying = released && !arrow.animation["Release"].enabled;
        if (flying)
        {
            if (!decaying)
                StartCoroutine(Decay());

            transform.Translate(Vector3.down * Time.deltaTime);
            transform.Translate(-Vector3.forward * transform.position.z * Time.deltaTime * 10, Space.World);
            transform.parent = null;
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if (Physics.Raycast(transform.position, transform.forward, out hit, length) && !hit.collider.isTrigger)
            {
                if (transform.position.x < hit.transform.position.x)
                    hit.collider.gameObject.BroadcastMessage("Hit", leftDamage, SendMessageOptions.DontRequireReceiver);
                else
                    hit.collider.gameObject.BroadcastMessage("Hit", rightDamage, SendMessageOptions.DontRequireReceiver);
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

    IEnumerator Decay()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
