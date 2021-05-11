using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLaser : MonoBehaviour
{
    public float speed = 80f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
