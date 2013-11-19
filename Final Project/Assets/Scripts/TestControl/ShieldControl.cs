using UnityEngine;
using System.Collections;

public class ShieldControl : MonoBehaviour {

    public CustomInput input;

	void Start ()
    {
        animation["Up"].speed = -1;
        if (input == null)
        {
            GetInput(gameObject);
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
	}

    void GetInput(GameObject gObject)
    {
        input = gObject.GetComponent<CustomInput>();
        if (input == null)
        {
            if (gObject.transform.parent.gameObject != null)
                GetInput(gObject.transform.parent.gameObject);
            else
                Debug.LogError("No CustomInput script on hierarchy.");
        }
    }
}
