/*
 * this is assignment for CSCI 4168 Game design
 *
 * Name: Kairui Liang B00861227
 *
 * this a health bar.
 *
 * this script will help health bar to show the current health for player.
 *
 * 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    
    public Slider slider;

    

    
    // set max health for health and set the current health to max
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    
    //set the player health with a number.
    public void SetHealth(int health)
    {
        if(slider != null)
            slider.value = health;
    }
}
