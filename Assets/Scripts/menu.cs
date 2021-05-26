using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject car;

    private void Start()
    {
        car.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = GlobalData.carColor;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadCity()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadSpace()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadDesert()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadStore()
    {
        SceneManager.LoadScene(2);
    }

    
}
