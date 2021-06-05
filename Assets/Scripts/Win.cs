using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public GameObject player;
    public GameObject effect;
    public Canvas winCanvas;
    public Canvas gameOverCanvas;
    public Canvas hudCanvas;
    public AudioSource deathSound;

    private Rigidbody playerRB;
    private float gas;
    private float health;

    bool win;
    bool lose;


    void Start()
    {
        playerRB = player.GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            win = true; // level complete triggered
            player.GetComponent<PotentialMove>().reduceGasPerUpdateFactor = 0; // gas does not empty upon completion of level
            // stop player from moving
            playerRB.isKinematic = true; 
            playerRB.velocity = Vector3.zero;
        }
    }

    void Update()
    {
        if (!player)
        {
            return;
        }
        // check status of health and gas
        gas = player.GetComponent<PotentialMove>().curGasAmount;
        health = player.GetComponent<PotentialMove>().curHealth;
        if (gas <= 0.0f || health <= 0.0f)
        {
            lose = true;
            // Get player's last location
            Vector3 lastLoc = player.transform.position;
            // Destroy the player gameobject on game over
            Destroy(player);
            // Play death effect after player is destroyed and then destroy the effect
            deathSound.Play();
            GameObject deathEffect = Instantiate(effect, lastLoc, Quaternion.identity);
            Destroy(deathEffect, 2);
        }
        // canvas enabling/disabling
        if (win)
        {
            winCanvas.enabled = true;
            gameOverCanvas.enabled = false;
            hudCanvas.enabled = false;
        }
        if (lose)
        {
            winCanvas.enabled = false;
            gameOverCanvas.enabled = true;
            hudCanvas.enabled = false;
        }
        if(!lose && !win)
        {
            winCanvas.enabled = false;
            gameOverCanvas.enabled = false;
            hudCanvas.enabled = true;
        }
    }
}