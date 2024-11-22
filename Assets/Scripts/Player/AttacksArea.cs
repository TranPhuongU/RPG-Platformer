using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttacksArea : MonoBehaviour
{
    Player player;
    HP hp;

    public int minDame;
    public int maxDame;
    public bool SwordDame;
    private void Start()
    {
        hp = GetComponent<HP>();
    }
    public void TakeDamage(int damage)
    {
        hp.TakeDame(damage);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !SwordDame)
        {
            Debug.Log("danhtrungnguoi");
            int damage = Random.Range(minDame, maxDame);
            collision.GetComponent<Player>().TakeDamage(damage);
            
        }
        if (collision.CompareTag("Enemy") && SwordDame)
        {
            Debug.Log("danhtrungquai");
            int damage = Random.Range(minDame, maxDame);
            collision.GetComponent<TakeHitEnemy>().TakeHit(damage);


        }
        if (collision.CompareTag("Skull") && SwordDame)
        {
            Debug.Log("danhtrungSkull");
            int damage = Random.Range(minDame, maxDame);
            collision.GetComponent<TakeHitEnemy>().TakeHit(damage);
        }
        if (collision.CompareTag("Bullet"))
        {
            Debug.Log("danhtrungBulletl");
            Destroy(collision.gameObject);
        }

    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    var enemy = collision..GetComponent<Skull>();
    //    if (enemy)
    //    {
    //        enemy.TakeHit(1);
    //    }
    //    Destroy(gameObject);
    //}
}
