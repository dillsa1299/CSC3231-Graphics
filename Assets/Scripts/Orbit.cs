 using UnityEngine;
 using System.Collections;
 
 /*
    Script contains modified code from:
    https://www.youtube.com/watch?v=En7iugIoG_A&ab_channel=RenaissanceCoders
*/

 public class Orbit : MonoBehaviour 
 {
     public float spread1;
     public float spread2;
     public float offset;
     public Transform centerPoint;

     public float orbitSpeed;
     public bool orbitY;
     public bool orbitZ;
     public bool orbitX;

     public float timer = 0;
     
     void Update () 
     {
        timer += Time.deltaTime * orbitSpeed;
        if (orbitZ)
        {
            RotateZ();
        }
        if (orbitY)
        {
            RotateY();
        }
        if (orbitX)
        {
            RotateX();
        }
        transform.LookAt(centerPoint);
     }

     void RotateY()
     {
        float x = -Mathf.Cos(timer) * spread1;
        float z = Mathf.Sin(timer) * spread2;
        Vector3 pos = new Vector3(x, offset, z);
        transform.position = pos + centerPoint.position;
     }
     void RotateZ()
     {
        float x = -Mathf.Cos(timer) * spread1;
        float y = Mathf.Sin(timer) * spread2;
        Vector3 pos = new Vector3(x, y, offset);
        transform.position = pos + centerPoint.position;
     }
     void RotateX()
     {
        float z = -Mathf.Cos(timer) * spread1;
        float y = Mathf.Sin(timer) * spread2;
        Vector3 pos = new Vector3(offset, y, z);
        transform.position = pos + centerPoint.position;
     }
 }