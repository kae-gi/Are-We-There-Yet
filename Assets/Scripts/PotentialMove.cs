using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PotentialMove : MonoBehaviour
{
    private float horizontalInput;
    private float steerAngle;
    private float speed;
    private int fuelCount;
    private bool isGrounded;
    private bool isAccelerating = false;
    private Rigidbody rb;

    public WheelCollider[] wheelColliders = new WheelCollider[4];
    public float maxSteerAngle = 30;
    public float baseSpeed = 25;
    public float maxSpeed = 40;
    public float jumpVelocity = 5;
    public float InitialTimeRemaining = 1;
    public float timeRemaining;
    public TextMeshProUGUI fuelCountText;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timeRemaining = InitialTimeRemaining;
        fuelCount = 0;
        SetCountText();
    }

    void FixedUpdate()
    {
        // input
        horizontalInput = Input.GetAxis("Horizontal"); // for moving side to side 
        // steering
        steerAngle = maxSteerAngle * horizontalInput;
        transform.Translate(Vector3.right * Time.deltaTime * steerAngle);
        // acceleration controls
        // => input if accelerating
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isAccelerating = true;
        }
        // => controls speed & duration
        if (!isAccelerating || timeRemaining < 0)
        {
            isAccelerating = false;
            speed = baseSpeed;
            timeRemaining = InitialTimeRemaining;
        }
        else 
        {
            isAccelerating = true;
            speed = maxSpeed;
            timeRemaining -= Time.deltaTime;
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

    // fuel counter
    void SetCountText()
    {
        fuelCountText.text = "Fuel Count: " + fuelCount.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            fuelCount++;

            SetCountText();
        }
    }



}
