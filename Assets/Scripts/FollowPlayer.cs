using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(0, 5, -7);

    // Update is called once per frame
    void Update()
    {
        if (player) // only run if the player object is not destroyed
        {
            transform.position = player.transform.position + offset;
        }
    }
}
