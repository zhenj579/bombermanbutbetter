using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int speed = 5;
    [SerializeField] private float multiplier = 1f;
    // Set Vector2 name same as PlayerInput/Actions name
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;
    
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void OnSprint (InputValue sprintvalue) // Get value from Unity Input System
    {
        var sprintInput = sprintvalue.Get<float>(); // Read value from Unity Input System as float
        if (sprintInput > 0)
        {
            multiplier = 1.5f;
        }
        else
        {
            multiplier = 1f;
        }
    }
    private void OnMovement (InputValue value) 
    {
        movement = value.Get<Vector2>();
        if(movement.x != 0 || movement.y != 0)
        {
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);

            animator.SetBool("IsWalking", true);
        }    
        else
        {
            animator.SetBool("IsWalking", false);    
        }

    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * multiplier * Time.fixedDeltaTime);
    }
}