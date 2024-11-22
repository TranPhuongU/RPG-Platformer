using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawnDropItem : MonoBehaviour
{
    public GameObject item;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnDropedItem()
    {
        Vector2 playerPos = new Vector2(player.position.x+3 , player.position.y );
        Instantiate(item,playerPos, Quaternion.identity);
    }
}
