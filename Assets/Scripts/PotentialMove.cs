using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PotentialMove : MonoBehaviour
{
    private float horizontalInput;
    private float steerAngle;
    private float speed;
    private bool isGrounded;
    private bool isAccelerating = false;
    private Rigidbody rb;

    public WheelCollider[] wheelColliders = new WheelCollider[4];
    public float maxSteerAngle = 30;
    public float baseSpeed = 25;
    public float maxSpeed = 40;
    public float jumpVelocity = 5;
    public float timeRemaining = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Input
        horizontalInput = Input.GetAxis("Horizontal"); // for moving side to side 
        // steering
        steerAngle = maxSteerAngle * horizontalInput;
        transform.Translate(Vector3.right * Time.deltaTime * steerAngle);
        // acceleration controls
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isAccelerating = true;
        }
        if (isAccelerating && timeRemaining > 0)
        {
            isAccelerating = true;
            speed = maxSpeed;
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            isAccelerating = false;
            speed = baseSpeed;
        }
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        // jumping
        isGrounded = true;
        for (int i = 0; i < 4; i++)
        {
            if (!wheelColliders[i].isGrounded)
            {
                isGrounded = false;
            }
        }
        if (Input.GetButton("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpVelocity, ForceMode.VelocityChange);
            isGrounded = false;
        }
        else if (!isGrounded)
        {
            rb.AddForce(Vector3.down, ForceMode.VelocityChange);
        }

    }


}
