using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float height = 0.5f;
    Vector3 InitialPos;
    Vector3 TempPos;

    void Start()
    {
        InitialPos = transform.position;
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
        TempPos = InitialPos;
        TempPos.y += Mathf.Sin(Time.fixedTime * 2f) * 0.25f;
        transform.position = TempPos;
    }
}
