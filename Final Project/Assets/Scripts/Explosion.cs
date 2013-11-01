using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        StartCoroutine(Countdown());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
