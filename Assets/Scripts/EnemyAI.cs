using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 2f;          // Tốc độ di chuyển
    public float moveDistance = 5f;       // Khoảng cách tối đa để di chuyển qua lại
    private Vector3 startPosition;        // Vị trí ban đầu của quái
    private bool isMovingRight = true;    // Biến điều khiển hướng di chuyển

    Animator animator;
    private void Start()
    {
        animator  = GetComponent<Animator>();
        startPosition = transform.position;  // Lưu vị trí ban đầu
        StartCoroutine(MoveLeftRight());     // Bắt đầu coroutine di chuyển qua lại
    }
    private void Update()
    {
        animator.SetFloat("Speed", startPosition.sqrMagnitude);
        QuayMatEnemy();
    }

    // Coroutine di chuyển qua trái phải
    private IEnumerator MoveLeftRight()
    {
        while (true)
        {
            // Di chuyển quái theo hướng trái phải
            if (isMovingRight)
            {
                // Di chuyển sang phải
                transform.position = Vector3.MoveTowards(transform.position, startPosition + Vector3.right * moveDistance, moveSpeed * Time.deltaTime);

                // Nếu quái đã đi đến vị trí tối đa sang phải, thay đổi hướng và dừng lại
                if (Mathf.Abs(transform.position.x - (startPosition.x + moveDistance)) < 0.1f)
                {
                    isMovingRight = false;
                    yield return new WaitForSeconds(1.5f);  // Dừng lại trong 1.5 giây
                }
            }
            else
            {
                // Di chuyển sang trái
                transform.position = Vector3.MoveTowards(transform.position, startPosition - Vector3.right * moveDistance, moveSpeed * Time.deltaTime);

                // Nếu quái đã đi đến vị trí tối đa sang trái, thay đổi hướng và dừng lại
                if (Mathf.Abs(transform.position.x - (startPosition.x - moveDistance)) < 0.1f)
                {
                    isMovingRight = true;
                    yield return new WaitForSeconds(1.5f);  // Dừng lại trong 1.5 giây
                }
            }

            yield return null;  // Đảm bảo coroutine tiếp tục chạy
        }
    }
    public void QuayMatEnemy()
    {
        if (startPosition.x != 0)
        {
            if (startPosition.x > 0)
            {
                transform.localScale = new Vector3(5, 5, 1);
            }
            else
            {
                transform.localScale = new Vector3(-5, 5, 1);
            }
        }
    }
}
