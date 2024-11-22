using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    public float speed;
    Transform player;
    public int minDame;
    public int maxDame;
    Player player2;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Destroy(this.gameObject, 4);
    }
    private void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed*Time.deltaTime);
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
