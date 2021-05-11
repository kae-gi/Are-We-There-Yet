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
    private Vector3 inputVector;

    public WheelCollider[] wheelColliders = new WheelCollider[4];
    public float maxSteerAngle = 30;
    public float baseSpeed = 25;
    public float maxSpeed = 40;
    public float jumpVelocity = 5;
    public float InitialTimeRemaining = 1;
    public float timeRemaining;

    public TextMeshProUGUI fuelCountText;
    public GasBar gasBar;
    public float reduceGasPerUpdateFactor = -0.001f;
    private float curGasAmount = 0.5f;

    public HealthBar healthBar;
    public float curHealth = 1.0f;

    public GameObject laser;

    public TextMeshProUGUI coinCountText;
    // NOTE: public static int coinCount is located in Scripts > Data.cs

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timeRemaining = InitialTimeRemaining;
        fuelCount = 0;
        SetCountText();
        healthBar.setHealth(1.0f);
        gasBar.setGas(0.5f);
        setCoinCountText();

        // set the car color
        transform.GetChild(0).GetComponent<MeshRenderer>().material.color = GlobalData.carColor;
    }

    void Update()
    {
        // laser input
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            // spawn location of laser beam
            Vector3 laser1Pos = new Vector3(transform.position.x + 0.75f, transform.position.y+0.65f, transform.position.z+7);
            Vector3 laser2Pos = new Vector3(transform.position.x - 0.75f, transform.position.y+0.65f, transform.position.z+7);
            // produce laser at player location
            Rigidbody _laser1 = Instantiate(laser.GetComponent<Rigidbody>(), laser1Pos, Quaternion.identity);
            Rigidbody _laser2 = Instantiate(laser.GetComponent<Rigidbody>(), laser2Pos, Quaternion.identity);

            // destroy object laser after 1 sec
            //Destroy(_laser1);
            //Destroy(_laser2);
        }
    }

    void FixedUpdate()
    {
        // input
        horizontalInput = Input.GetAxis("Horizontal"); // for moving side to side 
        // steering
        steerAngle = maxSteerAngle * horizontalInput;
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
            // ==> decrease the gas meter level (normal rate)
            changeGasAmount(reduceGasPerUpdateFactor);
        }
        else
        {
            isAccelerating = true;
            speed = maxSpeed;
            timeRemaining -= Time.deltaTime;
            // ==> decrease the gas meter level (accelerated)
            changeGasAmount(reduceGasPerUpdateFactor * 3);
        }
        // new movement added to use rigidBody instead of tranform
        inputVector = new Vector3(steerAngle, rb.velocity.y, speed);
        rb.velocity = inputVector;

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

        // keep the vehicle facing forward at all times
        transform.rotation = Quaternion.identity;
    }


    // fuel counter
    void SetCountText()
    {
        fuelCountText.text = "Fuel Count: " + fuelCount.ToString();
    }

    // coin counter
    void setCoinCountText()
    {
        coinCountText.text = "    " + GlobalData.coinCount.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            fuelCount++;
            curGasAmount += 0.1f;
            gasBar.setGas(curGasAmount);

            SetCountText();
        }

        else if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            GlobalData.coinCount++;
            setCoinCountText();
        }
    }

    // health bar 
    public void changeHealthAmount(float amount)
    {
        curHealth += amount;
        healthBar.setHealth(curHealth);
    }

    public void changeGasAmount(float amount)
    {
        curGasAmount += amount;

        if (curGasAmount > 1.0f)
        {
            curGasAmount = 1.0f;
        }

        gasBar.setGas(curGasAmount);

        // reload the scene if the player runs out of gas
        if (curGasAmount <= 0.0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}