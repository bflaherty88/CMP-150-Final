using UnityEngine;
using System.Collections;

public class Damage 
{
    public float baseDamage;
    public string type;
    public Vector3 baseKnockback;

    public Damage(float baseDamage, string type, Vector3 baseKnockback)
    {
        this.baseDamage = baseDamage;
        this.type = type;
        this.baseKnockback = baseKnockback;
    }
}
