using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankWeaponSystem : MonoBehaviour {

    public Transform bulletSpawnPoint;  //where the buuuullets come ouuuut...iiihaaaa
    public Transform dropableSpawnPoint;

    public GameObject[] weapons;    // reference to the weapons prefabs
    public GameObject[] dropables;   // reference to the dropables prefabs
    public Sprite[] weaponsImgs;
    public Sprite[] dropableImgs;

    public int loadedWeapon = 0;   // 0 is the default bullet
    public int howManyCanIShoot = 0;
    public int loadedDropable = -1;  // -1 means no Dropable loaded , won t use 0 because i want the index for the dropables vector directly from here
    public int howManyCanIDrop = 0;

    public Image loadedWeaponImg;
    public Image loadedDropableImg;
    public Text weaponCounter;
    public Text dropableCounter;


    void Start () {
        ClearLoadedDropable();
        ClearLoadedWeapon();

        SetUI();
	}
	
	void Update () {
        UpdateUI();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(loadedWeapon == 0)
            {
                Shoot(loadedWeapon);
            }
            else if (howManyCanIShoot > 0) //enters only if the loaded weapon is not the default one
            {
                Shoot(loadedWeapon);
                howManyCanIShoot--;
                if(howManyCanIShoot <= 0)
                {
                    ClearLoadedWeapon();
                }
            }
            else
            {
                Debug.Log("Am ajuns in else..Cum? TankWeaponSystem.cs");
                //ClearLoadedWeapon();
                //Shoot(loadedWeapon);
            }
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (howManyCanIDrop > 0)
            {
                Drop(loadedDropable);
                howManyCanIDrop--;
            }
            else
            {
                ClearLoadedDropable();
            }
        }
        
    }

    void Shoot(int weaponCode)  //instantiates the prefab for the loaded weapon (each prefab will have it s own script, so the bullets are on their own when they leave
    {
        GameObject clone = Instantiate(weapons[weaponCode], bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        Destroy(clone, 2.0f);
    }

    void Drop(int dropableCode)  //dropableCode is the loadedDropable
    {
        GameObject clone = Instantiate(dropables[dropableCode], dropableSpawnPoint.position, dropableSpawnPoint.rotation);

        //Destroy(clone, 2.0f);
    }

    void ClearLoadedWeapon()
    {
        loadedWeapon = 0;
    }
    void ClearLoadedDropable()
    {
        loadedDropable = -1;
    }
    void SetUI()
    {
        weaponCounter.enabled = false;
        dropableCounter.enabled = false;
        loadedDropableImg.enabled = false;
    }
    void UpdateUI()
    {
        loadedWeaponImg.sprite = weaponsImgs[loadedWeapon];
        if(howManyCanIShoot > 0)
        {
            weaponCounter.enabled = true;
            weaponCounter.text = howManyCanIShoot.ToString();
        }
        else
        {
            weaponCounter.enabled = false;
            loadedWeaponImg.sprite = weaponsImgs[loadedWeapon];
        }


        if(loadedDropable >= 0 && howManyCanIDrop >= 1)
        {
            loadedDropableImg.enabled = true;
            loadedDropableImg.sprite = dropableImgs[loadedDropable];
            dropableCounter.enabled = true;
            dropableCounter.text = howManyCanIDrop.ToString();
        }
        else
        {
            dropableCounter.enabled = false;
            loadedDropableImg.enabled = false;
        }
    }
}
