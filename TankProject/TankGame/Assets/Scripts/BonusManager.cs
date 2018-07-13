using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour {

    public GameObject[] bonusList;

    public float timerMin = 5f;
    public float timerMax = 10f;
    public float randTimer;
    public Transform popParent;


	// Use this for initialization
	void Start () {
        randTimer = 5f;
	}
	
	// Update is called once per frame
	void Update () {
        randTimer -= Time.deltaTime;

        if(randTimer <= 0)
        {
            CheckPopPoints();
            randTimer = Random.Range(timerMin, timerMax);
        }
	}

    void CheckPopPoints()
    {
        foreach (Transform child in popParent)
        {
            if (child.childCount == 0)
            {
                int rand = Random.Range(0, bonusList.Length);
                var clone = Instantiate(bonusList[rand], child.transform.position, bonusList[rand].transform.rotation);
                clone.transform.SetParent(child.transform);
                Animation an = child.GetChild(0).GetComponent<Animation>();
                an.Play("bonus");
            }
                //Something(child.gameObject);
            }
    }
}
