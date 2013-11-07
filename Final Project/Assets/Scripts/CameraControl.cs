using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class CameraControl : MonoBehaviour 
{
    public GameObject player;
    public float keyhole, moveSpeed;
    public int playerNum;
	
	void Start () 
    {
        
	}
	
	
	void Update () 
    {
        //camera.rect: (left, bottom, width, height)
        switch (InputController.PlayerCount)
        {
            case 1:
                gameObject.camera.rect = new Rect(0, 0, 1, 1);
                break;
            case 2:
                gameObject.camera.rect = (playerNum == 1) ? new Rect(0f, 0.5f, 1f, 0.5f) : new Rect(0f, 0f, 1f, 0.5f);
                break;
            case 3:
            case 4:
                gameObject.camera.rect = (playerNum < 3) ? new Rect((playerNum == 1) ? 0f : 0.5f, 0.5f, 0.5f, 0.5f) : new Rect((playerNum == 3) ? 0f : 0.5f, 0f, 0.5f, 0.5f);
                break;
        }
        
        if (transform.position.x > player.transform.position.x + keyhole)
            transform.Translate(-Vector3.right * moveSpeed * Time.deltaTime);
        else if (transform.position.x < player.transform.position.x - keyhole)
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        if (transform.position.y > player.transform.position.y + keyhole)
            transform.Translate(-Vector3.up * moveSpeed * Time.deltaTime);
        else if (transform.position.y < player.transform.position.y - keyhole)
            transform.Translate(-Vector3.up * moveSpeed * Time.deltaTime);
	}
}
