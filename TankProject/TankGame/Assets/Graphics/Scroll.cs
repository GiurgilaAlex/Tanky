using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {

    public float speed = .5f;
    public Renderer rend;
    public bool scroll = true;

	// Use this for initialization
	void Start () {
        rend = this.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {

        if (scroll)
        {
            Vector2 offset = new Vector2(Time.time * speed, 0);

            rend.material.SetTextureOffset("_MainTex", offset);
        }
    }
}
