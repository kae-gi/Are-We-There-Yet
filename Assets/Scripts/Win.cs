using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public GameObject player;
    public Canvas winCanvas;
    public Canvas gameOverCanvas;
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
        Debug.Log(win);
        if (win)
        {
            winCanvas.enabled = true;
            gameOverCanvas.enabled = false;
            hudCanvas.enabled = false;

        }
        else
        {
            winCanvas.enabled = false;
            gameOverCanvas.enabled = false;
            hudCanvas.enabled = true;
        }

    }
}