using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour 
{
    public HUDTextures textures;
    public int playerNumber;

    protected CharacterControl playerCharacter;
    protected float baseHealth, baseStamina;
    protected Rect viewport;
    protected int quadrant;
    protected bool initialized;


	void Start () 
    {
        
	}
	

	void Update ()
    {
        if (!initialized)
        {
            if (textures == null)
                textures = gameObject.GetComponent<HUDTextures>();
            playerCharacter = gameObject.GetComponent<CharacterControl>();
            baseHealth = playerCharacter.health;
            baseStamina = playerCharacter.stamina;

            switch (InputController.PlayerCount)
            {
                case 1:
                    quadrant = 7;
                    break;
                case 2:
                    quadrant = (playerNumber == 1) ? 5 : 6;
                    break;
                case 3:
                case 4:
                    quadrant = playerNumber;
                    break;

            }
            
            
            initialized = true;
        }
        switch (quadrant)
        {
            case 1:
                viewport = new Rect(0, 0, Screen.width / 2f, Screen.height / 2f);
                break;
            case 2:
                viewport = new Rect(Screen.width / 2, 0, Screen.width / 2f, Screen.height / 2f);
                break;
            case 3:
                viewport = new Rect(0, Screen.height / 2f, Screen.width / 2f, Screen.height / 2f);
                break;
            case 4:
                viewport = new Rect(Screen.width / 2f, Screen.height / 2f, Screen.width / 2f, Screen.height / 2f);
                break;
            case 5:
                viewport = new Rect(0, 0, Screen.width, Screen.height / 2f);
                break;
            case 6:
                viewport = new Rect(0, Screen.height / 2f, Screen.width, Screen.height / 2f);
                break;
            case 7:
                viewport = new Rect(0, 0, Screen.width, Screen.height);
                break;
        }
    }

    void OnGUI()
    {
        if (initialized)
        {
            if (!playerCharacter.Paused && playerCharacter.health > 0)
            {
                GUI.DrawTexture(new Rect(viewport.xMin + 5f, viewport.yMax - 15f, 100 * (playerCharacter.health / baseHealth), 5f), textures.healthTex);
                GUI.DrawTexture(new Rect(viewport.xMin + 5f, viewport.yMax - 10f, 100 * (playerCharacter.stamina / baseStamina), 5f), textures.staminaTex);
            }
            if (playerCharacter.Paused)
                GUI.Label(new Rect(viewport.xMin + viewport.width / 3, viewport.yMin + viewport.height / 2, viewport.width / 3f, 24f), "Player " + playerNumber);
        }
    }
}
