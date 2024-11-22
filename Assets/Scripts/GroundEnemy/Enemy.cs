using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Player player;
    public int minDamage;
    public int maxDamage;
    HP hp;
    

    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<Player>();
            InvokeRepeating("DamagePlayer", 0, 0.1f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = null;
            CancelInvoke("DamagePlayer");
            //Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }

    void DamagePlayer()
    {
        if (player != null) // Kiểm tra null trước khi gọi
        {
            if (player.isDashing)
            {
                return;
            }
            int damage = Random.Range(minDamage, maxDamage);
            player.TakeDamage(damage);
        }
    }
}
