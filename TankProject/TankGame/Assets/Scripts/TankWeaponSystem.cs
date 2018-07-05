using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankWeaponSystem : MonoBehaviour {

    public Transform bulletSpawnPoint;
    public GameObject[] weapons;    // reference to the weapons prefabs
    public GameObject[] dropables;   // reference to the dropables prefabs
    public int loadedWeapon = 0;   // 0 is the default bullet

    void Start () {
		
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot(loadedWeapon);
        }
        
    }

    void Shoot(int weaponCode)
    {
        GameObject clone = Instantiate(weapons[weaponCode], bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        Destroy(clone, 2.0f);
    }
}
