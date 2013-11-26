using UnityEngine;
using System.Collections;
using System;

public class EnemyAI : Character
{
 
    private CharacterController controller;

    GameObject[] players;

    // Use this for initialization
    void Start()
    {

        players = GameObject.FindGameObjectsWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVec = Vector3.zero;
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