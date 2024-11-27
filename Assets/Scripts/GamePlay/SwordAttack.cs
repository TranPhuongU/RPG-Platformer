using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public int attackDamage = 10;
    // bị đánh sẽ lùi về sau 1 chút
    public Vector2 knockback = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Dameable dameable = collision.GetComponent<Dameable>();
        if (dameable != null)
        {
            //knockback theo lùi về sau
            Vector2 deliveredKnockback = transform.parent.localScale.x > 0 ? knockback : new Vector2(-knockback.x, knockback.y);

            bool gotHit = dameable.Hit(attackDamage, deliveredKnockback);
            if (gotHit)
            {
                Debug.Log("-10");
            }
            
        }
    }
}
