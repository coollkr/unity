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
        // Health playerHealth = new Health(maxHealth);
        currentHealth = maxHealth;
        
        HealthBar.SetHealth(maxHealth);

        Transform respawnPoint = this.transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(20);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            getHeal(20);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
            die();
        HealthBar.SetHealth(currentHealth);
    }
    
    void getHeal(int heal)
     {
         currentHealth += heal;
         if (currentHealth > 100)
             currentHealth = 0;
         HealthBar.SetHealth(currentHealth);
     }


    void die()
    {
        // Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene(0);
    }
}
