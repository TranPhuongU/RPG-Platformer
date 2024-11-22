using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirection))] 
public class Player2 : MonoBehaviour
{
    TouchingDirection touchingDirection;
    public bool _isFacingRight = true;
    public float speed;
    //public float runSpeed;
    Animator animator;
    Rigidbody2D rb;

    [SerializeField]
    private bool _isMoving = false;

    Vector2 moveInput;
    public float jumpForce;

    public float CurrentSpeed
    {
        get
        {
            {
                if (IsMoving && !touchingDirection.IsOnWall)
                {
                    return speed;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
      
    // animation di chuyển
    public bool IsMoving { get 
        { 
            return _isMoving;
        }
        private set 
        {
            _isMoving = value;
            animator.SetBool(AnimationStrings.isMoving, value);
        }
       }

    //quay hướng mặt player
    public bool IsFacingRight { get 
        {
            return _isFacingRight;
        } private set 
        {
            if (_isFacingRight != value)
            {
                transform.localScale *= new Vector2(-1,1);
            }
            _isFacingRight = value;
        } 
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingDirection = GetComponent<TouchingDirection>();
    }
    
    private void FixedUpdate()
    {
        // Di chuyển của player
        rb.velocity = new Vector2(moveInput.x * CurrentSpeed, rb.velocity.y);

        animator.SetFloat(AnimationStrings.yVelocity, rb.velocity.y);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        IsMoving = moveInput != Vector2.zero;
        SetFacingDirection(moveInput);
    }
    //Quay hướng mặt player 
    public void SetFacingDirection(Vector2 moveInput)
    {
        if(moveInput.x > 0 && !IsFacingRight)
        {
            //Face is right
            IsFacingRight = true;
        }
        else if (moveInput.x < 0 && IsFacingRight)
        {
            //Face is left
            IsFacingRight = false;
        }
    }
    
    public void OnJump(InputAction.CallbackContext context)
    {
        //todo check if alive as well
        if (context.started && touchingDirection.IsGrounded)
        {
            animator.SetTrigger(AnimationStrings.jump);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    
}
