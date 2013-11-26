using UnityEngine;
using System.Collections;

public class ShieldControl : Controllable {

    public CustomInput input;
    public Character player;

    protected bool wasUp, wasDown = true;

	void Start ()
    {
        animation["Up"].speed = -1;
        if (input == null)
        {
            input = GetInput(gameObject);
        }
        if (player == null)
        {
            player = GetCharacter(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (input.GetDown(input.fire2))
        {
            if (animation["Up"].time < 0)
                animation["Up"].time = 0;
            animation["Up"].speed = 1;
        }
        else if (input.GetUp(input.fire2))
        {
            if (animation["Up"].time > animation["Up"].length)
                animation["Up"].time = animation["Up"].length;
            animation["Up"].speed = -1;
        }
        animation.Play("Up");

        if (animation["Up"].time >= animation["Up"].length)
        {
            wasDown = false;
            if (!wasUp)
            {
                wasUp = true;
                player.physicalResistance *= 2;
            }
        }
        else if (!wasDown)
        {
            wasUp = false;
            wasDown = true;
            player.physicalResistance /= 2;
        }

	}

    Character GetCharacter(GameObject pGameObject)
    {
        Character temp = pGameObject.GetComponent<Character>();
        if (temp == null)
        {
            if (pGameObject.transform.parent.gameObject != null)
                return GetCharacter(pGameObject.transform.parent.gameObject);
            else
                return null;
        }
        else
            return temp;
        
    }
}
