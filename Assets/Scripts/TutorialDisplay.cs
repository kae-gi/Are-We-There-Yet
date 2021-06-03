using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialDisplay : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI tutorialText;
    public TextMeshProUGUI coinText;
    public GameObject gui;

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
        else if (player.transform.position.z < -75){
            gui.SetActive(true);
            tutorialText.text = "Use your jump to get over gaps";
        }
    }

}
