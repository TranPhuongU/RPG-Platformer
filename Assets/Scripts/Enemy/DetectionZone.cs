using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectionZone : MonoBehaviour
{
    //public UnityEvent noCollidersRemain;

    public List<Collider2D>detectedColliders = new List<Collider2D>();
    Collider2D col;
    
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        detectedColliders.Add(collision);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        detectedColliders.Remove(collision);
        //enemy quay đầu khi tới cuối đường
        //if (detectedColliders.Count <= 0 )
        //{
        //    noCollidersRemain.Invoke();
        //}
    }
}
