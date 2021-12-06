using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchRock : MonoBehaviour
{
    void launch()
    {
        GetComponent<ParabolaController>().FollowParabola();
    }
}
