using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;

    private float width;
    private float height;

    private float spawnRate = 2.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        width = Camera.main.orthographicSize * Camera.main.aspect;
        height = Camera.main.orthographicSize;
        
        Invoke(nameof(Spawn), spawnRate);
    }
    
    void Spawn()
    {
        if (GameObject.Find("Player") == null)
            return;

        Vector3 spawnPoint = Vector3.zero;
        int randDir = Random.Range(0, 4);
        switch (randDir)
        {
            case 0:
                spawnPoint.x = -width - 1;
                spawnPoint.y = Random.Range(-height, height);
                break;
            case 1:
                spawnPoint.x = width + 1;
                spawnPoint.y = Random.Range(-height, height);
                break;
            case 2:
                spawnPoint.y = -height - 1;
                spawnPoint.x = Random.Range(-width, width);
                break;
            case 3:
                spawnPoint.y = height + 1;
                spawnPoint.x = Random.Range(-width, width);
                break;
            default:
                Debug.Log("Something went wrong");
                break;
        }
        
        float rand = Random.Range(0, 1f);

        //40% that we spawn enemy type 1, else spawn type 2
        if (rand < 0.4f)
            Instantiate(enemy1, spawnPoint, transform.rotation);
        else
            Instantiate(enemy2, spawnPoint, transform.rotation);

        if (spawnRate > 0.5f)
        {
            spawnRate -= 0.10f;
        }
        
        Invoke(nameof(Spawn), spawnRate);
    }
}
