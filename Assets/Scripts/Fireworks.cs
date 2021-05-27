using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireworks : MonoBehaviour
{
    public GameObject player;
    public GameObject lightMain;
    public GameObject explosion;
    public float fadeSpeed = 0.5f;
    private Light sceneLight;
    private ParticleSystem fireworks;
    private float targetIntensity = 0f;
    bool lightsOff;

    void Start()
    {
        sceneLight = lightMain.GetComponent<Light>();
        fireworks = explosion.GetComponent<ParticleSystem>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            lightsOff = true;   
            Debug.Log("Hit the lights");
        }
    }

    void Update()
    {
        if (lightsOff)
        {
            sceneLight.intensity = Mathf.Lerp(sceneLight.intensity, targetIntensity, fadeSpeed*Time.deltaTime);
            if (sceneLight.intensity <= 0.2f){
                fireworks.Play();
            } else
            {
                fireworks.Stop();
            }
        }
    }

}
