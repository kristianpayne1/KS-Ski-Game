using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject[] coins;
    float randomTime;
    public float nextSpawn;
    public GameObject player;
    private PlayerMovement movement;
    // Start is called before the first frame update
    void Start()
    {
        nextSpawn = Random.Range(0f,5f);
        movement = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn)
        {
            SetRandomTime();
            nextSpawn = Time.time + randomTime;
            if(movement.isMoving == true)
            {
                spawnCoins();
            }
        }
    }

    void SetRandomTime()
    {
        randomTime = Random.Range(1f, 10f);
    }

    void spawnCoins()
    {
        
        Vector3 newPoint = new Vector3(Random.Range(-25, 25), 0, 150);
        int coinlength = coins.Length;
        int coinShape = Mathf.RoundToInt(Random.Range(0f, coinlength - 1));
        Debug.Log(coinShape);
        Instantiate(coins[coinShape], newPoint, Quaternion.identity);     
    }
}
