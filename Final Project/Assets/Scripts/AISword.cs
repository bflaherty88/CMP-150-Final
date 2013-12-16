using UnityEngine;
using System.Collections;

public class AISword : Weapon
{

    protected bool swinging, waiting, wasDown;
    public float attackSpeed = 1;

    void Start()
    {
        leftDamage = new Damage(baseDamage, attackType, new Vector3(baseKnockback, baseKnockback));
        rightDamage = new Damage(baseDamage, attackType, new Vector3(-baseKnockback, baseKnockback));
    }

    // Update is called once per frame
    void Update()
    {
        animation["Down"].speed = attackSpeed;
        animation["Up"].speed = attackSpeed;
        waiting = (animation["Down"].enabled || animation["Up"].enabled);

        swinging = animation["Down"].enabled;

        if (animation["Down"].time > animation["Down"].length)
            animation.Play("Up");
    }

    void OnTriggerEnter(Collider other)
    {
        if (swinging)
        {
            if (transform.position.x < other.transform.position.x)
                other.gameObject.BroadcastMessage("Hit", leftDamage, SendMessageOptions.DontRequireReceiver);
            else
                other.gameObject.BroadcastMessage("Hit", rightDamage, SendMessageOptions.DontRequireReceiver);
        }
    }

    public void swing()
    {
        if (!waiting)
            animation.Play("Down");
    }
}
