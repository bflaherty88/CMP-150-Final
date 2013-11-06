using UnityEngine;
using System.Collections;

public abstract class ControllerInput : MonoBehaviour
{
    
    public bool IsActive
    {
        get { return isActive; }
    }
    protected bool isActive = false;
	
}
