using UnityEngine;
using System.Collections;

public class RangedEnemy : BrandonsEnemyAI
{

    public AIBow bow;

    protected override void Attack()
    {
        if (bow == null)
            bow = GetComponentInChildren<AIBow>();
        bow.player = player.transform;
        bow.draw();
    }
	
}
