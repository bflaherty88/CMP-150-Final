using UnityEngine;
using System.Collections;

public class Damage 
{
    public float baseDamage;
    public string type;

    public Damage(float baseDamage, string type)
    {
        this.baseDamage = baseDamage;
        this.type = type;
    }
}
