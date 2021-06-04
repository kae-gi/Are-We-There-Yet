using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextPop : MonoBehaviour
{
    public GameObject player;
    public GameObject check;
    public bool last;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            check.SetActive(true);
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            check.SetActive(false);
        }
        if (last)
        {
            Invoke("EndScene",15);
        }
    }
    void EndScene()
    {
        SceneManager.LoadScene(0);
    }
}