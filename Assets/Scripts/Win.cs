using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public GameObject player;
    public Canvas winCanvas;
    public Canvas hudCanvas;

    bool win;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            win = true;
        }
    }

    void Update()
    {
        if (win)
        {
            winCanvas.enabled = true;
            hudCanvas.enabled = false;
        }
        else
        {
            winCanvas.enabled = false;
            hudCanvas.enabled = true;
        }

    }
}