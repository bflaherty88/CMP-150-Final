using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{
    protected Texture[] content;
    public Texture[] baseTextures;
    public Texture[] activeTextures;
    public float offset, Scale = 1500;
    public CustomInput input;
    public int PlayerNumber;

    protected int playerNumber;
    protected Rect viewport;
    protected bool mouseMode, initialized;
    protected int selected, selectedL;
    protected float oldWidth, scale;
    protected Rect[] elementRects;
    Vector2 oldPos, newPos;
    Event current;

	protected void OnEnable () 
    {
        initialized = false;
        oldWidth = 0;
        playerNumber = PlayerNumber;

        if (input == null)
        {
            foreach (CustomInput customInput in gameObject.GetComponents<CustomInput>())
            {
                if (customInput.playerNumber == playerNumber)
                {
                    input = customInput;
                    break;
                }
            }

        }
        input.enabled = true;

        content = new Texture[baseTextures.Length];
        for (int i = 0; i < baseTextures.Length; i++)
            content[i] = baseTextures[i];
        content[selected] = activeTextures[selected];
        elementRects = new Rect[content.Length];
        
	}


    protected void Update() 
    {
        if (Screen.width != oldWidth)
        {
            initialized = true;
            if (InputController.PlayerCount == 1)
            {
                scale = Scale;
                viewport = new Rect(0, 0, Screen.width, Screen.height);
            }
            else
            {
                scale = Scale / 2;
                switch (playerNumber)
                {
                    case 1:
                        viewport = new Rect(0, 0, Screen.width / 2, Screen.height / 2);
                        break;
                    case 2:
                        viewport = new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height / 2);
                        break;
                    case 3:
                        viewport = new Rect(0, Screen.height / 2, Screen.width / 2, Screen.height / 2);
                        break;
                    case 4:
                        viewport = new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height / 2);
                        break;
                }
            }
            oldWidth = Screen.width;

        }

        if (!InputController.controllerMode)
        {
            newPos = Input.mousePosition;
            mouseMode = newPos != oldPos;
        }
        else
            mouseMode = false;

        if (input.GetDown(input.activate) || input.GetDown(input.fire1) || input.GetDown(input.jump))
        {
            select(selected);
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
        if (initialized)
        {
            current = Event.current;
            for (int i = 0; i < content.Length; i++)
            {
                elementRects[i] = new Rect(viewport.center.x - (content[i].width * viewport.width) / scale, viewport.center.y - (content[i].height * viewport.width) / scale + ((content[i].height * viewport.width) / (scale / 3)) * i - offset, (content[i].width * viewport.width) / (scale / 2), (content[i].height * viewport.width) / (scale / 2));
                GUI.DrawTexture(elementRects[i], content[i]);
            }
        }
    }

    protected virtual void select(int selection)
    {
        Debug.LogError("Don't instantiate Menu class");
    }
}
