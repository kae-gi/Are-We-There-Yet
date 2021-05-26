using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertBoat : MonoBehaviour
{
    public Transform player;
    private bool shouldMove = false;
    private Vector3 startLocation;
    private float maxHorizontalSpeed = 0.2f;
    private float horizontalSpeed = 0.0f;

    void Start()
    {
        startLocation = transform.position;
    }

    void FixedUpdate()
    {
        // wait until the player touches the boat to move
        if (shouldMove)
        {
            transform.position = new Vector3(transform.position.x + horizontalSpeed, transform.position.y, player.transform.position.z);

            float diff = transform.position.z - startLocation.z;
            if (diff > 90.0f)
            {
                horizontalSpeed = -maxHorizontalSpeed;
            }
            if (diff > 160.0f)
            {
                horizontalSpeed = 0.0f;
            }
            if (diff > 200.0f)
            {
                horizontalSpeed = maxHorizontalSpeed;
            }
            if (diff > 260.0f)
            {
                horizontalSpeed = 0.0f;
            }
            if (diff > 300.0f)
            {
                shouldMove = false;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        print("Collided");
        if (other.transform == player)
        {
            shouldMove = true;
        }
    }
}
