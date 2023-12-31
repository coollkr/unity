/*
 * this is assignment for CSCI 4168 Game design
 *
 * Name: Kairui Liang B00861227
 *
 * this is to help player move .
 *
 * this script is character controller for player.
 *
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update


    public float moveSpeed;
    public float RunSpeed = 10f;
    public float WalkSpeed = 2f;
    public float RotateSpeed;
    
    public CharacterController controller;
    public Vector3 moveDirection;
    private Vector3 velocity;
    
    public bool isGrounded;
    public float groundCheckDistance = 0.4f;
    public float gravity = -9.8f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;
    
    
    
    
    private Animation _animation;
    void Start()
    {
        
        controller = GetComponent<CharacterController>();
        
        groundMask = LayerMask.GetMask("ground");
        
        _animation = GetComponent<Animation>();
        
        
    }
    
    
    void Update()
    {
        //call move function
        Move();
        
    }
    
    private void Move()
    {
        
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
           
        }

       
        var moveZ = Input.GetAxis("Vertical");
        var moveX = Input.GetAxis("Horizontal");
        
        

        moveDirection = new Vector3(moveX, 0, moveZ);
        moveDirection.Normalize();
        
        if (moveDirection != Vector3.zero)
        {
            transform.forward = moveDirection;
        }

        

        
        
        // only is ground then we can move.
        if (isGrounded)
        {
            

            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
            
                Walk();
                if(isGrounded)
                    _animation.Play("walk");
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
            
                Run();
                if(isGrounded)
                    _animation.Play("run");
            }
            

            if (Input.GetButtonDown("Jump"))
            {
                
                Jump();
                
            }
            
            if (!_animation.isPlaying)
            {
                _animation.Play("idle");
            }

            
        }

       
        // if player is not on the ground.
        else if (!isGrounded)
        {
            _animation.Play("jumpFall");
        }



        moveDirection *= moveSpeed;
        controller.Move(moveDirection * Time.deltaTime);
        
       
        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        
        

    }
    
    
    //movement function or change speed when walking or Running.
    private void Walk()
    {
        moveSpeed = WalkSpeed;
    }

    private void Run()
    {
        moveSpeed = RunSpeed;
    }
    
    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }

}
