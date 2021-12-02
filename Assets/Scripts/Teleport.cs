using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This script is used to teleport the player to the corresponding island when they collide with it
*/

public class Teleport : MonoBehaviour
{
    public Transform player;
    public Transform island;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Teleporting");
            player.transform.position = island.transform.position;

            /*
            I'm stuck with this bit. It doesn't work when I try to teleport the player to the teleport
            marker as shown above, but if I try
            
            island.transform.position = player.transform.position;

            The marker teleports to the player as expected, but does not work the other way around.
            
            I also have a keybind setup to teleport the player to their starting position by pressing H.
            This works exactly as intended.

            I have ran out of time to find a fix before submission, but will keep trying
            */
        }
    }
}
