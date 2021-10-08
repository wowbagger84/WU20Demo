using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public GameObject bullet;
    private float timer;
    private float fireRate = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (Input.GetButton("Fire1") && timer > fireRate)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            timer = 0;
        }
    }
}
