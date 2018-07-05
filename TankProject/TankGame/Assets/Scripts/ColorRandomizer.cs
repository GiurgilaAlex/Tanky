using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRandomizer : MonoBehaviour {

    private Renderer[] pieceMaterial;
    public Material[] pieceColoredMaterial;

	void Start () {
        pieceMaterial = GetComponentsInChildren<Renderer>();
        int rand = 0;
        for(int i = 0; i < pieceMaterial.Length; i++)
        {
            rand = (int)Random.Range(0f, (float)pieceColoredMaterial.Length);
            //Debug.Log("color: " + rand);
            pieceMaterial[i].material = pieceColoredMaterial[rand];
        }
        pieceMaterial = null;
    }

	void Update () {
		
	}
}
