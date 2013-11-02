using UnityEngine;
using System.Collections;

public class ProjectileControl : MonoBehaviour {

    public float speed, lifeSpan, damage;
    public string damageType;
    public Transform explosion;

    protected bool closing;

	// Use this for initialization
	void Start () 
    {
        StartCoroutine(Countdown());
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
        other.BroadcastMessage("Hit", new Damage(damage, damageType), SendMessageOptions.DontRequireReceiver);
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
