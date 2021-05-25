using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienEnemy : MonoBehaviour
{
    public float frequency = 0f; // speed
    public float magnitude = 0f; // distance
    public float offset = 0f; // shift position

    private Vector3 startPos;

    GameObject Laser;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // movement
        transform.position = startPos + transform.forward * Mathf.Sin(Time.time * frequency + offset) * magnitude;        
    }

    //    void OnTriggerEnter(Collider collider)
    //    {
    //        if (collider.gameObject.CompareTag("Laser")) {
    //            Destroy(this.gameObject);
    //        }
    //    }
}
