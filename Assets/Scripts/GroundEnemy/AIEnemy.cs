using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class AIEnemy : MonoBehaviour
{
    public float speed;
    public float circleRadius;
    private Rigidbody2D EnemyRB;
    public GameObject groundCheck;
    public LayerMask groundLayer;
    public bool facingRight;
    public bool isGounded;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        EnemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", EnemyRB.velocity.sqrMagnitude);
        EnemyRB.velocity = Vector2.right * speed * Time.deltaTime;
        isGounded = Physics2D.OverlapCircle(groundCheck.transform.position, circleRadius, groundLayer);
        if( !isGounded && facingRight)
        {
            Flip();
        }
        else if(!isGounded && !facingRight)
        {
            Flip();
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(new Vector3(0,180,0));
        speed = -speed;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.transform.position, circleRadius);    
    }
}
