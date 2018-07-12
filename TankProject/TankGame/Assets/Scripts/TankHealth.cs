using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class TankHealth : MonoBehaviour {

    public Image healthRadialImage;
    public int maxHealth = 1000;
    public int health;
    //public float startingFilling = 1;

	void Start () {
        health = maxHealth;
	}
	
    public void AddHealth(int value)
    {
        health += value;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
        UpdateHealth();
    }

    public bool RemoveHealth(int value)
    {
        health -= value;
        if(health <= 0)
        {
            health = 0;
            UpdateHealth();
            Death();
            return true;
        }
        UpdateHealth();
        return false;
    }

    private void UpdateHealth()
    {
        healthRadialImage.fillAmount = ((float)health / (float)maxHealth); // * startingFilling;
    }

    public void Death()
    {
        Debug.Log("A tank is dying, shioit!");
        Destroy(this.gameObject);

    }
}
