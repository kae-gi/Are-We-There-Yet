using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TutorialDisplay : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI tutorialText;
    public TextMeshProUGUI coinText;
    public GameObject gui;

    private PotentialMove playerMovement;

    void Start()
    {
        playerMovement = player.GetComponent<PotentialMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z < -400){
            gui.SetActive(false);
            tutorialText.text = "Welcome to Are We There Yet!";
        }
        else if (player.transform.position.z < -300){
            tutorialText.text = "Use A/D to move Left/Right";
        }
        else if (player.transform.position.z < -200){
            tutorialText.text = "Dodge obstacles to avoid damage to your car";
        }
        else if (player.transform.position.z < -150){
            tutorialText.text = "Press space to jump";
        }
        else if (player.transform.position.z < -50){
            tutorialText.text = "Use your jump to get over gaps";
        }
        else if (player.transform.position.z < 25){
            gui.SetActive(true);
            tutorialText.text = "This is the game's GUI";
            playerMovement.reduceGasPerUpdateFactor = -0.001f;
        }
        else if (player.transform.position.z < 100){
            tutorialText.text = "Collecting gas cans increases your gas bar";
        }
        else if (player.transform.position.z < 175){
            tutorialText.text = "Use left shift to burn gas faster and accelerate";
        }
        else if (player.transform.position.z < 275){
            tutorialText.text = "Be careful, if you run out of gas it's game over";
        }
        else if (player.transform.position.z < 350){
            tutorialText.text = "The coin counter at top left tracks the coins you collect";
        }
        else if (player.transform.position.z < 425){
            tutorialText.text = "You can use coins in the store on the main menu to buy upgrades";
        }
        else if (player.transform.position.z < 500){
            tutorialText.text = "The goal is to make it to the mechanic's at the end of the level";
        }
        else if (player.transform.position.z < 550){
            tutorialText.text = "To fix your brakes and accelerator, obviously";
        }
        else if (player.transform.position.z < 585){
            tutorialText.text = "That's all! Good luck!";
        }
        else {
            GlobalData.coinCount -= 16;
            SceneManager.LoadScene(0);
        }
    }

}
