using UnityEngine;
using System.Collections;

public class AIBow : Weapon 
{
    public Transform arrow;
    public Transform player;
    public GameObject bow;

    protected bool firing, releasing;
    protected GameObject tempArrow;

    void Start()
    {

        leftDamage = new Damage(baseDamage, attackType, new Vector3(baseKnockback, baseKnockback));
        rightDamage = new Damage(baseDamage, attackType, new Vector3(-baseKnockback, baseKnockback));
    }

    void Update()
    {
        if (player != null)
            transform.LookAt(player.position);

        if (firing && !releasing && !bow.animation["Draw"].enabled)
            StartCoroutine(Release());
    }

    public void draw()
    {
        if (!firing)
        {
            firing = true;
            tempArrow = ((Transform)Instantiate(arrow, bow.transform.position, transform.rotation)).gameObject;
            tempArrow.transform.parent = bow.transform;
            bow.animation.Play("Draw");
            tempArrow.BroadcastMessage("Draw");
        }
    }

    IEnumerator Release()
    {
        releasing = true;
        bow.animation.Play("Release");
        tempArrow.BroadcastMessage("Release");
        yield return new WaitForSeconds(0.5f);
        firing = false;
        releasing = false;
    }
}
