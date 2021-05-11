using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float xSpeed = 0;
    public float ySpeed = 0;
    public float zSpeed = 0;

    GameObject Laser;

    void Update()
    {
        // movement
        transform.Translate(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, zSpeed * Time.deltaTime);
    }

//    void OnTriggerEnter(Collider collider)
//    {
//        if (collider.gameObject.CompareTag("Laser")) {
//            Destroy(this.gameObject);
//        }
//    }
}
