using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusAnimator : MonoBehaviour {

    public int speed = 50;

	// Use this for initialization
	void Start () {
        Animation an = this.GetComponent<Animation>();
        an.Play("bonus");
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(Vector3.back * Time.deltaTime * speed );
	}
}
