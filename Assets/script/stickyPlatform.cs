/*
 * this is assignment for CSCI 4168 Game design
 *
 * Name: Kairui Liang B00861227
 *
 * this is to help to stick player on the platform.
 *
 *  
 */
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class sti : MonoBehaviour
{
    public GameObject player;
    
    
    //trigger for if player on the board let player be child of platform. 
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == player)
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }
    //If player go away, let relation break.
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject == player)
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
    
    
    
}
