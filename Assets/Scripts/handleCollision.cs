using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class handleCollision : MonoBehaviour
{
    public Transform player;

    void OnCollisionEnter(Collision other)
	{
        if (other.transform == player)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
