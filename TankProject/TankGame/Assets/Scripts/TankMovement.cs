using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour {

  ////TO DO : Implement a way the tank moves only when the tank touches the ground, or you ll end up with a flying tank 

    public Vector3 _centerOfMasss;
    public string hAxisName;
    public string vAxisName;
    //public string fireAxisName;
    //public string dropAxisName;

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
        rb.centerOfMass = _centerOfMasss;
    }

    private void Update()
    {
        rb.centerOfMass = _centerOfMasss;
        h = Input.GetAxis(hAxisName);
        v = Input.GetAxis(vAxisName);
        
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
