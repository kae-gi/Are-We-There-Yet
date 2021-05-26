using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // NOT working currently
    public GameObject player;
    public Canvas winCanvas;
    public Canvas gameOverCanvas;
    public Canvas hudCanvas;

    bool gameOver;

    void Update()
    {
        //if (player.GetComponent<PotentialMove>().curHealth <= 0.0f)
       // {
        //    gameOver = true;
        //    Scene scene = SceneManager.GetActiveScene();
       //     SceneManager.LoadScene(scene.name);
       // }

        if (gameOver)
        {
            winCanvas.enabled = false;
            gameOverCanvas.enabled = true;
            hudCanvas.enabled = false;
            SceneManager.LoadScene(0);
        }
        else
        {
            winCanvas.enabled = false;
            gameOverCanvas.enabled = false;
            hudCanvas.enabled = true;
        }

    }
}