using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Deals with collectables behaviour

public class CollectableWeapon : MonoBehaviour {


    public int weaponID = 0;
    public int howManyCanHeShoot = 0;

	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tank")
        {
            TankWeaponSystem tws = collision.gameObject.GetComponent<TankWeaponSystem>();
            tws.loadedWeapon = weaponID;
            tws.howManyCanIShoot = howManyCanHeShoot;
            Destroy(this.gameObject, 0.02f);
        }
    }
}
