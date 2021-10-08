using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootMovement : MonoBehaviour
{
    public GameObject enemyBullet;  //Ref. to our bullet, connect in Unity
    
    private GameObject target;   //The player, that we want to kill
    private Vector3 moveTarget; //where we want to go.
    private float timer;        //Counts time
    private float actionRate = 2.5f;   //how often we can do stuff
    public Sprite normal;
    public Sprite shoot;
    
    // Start is called before the first frame update
    void Start()
    {
        //Find our player/target
        target = GameObject.Find("Player");
        
        //select where to go
        SelectMoveTarget();
    }

    private void SelectMoveTarget()
    {
        //calculate x and y distance
        float xDist = transform.position.x - target.transform.position.x;
        float yDist = transform.position.y - target.transform.position.y;
        
        //start moveTarget calculation
        moveTarget = transform.position;
        
        //decide if we want to go in x or y dir
        if (Mathf.Abs(xDist) > Mathf.Abs(yDist))
        {
            //move in the x direction
            moveTarget.x -= xDist;
        }
        else
        {
            //move in the y direction
            moveTarget.y -= yDist;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        //Move us towards move target.
        transform.position = Vector3.MoveTowards(transform.position, moveTarget, Time.deltaTime);

        //when we reach move target
        if (timer > actionRate)
        {
            timer = 0;
            
            if (target == null)
                return;
            
            //random choice what to do
            int rand = Random.Range(0, 3);
            switch (rand)
            {
                case 0:
                    moveTarget = transform.position;
                    GetComponent<SpriteRenderer>().sprite = shoot;
                    Invoke(nameof(Shoot), 0.5f);
                    break;
                default:
                    GetComponent<SpriteRenderer>().sprite = normal;
                    SelectMoveTarget();
                    break;
            }
        }
    }

    private void Shoot()
    {
        if (target == null)
            return;
        
        Vector3 targetPos = target.transform.position;
        targetPos -= transform.position;

        Vector3 spawnPos = transform.position + new Vector3(0, -0.3f, 0);
        
        GameObject newBullet = Instantiate(enemyBullet, spawnPos, Quaternion.identity);
        newBullet.transform.up = targetPos;
    }
}
