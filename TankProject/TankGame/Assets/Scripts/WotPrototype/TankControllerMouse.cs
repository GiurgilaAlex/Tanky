using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControllerMouse : MonoBehaviour {

    public float mouseX;
    public float mouseY;
    //Vector3 EulerAngleVelocity;
    public float rotSpeed = 5f;
    public GameObject turret;
    //public Transform turretTransform;
	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        //EulerAngleVelocity = new Vector3(0, rotSpeed, 0);
        //Quaternion deltaRotation = Quaternion.Euler(EulerAngleVelocity * h * Time.deltaTime);
        turret.transform.Rotate(transform.up * mouseX *  Time.deltaTime * rotSpeed, Space.World);
        //turret.transform.local
    }
}
