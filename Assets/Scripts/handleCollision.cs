using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HandleCollision : MonoBehaviour
{
    public Transform player;
    public AudioSource crashSound;

    // collisionHitAmount is how much the health should be reduced by per collision with
    // a specific game object. The initial health starts at 1.0f and the level will restart
    // when the remaining health goes <= 0.0f. This can be adjusted for each unique game object
    public float collisionHitAmount = -0.3f; 

    void OnCollisionEnter(Collision other)
	{
        if (other.transform == player)
		{
            if (crashSound)
            {
                crashSound.Play();
            }
            player.GetComponent<PotentialMove>().changeHealthAmount(collisionHitAmount);

            // restart the level if the current health goes down to 0.0f. Starts with 1.0f at beginning
            if (player.GetComponent<PotentialMove>().curHealth <= 0.0f)
            {
			    SceneManager.LoadScene(0);
            }
        }
    }
}
