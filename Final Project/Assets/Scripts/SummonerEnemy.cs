using UnityEngine;
using System.Collections;

public class SummonerEnemy : BrandonsEnemyAI
{
    public Transform Minion;
    protected Object[] minions = new Object[4];
    protected bool recharging;

    protected override void Attack()
    {
        if (!recharging)
            StartCoroutine(Summon());
    }

    IEnumerator Summon()
    {
        recharging = true;

        for (int i = 0; i < minions.Length; i++ )
        {
            if (minions[i] == null)
            {
                if (player.transform.position.x > transform.position.x)
                    minions[i] = GameObject.Instantiate(Minion, transform.position + Vector3.right * 3, transform.rotation);
                else
                    minions[i] = GameObject.Instantiate(Minion, transform.position - Vector3.right * 3, transform.rotation);

                break;
            }
        }
        yield return new WaitForSeconds(3);
        recharging = false;

    }

    void OnDestroy()
    {
        foreach (Object minion in minions)
            if (minion != null)
                Destroy(((Transform)minion).gameObject);
    }
}
