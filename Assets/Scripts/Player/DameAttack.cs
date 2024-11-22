using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DameAttack : MonoBehaviour
{
    public GameObject hitbox =  default;

    private bool attacking = false;

    private float timeToAttack = 0.25f;
    private float Timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        hitbox = transform.GetChild(0).gameObject;
    }

    void Update()
    {
      if(Input.GetMouseButtonDown(0))
        {
            Attack();
        }
      if(attacking)
        {
            Timer += Time.deltaTime;

                if(Timer >= timeToAttack )
            {
                Timer = 0f;
                attacking = false;
                hitbox.SetActive(attacking);
            }
        }
    }
    private void Attack()
    {
        attacking = true;
        hitbox.SetActive(attacking);
    }
}
