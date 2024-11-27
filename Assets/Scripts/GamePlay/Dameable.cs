using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dameable : MonoBehaviour
{
    public UnityEvent<int, Vector2> dameableHit;
    Animator animator;
    [SerializeField]
    public int _maxHealth = 100;
    public int MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
        }
    }
    [SerializeField]
    private int _health = 100;

    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            if (_health <= 0)
            {
                IsAlive = false;
            }
        }
    }
    [SerializeField]
    private bool _isAlive = true;
    [SerializeField]
    // bất tử
    private bool isInvincible = false;

    private float timeSinceHit = 0;
    // thời gian bất tử
    public float invincibilityTimer;

    [SerializeField]
    public bool IsAlive
    {
        get
        {
            return _isAlive;
        }
        set
        {
            _isAlive = value;
            animator.SetBool("isAlive", value);
        }
    }

    public bool LockVelocity
    {
        get
        {
            return animator.GetBool("lockVelocity");
        }
        set
        {
            animator.SetBool("lockVelocity", value);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isInvincible)
        {
            if (timeSinceHit > invincibilityTimer)
            {
                isInvincible = false;
                timeSinceHit = 0;
            }
            timeSinceHit += Time.deltaTime;
        }
        
       
    }
    //returns whether the damageable took damage or not
    public bool Hit(int damage, Vector2 knockback)
    {
      if (IsAlive && !isInvincible)
        {
           Health -= damage;
           isInvincible = true;
            LockVelocity = true;
            animator.SetTrigger("hit");
            dameableHit?.Invoke(damage, knockback);
            CharacterEvents.characterDamaged.Invoke(gameObject, damage);

           return true;
        }
      else
        {
            // unable to be hit
            return false;
        }
    }
}
