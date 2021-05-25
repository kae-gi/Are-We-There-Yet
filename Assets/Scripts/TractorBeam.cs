using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBeam : MonoBehaviour
{
    public Transform Mover;
    public Transform Target;
    public float speed;

    bool isInRange;

    void OnTriggerStay(Collider other)
    {
        if (other.transform == Mover)
        {
            isInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == Mover)
        {
            isInRange = false;
        }
    }

    void Update()
    {
        if (isInRange)
        {
            Mover.position = Vector3.MoveTowards(Mover.position, Target.position, speed * Time.deltaTime);
        }
    }
}