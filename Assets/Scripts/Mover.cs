using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    void Update()
    {
        transform.Translate(0, 0, -20 * Time.deltaTime);
    }
}
