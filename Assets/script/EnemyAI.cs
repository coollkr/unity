using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UIElements;

public class police : MonoBehaviour
{
    // Start is called before the first frame update


    public Transform player;
    public float speed = 1f, distance;
    public Vector3 StarPosition;
    
    public LayerMask groundMask;
    public float groundCheckDistance = 0.4f;
    public bool isGrounded;
    private Vector3 velocity;
    public float gravity = -9.8f;
    private CharacterController controller;
    private float attackCooldown = 1f;
    private float _lastAttackTime;
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("GameController").transform;
        StarPosition = transform.position;
        groundMask = LayerMask.GetMask("ground");
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
        distance = Vector3.Distance(transform.position, player.position);
        
        
        
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
           
        }
        
        if (distance <= 10f)
        {
            //chase player
            Chase();
        }
        
        if (distance <= 2f)
        {
            //give damage to player
            if (Time.time - _lastAttackTime >= attackCooldown)
            {
                damage();
            }

            
            
        }
        
        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        
    }


    void Chase()
    {
            Vector3 newVector =  player.position - transform.position ;
        
            controller.transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            // controller.transform.LookAt();
            // transform.Translate(0,0, speed * Time.deltaTime);
            controller.Move(newVector * speed * Time.deltaTime);
        
    }

    void damage()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<NewBehaviourScript>().TakeDamage(20);
        _lastAttackTime = Time.time;
    }


}
