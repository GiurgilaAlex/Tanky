using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public int speed = 20;
	public Rigidbody rb;

	private Vector3 dir;
	private GameObject player;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Tank");
		dir = player.transform.forward;
	}

	void Update()
	{
		transform.Translate(-dir*speed*Time.deltaTime);
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.collider.name == "Wall" || col.collider.name == "Wall(Clone)")
			Destroy (gameObject);
	}
}
