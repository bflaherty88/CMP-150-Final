using UnityEngine;
using System.Collections;

public class CharacterSelection : Menu
{
    /*
    protected Rect viewport;
    public int PlayerNumber;
    public Texture[] baseTextures, activeTextures;

    protected int playerNumber;
    protected bool active;
    protected Texture[] content;


	// Use this for initialization
	void Start () 
    {
        playerNumber = PlayerNumber;

        if (InputController.PlayerCount == 1)
            viewport = new Rect(0, 0, Screen.width, Screen.height);
        else
        {
            switch (playerNumber)
            {
                case 1:
                    viewport = new Rect(0, 0, Screen.width / 2, Screen.height);
                    break;
                case 2:
                    viewport = new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height);
                    break;
                case 3:
                    viewport = new Rect(0, Screen.height / 2, Screen.width / 2, Screen.height);
                    break;
                case 4:
                    viewport = new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height);
                    break;
            }
        }

        content = new Texture[baseTextures.Length];
        for (int i = 0; i < baseTextures.Length; i++)
            content[i] = baseTextures[i];
	}

    // Update is called once per frame
    void Update() 
    {
	
	}

    void OnGUI()
    {
        for (int i = 0; i < content.Length; i++)
        {
            elementRects[i] = new Rect((Screen.width / 2) - (content[i].width * Screen.width) / scale, (Screen.height / 2) - (content[i].height * Screen.width) / scale + ((content[i].height * Screen.width) / (scale / 2)) * i - offset, (content[i].width * Screen.width) / (scale / 2), (content[i].height * Screen.width) / (scale / 2));
            GUI.DrawTexture(elementRects[i], content[i]);
        }
         * 
        
    }
     * */
    protected override void select(int selected)
    {
        Debug.Log("Selected: " + selected);
    }
}
