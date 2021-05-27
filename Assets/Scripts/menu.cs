using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject car;

    private void Start()
    {
        if (car)
        {
            car.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = GlobalData.carColor;
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadStore()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadCity()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadSpace()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadDesert()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
