using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsScript : MonoBehaviour
{
    public static int coins= 0;
    public Text coinsText;

    void Start()
    {
        coins = 0;
    }
  
    // Update is called once per frame
    void Update()
    {
        int value = coins / 2;
        coinsText.text = "Coins: " +  value.ToString("0");
    }

    public void gainCoins(int amount) 
    {
        coins += amount;
    }
}
