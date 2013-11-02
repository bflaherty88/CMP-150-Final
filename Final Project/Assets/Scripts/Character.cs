using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour 
{

    public float health, physicalResistance, magicResistance, knockbackResistance, moveSpeed;

    protected Vector3 knockback;
    protected int effectTime = 5;

    void Hit(Damage attack)
    {
        if (attack.type == "Physical")
        {
            health -= (attack.baseDamage / physicalResistance);
        }
        else if (attack.type == "Piercing")
        {
            health -= (attack.baseDamage / (physicalResistance / 2));
        }
        else if (attack.type == "Fire" || attack.type == "Frost")
        {
            health -= (attack.baseDamage / magicResistance);
            StartCoroutine(Affect(attack));
        }
        else if (attack.type == "Poison")
        {
            StartCoroutine(Affect(attack));
        }

        knockback += new Vector3(-1, 1) * (attack.baseKnockback / knockbackResistance);
    }

    IEnumerator Affect(Damage attack)
    {
        if (attack.type == "Fire")
        {
            for (int i = 0; i < (effectTime * 2); i++)
            {
                health -= (attack.baseDamage / (effectTime * 2));
                yield return new WaitForSeconds(0.5f);
            }
        }
        else if (attack.type == "Poison")
        {
            for (int i = 0; i < (effectTime * 2); i++)
            {
                health -= (attack.baseDamage / (effectTime * 2));
                yield return new WaitForSeconds(0.5f);
            }
        }
        else if (attack.type == "Frost")
        {
            moveSpeed *= (3f / 4f);
            yield return new WaitForSeconds(effectTime / 2f);
        }
    }
}
