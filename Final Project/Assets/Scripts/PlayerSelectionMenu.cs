using UnityEngine;
using System.Collections;

public class PlayerSelectionMenu : Menu
{
    protected override void select(int selection)
    {
        if (selection == 0)
        {
            foreach (CharacterSelection nextMenu in gameObject.GetComponents<CharacterSelection>())
            {
                if (nextMenu.PlayerNumber == 1)
                    nextMenu.enabled = true;
            }
            this.enabled = false;
        }
        else
        {
            /*
            foreach (CharacterSelection nextMenu in gameObject.GetComponents<CharacterSelection>())
            {
                nextMenu.enabled = true;
            }
            */

            Debug.Log("Multiplayer not implemented yet");
        }

    }
}
