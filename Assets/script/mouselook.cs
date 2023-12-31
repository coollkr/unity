/*
 * this is assignment for CSCI 4168 Game design
 *
 * Name: Kairui Liang B00861227
 *
 * this a mouse look.
 *
 * this script will help mouse to change the direction.
 *
 * no used in this assignment.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class mouselook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 250f;

        
    private Transform parent;
    
    private GameObject kid;

    private void Start()
    {
        parent = transform.parent;


        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Rotate();
        

    }

    
    private void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        
        if(parent != null)
            parent.Rotate(Vector3.up, mouseX);
    }

    
}
