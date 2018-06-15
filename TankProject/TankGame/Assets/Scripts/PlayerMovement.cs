using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = 10;
	public int rotationSpeed = 25;
	public Rigidbody rb;
	public GameObject ball;
	public Transform ballSpawnPoint;
	public VirtualJoystick joystick;

	private float horizontal;
	private float vertical;
	//private Vector3 newPos = Vector3.zero;
	//private GameObject body;

	void Start()
	{
		//body = transform.GetChild(0).GetChild(0).GetComponent<GameObject>();
	}

	void Update()
	{
		horizontal = joystick.Horizontal();
		vertical = joystick.Vertical();

		Debug.Log("horizontal: " + horizontal + "    vertical: " + vertical);

		MovePosition();

		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			Shoot ();
		}
	}

	void Shoot()
	{
		Instantiate (ball, ballSpawnPoint.position, Quaternion.identity);
	}


	void MovePosition()
	{
		float temp1, temp2;
		temp1 = horizontal;
		temp2 = vertical;
		if(Mathf.Abs(temp1) < 0.25 && Mathf.Abs(temp2) < 0.25)
			speed = 2.5f;
		else
			if(Mathf.Abs(temp1) < 0.5 && Mathf.Abs(temp2) < 0.5)
				speed = 5f;
		else
			speed = 10f;
		Vector3 movement = new Vector3(horizontal,0,vertical);
		movement = movement.normalized * speed * Time.deltaTime;
		rb.MovePosition(rb.position + movement);
	}
}
