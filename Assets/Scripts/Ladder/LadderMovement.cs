using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    private float vertical;
    public float speed;
    private bool isLadder;
    private bool isClimbing;
    Animator animator;

    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("SpeedUp", Mathf.Abs(vertical));

    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        if(isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }
        
    }
    private void FixedUpdate()
    {
        if(isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical *speed);
        }
        else
        {
            rb.gravityScale = 7f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
            animator.SetBool("IsLadderMoving", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
            animator.SetBool("IsLadderMoving", false);
        }
    }
}
