using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPoint : MonoBehaviour
{
    public int hitPoints = 2;
    public GameObject deathExplosion;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void Hit()
    {
        hitPoints--;

        //If we die
        if (hitPoints <= 0)
        {
            Death();
        }
        else
        {
            GetComponent<AudioSource>().Play();
        }
    }

    public void Death()
    {
        Destroy(gameObject);
        Instantiate(deathExplosion, transform.position, Quaternion.identity);
        FindObjectOfType<ScoreController>().AddScore(100);
    }
}
