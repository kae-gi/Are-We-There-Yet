using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public float loc = -20;
    public Vector3 return_pos = new Vector3(0f, -0.13f, 208f);
    void Update()
    {
        if (transform.position.z < loc){
            transform.position = return_pos;
        }
    }
}
