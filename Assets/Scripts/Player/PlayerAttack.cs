using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    private int attackIndex = 0;
    private int maxAttackIndex = 4;
    public float timeAttack = 0.25f;
    public float m_timeAttack = 0.25f;
    Player player;
    public float originalSpeed;
    bool hasReducedSpeed = false;
    public float reduceSpeed;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = FindAnyObjectByType<Player>();
        originalSpeed = player.moveSpeed;
    }

    void Update()
    {
        timeAttack -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && timeAttack <= 0) // Ấn chuột trái
        {
            // Kiểm tra và đặt `attackIndex` bắt đầu từ `1` nếu hiện tại là `0`
            if (attackIndex == 0)
            {
                attackIndex = 1;
            }
            else
            {
                attackIndex++;
            }

            if (attackIndex > maxAttackIndex)
            {
                attackIndex = 1; // Reset về 1 nếu vượt quá giới hạn
            }

            timeAttack = m_timeAttack;

            // Thiết lập giá trị `attackIndex` cho Animator
            animator.SetInteger("attackIndex", attackIndex);

            // Giảm tốc độ nếu chưa giảm
            if (!hasReducedSpeed)
            {
                player.moveSpeed -= reduceSpeed;
                hasReducedSpeed = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            player.moveSpeed = originalSpeed; // Khôi phục tốc độ ban đầu
            hasReducedSpeed = false; // Cho phép giảm tốc độ lần tiếp theo khi ấn chuột
        }
    }

    public void ResetAttackIndex()
    {
        // Đặt lại `attackIndex` về 0 thông qua Animation Event
        animator.SetInteger("attackIndex", 0);
        attackIndex = 0; // Đồng bộ giá trị `attackIndex` của script
    }
    public void IsDrinkHP()
    {
        animator.SetBool("isDrinkHP", false);
    }
}
