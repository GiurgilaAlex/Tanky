using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableDropable : MonoBehaviour {

    public int dropableID = 0; // 0 is the mine
    public int howManyCanHeDrop = 0;
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tank")
        {
            TankWeaponSystem tws = other.gameObject.GetComponent<TankWeaponSystem>();

            if (tws.loadedDropable == -1)
            {
                tws.loadedDropable = dropableID;
                tws.howManyCanIDrop = howManyCanHeDrop;
                tws.UpdateUI();
                Destroy(this.gameObject, 0.02f);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Tank")
        {
            TankWeaponSystem tws = other.gameObject.GetComponent<TankWeaponSystem>();

            if (tws.loadedDropable == -1)
            {
                tws.loadedDropable = dropableID;
                tws.howManyCanIDrop = howManyCanHeDrop;
                tws.UpdateUI();
                Destroy(this.gameObject, 0.02f);
            }
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tank")
        {
            TankWeaponSystem tws = collision.gameObject.GetComponent<TankWeaponSystem>();
            
            if (tws.loadedDropable == -1)
            {
                tws.loadedDropable = dropableID;
                tws.howManyCanIDrop = howManyCanHeDrop;
                tws.UpdateUI();
                Destroy(this.gameObject, 0.02f);
            }
        }
    }*/
}
