using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateConstant : MonoBehaviour
{
    public int RotateDegreesPerSecond = 50;

    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, RotateDegreesPerSecond * Time.deltaTime);
    }
}
