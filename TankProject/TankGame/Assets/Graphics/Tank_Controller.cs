using UnityEngine;
using System.Collections;

public class Tank_Controller: MonoBehaviour
{
    public float speed = 3.0f;
    public float rotSpeed = 90.0f;
    public Rigidbody rb;
    public float xaxes;
    public float yaxes;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float rotateTank = Input.GetAxis("Horizontal");
        float moveTank = Input.GetAxis("Vertical");

        //rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed * -moveTank * Time.deltaTime;

        transform.Rotate(Vector3.up * rotSpeed * rotateTank * Time.deltaTime);

    }
    
}