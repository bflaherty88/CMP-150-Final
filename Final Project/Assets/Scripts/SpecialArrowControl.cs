using UnityEngine;
using System.Collections;

public class SpecialArrowControl : MonoBehaviour
{

    public float speed, length, damage, knockback, effectDamage;
    public GameObject arrow;
    public string damageType, effectType;

    protected bool flying;
    protected RaycastHit hit;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        flying = !arrow.animation["Default Take"].enabled;
        if (flying)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Physics.Raycast(transform.position, transform.forward, out hit, length) && !hit.collider.isTrigger)
        {
            hit.collider.gameObject.BroadcastMessage("Hit", new Damage(damage, damageType, knockback), SendMessageOptions.DontRequireReceiver);
            hit.collider.gameObject.BroadcastMessage("Hit", new Damage(effectDamage, damageType, 0f), SendMessageOptions.DontRequireReceiver);
            Destroy(this.gameObject);
        }
    }
}
