using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune : MonoBehaviour
{
    public float offset = 0;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Vector3 pos = transform.position;
        transform.position = pos;
        transform.Rotate(time/10, time/10, 0);
    }
}
