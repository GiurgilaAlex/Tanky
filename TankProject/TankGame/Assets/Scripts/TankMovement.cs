using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour {

    /* Ataseaza virtual joystickul la axele Horizontal si Vertical.. */

    public int rotSpeed = 100;
    public float moveSpeed = 10;

    Rigidbody rb;
    Vector3 EulerAngleVelocity;
    float h = 0;
    float v = 0;
   
    int rotating = 0; //-1 means left, 1 means right

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        
        if( h > 0)
        {
            rotating = 1;
        }
        else if(h < 0)
        {
            rotating = -1;
        }
        else
        {
            rotating = 0;
        }

    }

    void FixedUpdate()
    {
        if(rotating != 0) RotateTank(rotating);
        rb.MovePosition(transform.position - transform.forward * v * moveSpeed * Time.deltaTime);
    }

    void RotateTank(int dirCode) 
    {
        if ((dirCode == 1 && v >= 0) || (dirCode == -1 && v >= 0))
        {
            EulerAngleVelocity = new Vector3(0, rotSpeed, 0);
            Quaternion deltaRotation = Quaternion.Euler(EulerAngleVelocity * h * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
        if((dirCode == -1 && v < 0) || (dirCode == 1 && v < 0))
        {
            EulerAngleVelocity = new Vector3(0, -rotSpeed, 0);
            Quaternion deltaRotation = Quaternion.Euler(EulerAngleVelocity * h * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
        
    }

    
}
