using UnityEngine;
using System.Collections;

public class WorldControl : MonoBehaviour 
{
    protected bool done, finishing, finished, dead;
    public Texture endTexture;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!finished)
        {
            done = true;
            for (int i = 0; i < InputController.PlayerCount; i++)
                done = CharacterControl.completed[i] ? done : false;

            if (done)
                StartCoroutine(FinishLevel());
            dead = true;
            for (int i = 0; i < InputController.PlayerCount; i++)
            {
                dead = !CharacterControl.dead[i] ? false : dead;
            }
            finished = dead;
            if (dead)
                Time.timeScale = 0;


        }
	}

    IEnumerator FinishLevel()
    {
        if (!finishing)
        {
            yield return new WaitForSeconds(3);
            finished = true;
            finishing = false;
            Time.timeScale = 0;
        }

    }

    void OnGUI()
    {
        if (finished)
            GUI.DrawTexture(new Rect(Screen.width / 2 - endTexture.width / 2, Screen.height / 2 - endTexture.height / 2, endTexture.width, endTexture.height), endTexture);
    }
}
