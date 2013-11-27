using UnityEngine;
using System.Collections;

public class Controllable : MonoBehaviour {

    protected CustomInput GetInput(GameObject pGameObject)
    {
        CustomInput temp = pGameObject.GetComponent<CustomInput>();
        if (temp == null)
        {
            if (pGameObject.transform.parent.gameObject != null)
                return GetInput(pGameObject.transform.parent.gameObject);
            else
                return null;
        }

        else
            return temp;
    }
}
