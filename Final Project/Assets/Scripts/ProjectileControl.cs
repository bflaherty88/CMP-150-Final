using UnityEngine;
using System.Collections;

public class ProjectileControl : MonoBehaviour {

    public float speed, lifeSpan;
    public Transform explosion;

    protected bool closing;
    protected Damage leftDamage, rightDamage;

	// Use this for initialization
	void Start () 
    {
        StartCoroutine(Countdown());
        leftDamage = transform.parent.gameObject.GetComponent<Weapon>().leftDamage;
        rightDamage = transform.parent.gameObject.GetComponent<Weapon>().rightDamage;
        transform.parent = null;
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(lifeSpan);
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (transform.position.x < other.transform.position.x)
            other.gameObject.BroadcastMessage("Hit", leftDamage, SendMessageOptions.DontRequireReceiver);
        else
            other.gameObject.BroadcastMessage("Hit", rightDamage, SendMessageOptions.DontRequireReceiver);

        Destroy(this.gameObject);
    }

    void OnApplicationQuit()
    {
        closing = true;
    }

    void OnDestroy()
    {
        if (!closing)
            Instantiate(explosion, transform.position, transform.rotation);
    }
}
