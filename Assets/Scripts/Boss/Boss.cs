using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirection))]
public class Boss : MonoBehaviour
{
    public float walkStopRate; //boss sẽ di chuyển thêm 1 xíu khi tấn công = 0.05 di lên 1 xíu, 1 là dừng hẳn
    public float walkSpeed;
    Rigidbody2D rb;
    public  DetectionZone attackZone;

    Animator animator;
    TouchingDirection touchingDirection;
    public enum WalkableDirection { Right, Left }

    private WalkableDirection _walkDirection;
    private Vector2 walkDirectionVector = Vector2.right;

    public WalkableDirection WalkDirection
    {
        get { return _walkDirection; }
        set
        {
            if (_walkDirection != value)
            {
                //Direction flipped
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);
                if (value == WalkableDirection.Right)
                {
                    walkDirectionVector = Vector2.right;

                }
                else if (value == WalkableDirection.Left)
                {
                    walkDirectionVector = Vector2.left;
                }
            }
            _walkDirection = value;
        }
    }

    public bool _hasTarget = false;
    public bool HasTarget { get 
        {
            return _hasTarget;
        } private set 
        {
            _hasTarget = value;
            animator.SetBool("hasTarget", value);
        } 
    }

    public bool CanMove
    {
        get
        {
            return animator.GetBool("canMove");
        }
    }

    // Start is called before the first frame update
    //void Start()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //    touchingDirection = GetComponent<TouchingDirection>();
    //}

    // Update is called once per frame
    //void Update()
    //{
    //    if (touchingDirection.IsGrounded && touchingDirection.IsOnWall)
    //    {
    //        FlipDirection();
    //    }
    //    rb.velocity = new Vector2(walkDirectionVector.x * walkSpeed, rb.velocity.y);

    //}
    private void Update()
    {
        HasTarget = attackZone.detectedColliders.Count > 0;
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        touchingDirection = GetComponent<TouchingDirection>();
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if (touchingDirection.IsGrounded && touchingDirection.IsOnWall)
        {
            FlipDirection();
        }
        if (CanMove)
        {
            rb.velocity = new Vector2(walkSpeed * walkDirectionVector.x, rb.velocity.y);
        }else
        {
            rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x,0,walkStopRate),rb.velocity.y);
        }
    }

    private void FlipDirection()
    {
        if (WalkDirection == WalkableDirection.Right)
        {
            WalkDirection = WalkableDirection.Left;
        }
        else if (WalkDirection == WalkableDirection.Left)
        {
            WalkDirection = WalkableDirection.Right;
        }
        else
        {
            Debug.LogError("Current walk direction is not set to legal values");
        }
    }
}
