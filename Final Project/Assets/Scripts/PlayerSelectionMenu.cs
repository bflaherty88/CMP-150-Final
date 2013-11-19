using UnityEngine;
using System.Collections;

public class PlayerSelectionMenu : MonoBehaviour 
{

    Texture[] content;
    public Texture[] baseTextures;
    public Texture[] activeTextures;
    public float offset, scale = 1500;
    public CustomInput input;

    bool mouseMode;
    int selected, selectedL;
    Rect[] elementRects;
    Vector2 oldPos, newPos;
    Event current;

	void Start () 
    {
        content = new Texture[baseTextures.Length];
        for (int i = 0; i < baseTextures.Length; i++)
            content[i] = baseTextures[i];
        content[selected] = activeTextures[selected];
        elementRects = new Rect[baseTextures.Length];
        
	}


    void Update() 
    {
        newPos = Input.mousePosition;
        mouseMode = newPos != oldPos;

        if (input.GetDown(input.activate) || input.GetDown(input.fire1))
        {
            if (selected == 0)
                Debug.Log("Singleplayer");
            else
                Debug.Log("Multiplayer");
        }

        if (input.GetDown(input.down) && selected < content.Length - 1 && !input.GetDown(input.activate))
        {
            selected++;
        }
        else if (input.GetDown(input.up) && selected > 0 && !input.GetDown(input.activate))
        {
            selected--;
        }
        if (mouseMode)
        {
            if (current != null)
            {
                for (int i = 0; i < elementRects.Length; i++)
                {
                    selected = elementRects[i].Contains(current.mousePosition) ? i : selected;
                }
            }
        }

        if (selected != selectedL)
        {
            content[selectedL] = baseTextures[selectedL];
            content[selected] = activeTextures[selected];
            selectedL = selected;
        }
        oldPos = Input.mousePosition;
	}

    void OnGUI()
    {
        current = Event.current;
        for (int i = 0; i < content.Length; i++)
        {
            elementRects[i] = new Rect((Screen.width / 2) - (content[i].width * Screen.width) / scale, (Screen.height / 2) - (content[i].height * Screen.width) / scale + ((content[i].height * Screen.width) / (scale / 2)) * i - offset, (content[i].width * Screen.width) / (scale / 2), (content[i].height * Screen.width) / (scale / 2));
            GUI.DrawTexture(elementRects[i], content[i]);
        }
    }
}
