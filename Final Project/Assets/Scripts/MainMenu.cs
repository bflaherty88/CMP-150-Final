using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{

    Texture[] content;
    public Texture[] baseTextures;
    public Texture[] activeTextures;
    public float offset, scale = 1500;

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
        oldPos = Input.mousePosition;
	}


    void Update() 
    {
        newPos = Input.mousePosition;
        mouseMode = newPos != oldPos;
        /*
        if (Input.GetKey(KeyCode.Return))
            content[selected] = activeTextures[selected];
        else
            content[selected] = baseTextures[selected];
        */

        if (Input.GetKeyDown(KeyCode.DownArrow) && selected < content.Length - 1 && !Input.GetKey(KeyCode.Return))
        {
            selected++;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && selected > 0 && !Input.GetKey(KeyCode.Return))
        {
            selected--;
        }

        if (!InputController.controllerMode)
        {
            if (mouseMode)
                for (int i = 0; i < elementRects.Length; i++)
                {
                    selected = elementRects[i].Contains(current.mousePosition) ? i : selected;
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
