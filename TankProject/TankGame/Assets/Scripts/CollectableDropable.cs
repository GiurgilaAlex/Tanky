using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableDropable : MonoBehaviour {

    public int dropableID = 0; // 0 is the mine
    public int howManyCanHeDrop = 0;
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tank")
        {
            TankWeaponSystem tws = collision.gameObject.GetComponent<TankWeaponSystem>();
            tws.loadedDropable = dropableID;
            tws.howManyCanIDrop = howManyCanHeDrop;
            Destroy(this.gameObject, 0.02f);
        }
    }
}
