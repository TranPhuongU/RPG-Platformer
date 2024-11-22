using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    private Transform player;
    public float shootingRange;
    public GameObject bullet;
    public GameObject bulletParent;
    public float timeFire;
    private float m_timeFire;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        m_timeFire = timeFire;

    }

    // Update is called once per frame
    void Update()
    {
        m_timeFire -= Time.deltaTime;
        float distanceFromPlayer = Vector2.Distance(player.position,transform.position);
        if ( distanceFromPlayer < lineOfSite && distanceFromPlayer>shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);

        }
        else if (distanceFromPlayer <= shootingRange && m_timeFire<=0)
        {
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            m_timeFire = timeFire;
            
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
