using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankWeaponSystem : MonoBehaviour {

    public Transform bulletSpawnPoint;  //where the buuuullets come ouuuut...iiihaaaa
    public Transform dropableSpawnPoint;
    public GameObject rayTransform;

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

    public string fireAxisName;
    public string dropAxisName;
    public bool needHoldForThisWeapon = false;
    public float machineGunrate = 3F;

    void Start () {
        ClearLoadedDropable();
        ClearLoadedWeapon();

        SetUI();
	}
	
	void Update () {
        if (!needHoldForThisWeapon)
        {
            if (Input.GetButtonDown(fireAxisName))
            {
                Shoot();
            }
        }
        else //////////TO DO: Implement the Machine Gun
        {
            if (Input.GetButtonDown(fireAxisName))
            {
                InvokeRepeating("Shoot", 0.0f, machineGunrate);
            }
            if (Input.GetButtonUp(fireAxisName) || howManyCanIShoot <= 0 )
            {
                if(howManyCanIShoot <= 0) { ClearLoadedWeapon(); needHoldForThisWeapon = false; }
                CancelInvoke();
                
            }
        }
        
        if (Input.GetButtonDown(dropAxisName))
        {
            Drop();
        }
    }

    void Shoot()
    {
        if(howManyCanIShoot > 0)
        {
            Instantiate(weapons[loadedWeapon], bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            howManyCanIShoot--;
            if(howManyCanIShoot <= 0)
            {
                ClearLoadedWeapon();
                
            }
        }
        else //means the default is loaded
        {
            Instantiate(weapons[loadedWeapon], bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
        UpdateUI();
    }

    void Drop()
    {
        if (loadedDropable != -1)
        {
            if (howManyCanIDrop > 0)
            {
                Instantiate(dropables[loadedDropable], dropableSpawnPoint.position, dropableSpawnPoint.rotation);
                howManyCanIDrop--;
                if(howManyCanIDrop <= 0)
                {
                    ClearLoadedDropable();
                }
            }
            else
            {
                ClearLoadedDropable();
                
            }
            UpdateUI();
        }
        else
        {
            Debug.Log("You don't own any dropables!");
        }
    }

    void ClearLoadedWeapon()
    {
        if (loadedWeapon == 3)
        {
            rayTransform.SetActive(false);
        }
        loadedWeapon = 0;
        UpdateUI();
    }

    void ClearLoadedDropable()
    {
        
        loadedDropable = -1;
        UpdateUI();
    }

    void SetUI()
    {
        weaponCounter.enabled = false;
        dropableCounter.enabled = false;
        loadedDropableImg.enabled = false;
        rayTransform.SetActive(false);
        UpdateUI();
    }

    public void UpdateUI()
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
