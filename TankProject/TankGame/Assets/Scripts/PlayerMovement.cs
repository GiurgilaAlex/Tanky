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
	public Transform body;

	private float horizontal;
	private float vertical;
	//private Vector3 newPos = Vector3.zero;

	void Update()
	{
		horizontal = joystick.Horizontal();
		vertical = joystick.Vertical();
		
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
		/*if(Mathf.Abs(temp1) < 0.25 && Mathf.Abs(temp2) < 0.25)
			speed = 2.5f;
		else
			if(Mathf.Abs(temp1) < 0.5 && Mathf.Abs(temp2) < 0.5)
				speed = 5f;
		else
			speed = 10f;
		*/
		float currentSpeed;
		if(Mathf.Abs(temp1) > Mathf.Abs (temp2))
		{
			currentSpeed = speed * Mathf.Abs(temp1);
		}
		else 
		{
			currentSpeed = speed * Mathf.Abs(temp2);
		}
		Vector3 rotation = joystick.DirectionToRotate();
		if(rotation != Vector3.zero)
		body.rotation = Quaternion.Euler(body.transform.rotation.x,rotation.y,body.transform.rotation.z);
		
		Vector3 movement = new Vector3(horizontal,0,vertical);
		movement = movement.normalized * currentSpeed * Time.deltaTime;
		rb.MovePosition(rb.position + movement);
	}
}
