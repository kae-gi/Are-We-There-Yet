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

    public void ButtonStart()
    {
        SceneManager.LoadScene(1);
    }

    public void StoreStart()
    {
        SceneManager.LoadScene(2);
    }
}
