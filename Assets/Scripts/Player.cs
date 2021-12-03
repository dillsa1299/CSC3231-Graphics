using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    This script is used to contain the players data and control how they
    interact with objects
*/

public class Player : MonoBehaviour
{
    public Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.H))
        {
            Teleport(startPos);
        }
    }

    public void Teleport (Vector3 location) //Teleports player to location passed to method
    {
        transform.position = location;
    }
}
