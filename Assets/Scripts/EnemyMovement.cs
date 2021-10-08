using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject target;
    private float speed = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        //Find the player
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            //get target position
            Vector3 targetPos = target.transform.position;
            //calculate direction
            targetPos -= transform.position;
        
            //aim towards player/target (minus to flip direction)
            transform.up = -targetPos;
        
            //Move towards player
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HitPoint>().Hit();
            GetComponent<HitPoint>().Death();
        }
    }
}
