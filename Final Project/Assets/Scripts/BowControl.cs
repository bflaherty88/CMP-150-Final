using UnityEngine;
using System.Collections;

public class BowControl : Weapon {

    public Transform arrow, specialArrow;
    public GameObject bow;
    public CustomInput input;

    protected bool firing1, firing2, released1, released2, fireDown1, fireDown2, fireUp1, fireUp2, wasDown1, wasDown2;
    protected GameObject tempArrow;

	void Start () 
    {
        if (input == null)
            input = GetInput(gameObject);
        leftDamage = new Damage(10, "Piercing", new Vector3(20f, 20f));
        rightDamage = new Damage(10, "Piercing", new Vector3(-20f, 20f));
	}
	
	// Update is called once per frame
	void Update () 
    {
        fireDown1 = input.GetDown(input.fire1);
        fireDown2 = input.GetDown(input.fire2);
        fireUp1 = input.GetUp(input.fire1);
        fireUp2 = input.GetUp(input.fire2);

        released1 = fireUp1 && firing1 ? true : released1;
        released2 = fireUp2 && firing2 ? true : released2;

        if (fireDown1 && !(firing1 || firing2))
            draw1();
        else if (fireDown2 && !(firing1 || firing2))
            draw2();

        if (released1 && !bow.animation["Draw"].enabled)
            release1();
        else if (released2 && !bow.animation["Draw"].enabled)
            release2();

	}

    void draw1()
    {
        firing1 = true;
        tempArrow = ((Transform)Instantiate(arrow, transform.position, transform.rotation)).gameObject;
        tempArrow.transform.parent = transform;
        bow.animation.Play("Draw");
        tempArrow.BroadcastMessage("Draw");
    }

    void draw2()
    {
        firing2 = true;
        tempArrow = ((Transform)Instantiate(specialArrow, transform.position, transform.rotation)).gameObject;
        tempArrow.transform.parent = transform;
        bow.animation.Play("Draw");
        tempArrow.BroadcastMessage("Draw");
    }

    void release1()
    {
        released1 = false;
        firing1 = false;
        bow.animation.Play("Release");
        tempArrow.BroadcastMessage("Release");
    }

    void release2()
    {
        released2 = false;
        firing2 = false;
        bow.animation.Play("Release");
        tempArrow.BroadcastMessage("Release");
    }
}
