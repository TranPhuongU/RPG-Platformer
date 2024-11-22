using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeHitEnemy : MonoBehaviour
{
    public HPBarEnemy healthBar;
    public float HitPoints;
    public float MaxHitPoints = 5f;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        HitPoints = MaxHitPoints;
        healthBar.SetHealth(HitPoints, MaxHitPoints);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeHit(float damage)
    {
        HitPoints -= damage;
        animator.SetTrigger("TakeHit");
        healthBar.SetHealth(HitPoints, MaxHitPoints); // Cập nhật thanh máu ngay sau khi bị giảm HP
        if (HitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }

}
