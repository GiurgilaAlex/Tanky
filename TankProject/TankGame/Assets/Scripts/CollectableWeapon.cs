using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Deals with collectables behaviour

public class CollectableWeapon : MonoBehaviour {


    public int weaponID = 0;
    public int howManyCanHeShoot = 0;

	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tank")
        {
            TankWeaponSystem tws = other.gameObject.GetComponent<TankWeaponSystem>();

            
            if (tws.loadedWeapon == 0)
            {
                if (weaponID == 3)
                {
                    tws.rayTransform.SetActive(true);

                }
                if (weaponID == 4)
                {
                    tws.needHoldForThisWeapon = true;
                }
                tws.loadedWeapon = weaponID;
                tws.howManyCanIShoot = howManyCanHeShoot;
                tws.UpdateUI();
                Destroy(this.gameObject, 0.02f);
            }
        }
    }

    /*private void OnTriggerStay(Collider other)  //TODO FIX
    {
        if (other.gameObject.tag != "DoesDamage" && other.gameObject.tag != "Explosive")
        {
            TankWeaponSystem tws = other.gameObject.GetComponent<TankWeaponSystem>();

            if (weaponID == 3)
            {
                tws.rayTransform.SetActive(true);

            }
            if (weaponID == 4)
            {
                tws.needHoldForThisWeapon = true;
            }
            if (tws.loadedWeapon == 0)
            {
                tws.loadedWeapon = weaponID;
                tws.howManyCanIShoot = howManyCanHeShoot;
                tws.UpdateUI();
                Destroy(this.gameObject, 0.02f);
            }
        }
    }*/

}
