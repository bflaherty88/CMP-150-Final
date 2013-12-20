using UnityEngine;
using System.Collections;

public class SummonerEnemy : BrandonsEnemyAI
{
    public Transform Minion;
    public float fleeDistance;
    protected Object[] minions = new Object[4];
    protected bool recharging;

    protected void Update()
    {
        base.Update();

        if (player != null)
            if (Mathf.Abs(player.transform.position.x - transform.position.x) < fleeDistance)
                moveSpeed += acceleration * (player.transform.position.x < transform.position.x ? 1 : -1);
    }

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
