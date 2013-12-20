using UnityEngine;
using System.Collections;

public class CharacterSelection : Menu
{
    public Texture readyTexture;

    protected Texture[] baseTemp, activeTemp;
    protected bool ready;
    protected float tempOffset;

    protected override void select(int selected)
    {
        if (!ready)
        {
            InputController.playerCharacters[playerNumber - 1] = selected;
            base.selected = 0;
            base.selectedL = 0;
            ready = true;
            baseTemp = baseTextures;
            activeTemp = activeTextures;
            baseTextures = new Texture[] { readyTexture };
            content = baseTextures;
            activeTextures = baseTextures;
            elementRects = new Rect[content.Length];
            tempOffset = offset;
            offset = 0;
        }


    }

    protected void GoBack()
    {
        if (!ready)
        {
            Disable(gameObject);
        }
        else
        {
            baseTextures = baseTemp;
            activeTextures = activeTemp;
            offset = tempOffset;
            ready = false;
            base.OnEnable();
        }
    }

    protected static void Disable(GameObject gameObject)
    {
        foreach (CharacterSelection menu in gameObject.GetComponents<CharacterSelection>())
            menu.enabled = false;
        foreach (CustomInput input in gameObject.GetComponents<CustomInput>())
            if (input.playerNumber != 1)
                input.enabled = false;
        gameObject.GetComponent<PlayerSelectionMenu>().enabled = true;
    }

    new protected void Update()
    {
        base.Update();

        if (input.GetDown(input.back))
            GoBack();

        if (input.GetDown(input.activate) && ready && playerNumber == 1)
        {
            InputController.PlayerCount = 0;
            Application.LoadLevel("Level 1");
        }
    }
}
