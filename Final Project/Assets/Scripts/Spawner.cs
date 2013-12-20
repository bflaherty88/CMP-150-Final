using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public Transform[] characterPrefabs;
    public int playerNumber;

    protected GameObject player;


	void Start () 
    {
        if (InputController.playerCharacters[playerNumber - 1] != -1)
        {
            player = ((Transform)GameObject.Instantiate(characterPrefabs[InputController.playerCharacters[playerNumber - 1]], transform.position + Vector3.up, transform.rotation)).gameObject;

            player.GetComponentInChildren<CustomInput>().playerNumber = playerNumber;
        }
        Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
