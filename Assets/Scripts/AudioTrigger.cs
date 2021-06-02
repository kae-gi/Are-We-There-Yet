using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{

    public GameObject player;
    public AudioSource sound;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            if (sound) 
            {
                sound.Play();
            }
        }
    }
}
