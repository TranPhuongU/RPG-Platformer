using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    //public GameObject effect;
    private Transform player;
    HP hp;
    HealthBar healthBar;
    Animator animator;
    private Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerAnimator = player.GetComponent<Animator>(); // Lấy Animator từ Player
        healthBar = FindObjectOfType<HealthBar>();
        hp = FindObjectOfType<HP>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Use()
    {
        if (hp != null)
        {
            hp.currentHP += 20; // Cộng thêm máu
            healthBar.UpdateBar(hp.currentHP, hp.maxHP);
        }
        if (playerAnimator != null)
        {
            playerAnimator.SetBool("isDrinkHP", true); // Gọi trigger
        }
        //Instantiate(effect, player.position, Quaternion.identity);// gọi ra animation
        Destroy(gameObject);
    }
}
