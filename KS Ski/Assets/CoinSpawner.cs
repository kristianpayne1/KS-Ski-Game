using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinLine;
    float randomTime;
    public float nextSpawn;

    public bool gameEnded = false;
    // Start is called before the first frame update
    void Start()
    {
        nextSpawn = Random.Range(0f,5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn)
        {
            SetRandomTime();
            nextSpawn = Time.time + randomTime;
            spawnCoins();
        }
    }

    void SetRandomTime()
    {
        randomTime = Random.Range(1f, 10f);
    }

    void spawnCoins()
    {
        
        Vector3 newPoint = new Vector3(Random.Range(-25, 25), 0, 150);
            
        Instantiate(coinLine, newPoint, Quaternion.identity);     
    }
}
