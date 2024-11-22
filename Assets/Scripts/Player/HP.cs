using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HP : MonoBehaviour
{
    public int maxHP;
    public int currentHP;

    public float safeTime = 1f;// time bat tu
    float m_safeTimeCooldown;//time dem nguoc
    private HealthBar healthBar;

    //Goi ra cac ham duoc gan vao onDeath
    public UnityEvent onDeath;

    private void OnEnable()
    {
        //them cac ham vao su kien onDeath
        onDeath.AddListener(Death);
    }
    private void OnDisable()
    {
        onDeath.RemoveListener(Death);
    }

    private void Start()
    {
        currentHP = maxHP;
        healthBar = FindAnyObjectByType<HealthBar>();
        healthBar.UpdateBar(currentHP, maxHP);
    }
    public void TakeDame(int damage)
    {
        if (m_safeTimeCooldown <= 0)
        {
            currentHP -= damage;

            if (currentHP < 0)
            {
                currentHP = 0;
                onDeath.Invoke();
            }
            m_safeTimeCooldown = safeTime;
            //healthBar.UpdateBar(currentHP, maxHP);
            healthBar.UpdateBar(currentHP, maxHP);
        }
    }
    public void Death()
    { 
        Destroy(gameObject) ;
    }
    private void Update()
    {
        m_safeTimeCooldown -= Time.deltaTime;
        
    }
    
}
