using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Deals with bullet physics

public class Bullet : MonoBehaviour {


    public int speed = 5;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = transform.up * -speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
