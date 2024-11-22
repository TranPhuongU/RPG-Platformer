using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;
    Player player;
    public int minDame;
    public int maxDame;
    
    // Start is called before the first frame update
    void Start()
    {
        
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 2);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Lấy đối tượng Player
            Player player = collision.GetComponent<Player>();
            if (player != null && player.isDashing)
            {
                return; // Không làm gì nếu Player đang Dash
            }

            // Tính sát thương
            int dame = Random.Range(minDame, maxDame);
            player.TakeDamage(dame);
            Destroy(gameObject);
        }
    }

}
