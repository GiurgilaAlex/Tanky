using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//Deals with bullet physics

public class Bullet : MonoBehaviour {

    public int maxDamage = 200;
    //public int damageDrop;
    public int speed = 5;
    Rigidbody rb;


    float timer = 0.0f;
    //timerMultiplier getting a higher value means a higher damage dropOverTime
    //for variation in game // should be rethinked based on the speed
    public int damageDropOverTime = 25;
    private int converted;
	void Start () {
        rb = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = transform.up * -speed;
        timer += Time.deltaTime;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        converted = Convert.ToInt32(timer * damageDropOverTime);
        if (other.gameObject.tag == "Tank")
        {
            other.gameObject.GetComponent<TankHealth>().RemoveHealth(maxDamage - converted);
        }
        //Debug.Log("Damage Drop: " + converted);
        //Debug.Log("Damage Given: " + (maxDamage - converted));
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject, .05f);
    }
}
    
    /*private void OnCollisionEnter(Collision collision)
    {
        converted = Convert.ToInt32(timer* damageDropOverTime);
        if (collision.gameObject.tag == "Tank")
        {
            collision.gameObject.GetComponent<TankHealth>().RemoveHealth(maxDamage-converted);
        }
        Debug.Log("Damage Drop: " + converted);
        Debug.Log("Damage Given: " + (maxDamage-converted));
        Destroy(this.gameObject);
    }*/
