using UnityEngine;
using System.Collections;

public class MeleeEnemy : BrandonsEnemyAI {

    public AISword sword;

    protected override void Attack()
    {
        if (sword == null)
            sword = GetComponentInChildren<AISword>();
        sword.swing();
    }
}
