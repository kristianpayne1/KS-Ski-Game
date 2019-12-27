using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameObject Coins;
    private CoinsScript coinsScript;

    // Start is called before the first frame update
    void Start()
    {
        Coins = GameObject.FindWithTag("Coins");
        coinsScript = Coins.GetComponent<CoinsScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate (0,50*Time.deltaTime,0);

        if(transform.position.x >= 50)
        {
            transform.position = new Vector3(-transform.position.x + 2, transform.position.y, transform.position.z);
        }else if(transform.position.x <= -50)
        {
            transform.position = new Vector3(-transform.position.x - 2, transform.position.y, transform.position.z);
        }else if (transform.position.z <= -40)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Collider>().tag == "Player")
        {
            Destroy(this.gameObject);
            coinsScript.gainCoins(1);
        }
    }
}
