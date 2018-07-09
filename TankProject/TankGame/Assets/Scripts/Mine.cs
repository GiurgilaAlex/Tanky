using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour {

    public Material mat;
    public float timer = 1f;
    private float _timer = 1f;
    private bool b = true;
	// Use this for initialization
	void Start () {
        mat = this.GetComponent<Renderer>().material;
        _timer = timer;
	}
	
	// Update is called once per frame
	void Update () {
        _timer -= .1f;
        if (_timer <= 0)
        {
            if (b) { 
                mat.DisableKeyword("_EMISSION");
                b = false;
            }
            else
            {
                mat.EnableKeyword("_EMISSION");
                b = true;
            }
            _timer = timer;
        }
	}
}
