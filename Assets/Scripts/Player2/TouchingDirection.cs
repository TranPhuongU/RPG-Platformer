using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingDirection : MonoBehaviour
{
    public ContactFilter2D castFilter;
    CapsuleCollider2D touchingCol;

    public float groundDistance = 0.05f;
    public float wallDistance = 0.2f;
    public float ceilingDistance = 0.05f;

    RaycastHit2D[] groundHits = new RaycastHit2D[5];
    RaycastHit2D[] wallHits = new RaycastHit2D[5];
    RaycastHit2D[] ceilingHits = new RaycastHit2D[5];

    Animator animator;

    [SerializeField]
    private bool _isOnWall;

    //Kiểm tra xem có ở dưới đất hay không
    public bool IsOnWall
    {
        get
        {
            return _isOnWall;
        }
        private set
        {
            _isOnWall = value;
            animator.SetBool("isOnWall", value);
        }
    }

    [SerializeField]
    private bool _isOnCeiling;

    //Kiểm tra xem có ở dưới đất hay không
    public bool IsOnCeiling
    {
        get
        {
            return _isOnCeiling;
        }
        private set
        {
            _isOnCeiling = value;
            animator.SetBool("isOnCeiling", value);
        }
    }

    [SerializeField]
    private bool _isGrounded;

    //Kiểm tra xem có ở dưới đất hay không
    public bool IsGrounded { get 
        {
            return _isGrounded;
        } private set 
        {
            _isGrounded = value;
            animator.SetBool("isGrounded", value);
        } }

    public Vector2 WallCheckDirection => gameObject.transform.localScale.x > 0 ? Vector2.right : Vector2.left;


    private void Awake()
    {
        animator = GetComponent<Animator>();  
        touchingCol = GetComponent<CapsuleCollider2D>();
    }

    private void FixedUpdate()
    {
        // VA CHẠM VỚI GROUND
        IsGrounded = touchingCol.Cast(Vector2.down, castFilter, groundHits, groundDistance) > 0;
        //VA CHẠM VỚI TƯỜNG
        IsOnWall = touchingCol.Cast(WallCheckDirection, castFilter, wallHits,wallDistance) > 0;
        // VA CHẠM VỚI TRẦN NHÀ
        IsOnCeiling = touchingCol.Cast(Vector2.up, castFilter, ceilingHits, ceilingDistance) > 0;
    }
}
