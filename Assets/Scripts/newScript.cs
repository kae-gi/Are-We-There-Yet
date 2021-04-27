using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newScript : MonoBehaviour
{
	public WheelCollider[] wheelColliders = new WheelCollider[4];
	public Transform[] tyreMeshes = new Transform[4];
	public float maxTorque = 50.0f;
	private Rigidbody m_rigidbody;
	public Transform centerOfMass;
	public int jumpHeight = 5;
	public float horizontalSpeed = 7f;
	public float horizontalInput;
	public float forwardInput;
	public float constSpeed = 20;

	void Start()
	{
		m_rigidbody = GetComponent<Rigidbody>();
	}

	void OnCollisionEnter(Collision c)
	{
		string n = c.gameObject.name;
        if ((n == "RespawnPlane") || (n.Substring(0, 3) == "Cyl"))
		{
			respawn();
        }
    }

	void respawn()
    {
		// respawn to the beginning
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		/*transform.position = new Vector3(0, 0.3f, 0);
		transform.rotation = Quaternion.Euler(0, 0, 0);
		m_rigidbody.velocity = Vector3.zero;*/
	}


    void FixedUpdate()
	{
		bool isGrounded = true;
		horizontalInput = Input.GetAxis("Horizontal");
		forwardInput = Input.GetAxis("Vertical");

		for (int i = 0; i < 4; i++)
		{
			if (!wheelColliders[i].isGrounded)
			{
				isGrounded = false;
			}
		}
		
		if (Input.GetButton("Jump") && isGrounded)
		{
			m_rigidbody.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
		}
		/*transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed * horizontalInput + Vector3.forward * constSpeed * Time.deltaTime);*/
		transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed * horizontalInput);
	}
}
