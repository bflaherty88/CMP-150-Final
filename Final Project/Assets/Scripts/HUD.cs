using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour 
{
    public GameObject player;
    public Texture healthTex;
    public Texture staminaTex;
    public int playerNumber;

    protected bool paused;
    protected Character playerCharacter;
    protected float baseHealth, baseStamina;
    protected float screenBottom, screenLeft;
    protected int quadrant;


	void Start () 
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");

        playerCharacter = player.GetComponent<Character>();
        healthTex = player.GetComponent<HUDTextures>().healthTex;
        staminaTex = player.GetComponent<HUDTextures>().staminaTex;
        baseHealth = playerCharacter.health;
        baseStamina = playerCharacter.stamina;

        switch (InputController.PlayerCount)
        {
            case 1:
                quadrant = 3;
                break;
            case 2:
                quadrant = (playerNumber == 1) ? 1 : 3;
                break;
            case 3:
            case 4:
                quadrant = playerNumber;
                break;

        }

        if (quadrant == 1 || quadrant == 2)
            screenBottom = Screen.height / 2;
        else if (quadrant == 3 || quadrant == 4)
            screenBottom = Screen.height;

        if (quadrant == 1 || quadrant == 3)
            screenLeft = 0;
        else if (quadrant == 2 || quadrant == 4)
            screenLeft = Screen.width / 2;
	}
	

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            pause();

    }

    void OnGUI()
    {
        if (!paused && playerCharacter.health > 0)
            GUI.DrawTexture(new Rect(screenLeft + 5f, screenBottom - 15f, 100 * (playerCharacter.health / baseHealth), 5f), healthTex);
        GUI.DrawTexture(new Rect(screenLeft + 5f, screenBottom - 10f, 100 * (playerCharacter.stamina / baseStamina), 5f), staminaTex);
    }

    void pause()
    {
        if (!paused)
        {
            Time.timeScale = 0f;
            paused = true;
        }
        else
        {
            Time.timeScale = 1f;
            paused = false;
        }
    }
}
