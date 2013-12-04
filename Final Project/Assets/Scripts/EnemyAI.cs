using UnityEngine;
using System.Collections;
using System;

public class EnemyAI : Character
{
 
    private CharacterController controller;
    public string pathName;
    public float travelTime = 5;

    GameObject[] players;

    // Use this for initialization
    void Start()
    {

        players = GameObject.FindGameObjectsWithTag("Player");
        
        //itween
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(pathName), "time", travelTime, "easeType", iTween.EaseType.linear.ToString(), "looptype", iTween.LoopType.pingPong, "orienttopath", true, "axis","y", "oncomplete", "turnAround"));


    }

    void turnAround()
    {
        Debug.Log("turned around");
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject player in players)
        {
            if (player.transform.position.x < transform.position.x)
            {
                Debug.Log("Look");
                transform.LookAt(transform.position - Vector3.forward);
            }
            else
                transform.LookAt(transform.position + Vector3.forward);
        }

       
    }

}