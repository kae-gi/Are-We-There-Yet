using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject boost;
    public Vector3 offset = new Vector3(0, 5, -7);

    // Update is called once per frame
    void Update()
    {
        if (player) // only run if the player object is not destroyed
        {
            transform.position = player.transform.position + offset;
            if (player.GetComponent<PotentialMove>().isAccelerating)
            {
                // for boost FX
                Vector3 offset = new Vector3(0, -2f, 15); // move location of boostFX
                // Quaternion.Euler(180, 0, 90) -> lock rotation of boostFX
                GameObject boostFX = Instantiate(boost, transform.position+offset, Quaternion.Euler(190, 0, 90));
                Destroy(boostFX, 0.1f);
            }
        }
    }
}
