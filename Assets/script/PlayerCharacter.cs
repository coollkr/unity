/*
 * this is assignment for CSCI 4168 Game design
 *
 * Name: Kairui Liang B00861227
 *
 * this is to track player's health.
 *
 * this script will store the player's current health.
 *
 * 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using Update = Unity.VisualScripting.Update;


public class NewBehaviourScript : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public healthBar HealthBar;
    
    public Transform respawnPoint;
    void Start()
    {
        
        currentHealth = maxHealth;
        
        HealthBar.SetHealth(maxHealth);

        Transform respawnPoint = this.transform;
    }

    void Update()
    {
        //K for get damage and L for get heal just for cheat code in this game.
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(20);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            getHeal(20);
        }
    }
    
    //take damage from coppers
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
            die();
        HealthBar.SetHealth(currentHealth);
    }
    
    //get heal function.
    void getHeal(int heal)
     {
         currentHealth += heal;
         if (currentHealth > 100)
             currentHealth = 0;
         HealthBar.SetHealth(currentHealth);
     }

    // if player die, them the game will restart.
    void die()
    {
        
        SceneManager.LoadScene(0);
    }
}
