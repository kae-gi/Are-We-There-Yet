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

	void Start()
	{
		m_rigidbody = GetComponent<Rigidbody>();
	}

    void FixedUpdate()
	{
		bool isGrounded = true;
		horizontalInput = Input.GetAxis("Horizontal");

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
		else if (!isGrounded)
		{
			m_rigidbody.AddForce(Vector3.down, ForceMode.VelocityChange);
		}
		/*transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed * horizontalInput + Vector3.forward * constSpeed * Time.deltaTime);*/
		transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed * horizontalInput);
	}
}
