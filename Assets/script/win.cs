/*
 * this is assignment for CSCI 4168 Game design
 *
 * Name: Kairui Liang B00861227
 *
 * this is win script for player.
 *
 *  if player reach the destination on each level one, heal player to 100 HP and print WIN in console.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class win : MonoBehaviour
{
    public float distance;
    public Transform player;


    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("GameController").transform;
    }

    private void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);
        if (distance <= 3f)
        {
            Debug.Log("WIN!");
            if (player.GetComponent<NewBehaviourScript>().currentHealth < 100)
            {
                player.GetComponent<NewBehaviourScript>().currentHealth = 100;
                player.GetComponent<NewBehaviourScript>().HealthBar.SetHealth(100);
            }
        }

        

    }

}
