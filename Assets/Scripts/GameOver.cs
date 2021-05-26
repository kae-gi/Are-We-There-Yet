using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadCurrent()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void LoadStore()
    {
        SceneManager.LoadScene(2);
    }
}
