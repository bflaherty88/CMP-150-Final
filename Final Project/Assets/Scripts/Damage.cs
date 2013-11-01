using UnityEngine;
using System.Collections;

public class Damage 
{
    public float baseDamage, baseKnockback;
    public string type;

    public Damage(float baseDamage, string type)
    {
        this.baseDamage = baseDamage;
        this.type = type;
        this.baseKnockback = 1;
    }
    public Damage(float baseDamage, string type, float baseKnockback)
    {
        this.baseDamage = baseDamage;
        this.type = type;
        this.baseKnockback = baseKnockback;
    }
}
