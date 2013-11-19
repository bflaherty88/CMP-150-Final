using UnityEngine;
using System.Collections;
using System;

/*
public static class Extensions
{
    public static bool Has<T>(this Enum type, T value)
    {
        try
        {
            return (((int)(object)type & (int)(object)value) == (int)(object)value);
        }
        catch
        {
            return false;
        }
    }
}

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 10,
                 attackDistanceStart = 10,
                 attackDistanceStop = 20;
    private bool directionChange = true;
    public GameObject drawObject;
    private CharacterController controller;

    CollisionFlags prevFlags;
    GameObject[] players;

    // Use this for initialization
    void Start()
    {

        players = GameObject.FindGameObjectsWithTag("Players");

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVec = Vector3.zero;
        foreach (GameObject player in players)
            if (player.transform.position.x < (transform.position.x + attackDistanceStart))
                transform.LookAt(transform.position - Vector3.forward);


        /*if (directionChange)
        {
            moveVec.x += moveSpeed * Time.deltaTime;
            drawObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (!directionChange)
        {
            moveVec.x -= moveSpeed * Time.deltaTime;
            drawObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (prevFlags.Has(CollisionFlags.Sides))
        {
            directionChange = !directionChange;
        }

        
        if (controller.collisionFlags == CollisionFlags.Sides)
        {
            transform.Rotate(0, 180, 0);
            transform.position += Vector3.forward;
        }


    }

}

*/