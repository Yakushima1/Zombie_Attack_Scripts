using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour
{

    public float health;
	public GameOverScript GameOverScript;
    public Slider healthBar;
	public int points = 0;
    public Fire fire;
    void Start ()
    {
        healthBar.value = health;
    }
    
    public void damage(float amount)
    {
        if(health > 0)
        {
            health -= amount;
        }
        
        if(health <= 0)
        {
			GameOverScript.Setup(points);
        }
        healthBar.value = health;
    }

    public void setHealth(float health)
    {
        health = Math.Min(health + 20, 100);
        healthBar.value = health;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FirstAidKit"))
        {
            setHealth(health + 20);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Mag"))
        {
            fire.incrementAmmo();
            Destroy(other.gameObject);
        }
    }
}