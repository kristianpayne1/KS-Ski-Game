using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Points : MonoBehaviour
{
    public static int points= 0;
    public Text pointText;

    void Start()
    {
        points = 0;
    }
  
    // Update is called once per frame
    void Update()
    {
        pointText.text = "Points: " +  points.ToString("0");
    }

    public void gainPoints(int amount) 
    {
        points += amount;
    }
}
