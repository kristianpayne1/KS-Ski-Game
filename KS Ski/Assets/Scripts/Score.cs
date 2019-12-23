using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform movObject;
    public Text scoreText;
    public static int points = 0;
    public float scoreValue;
    // Update is called once per frame

    void Start()
    {
        points = 0;
    }

    void Update()
    {
        scoreValue = (-movObject.position.z / 10) + points;
        scoreText.text = scoreValue.ToString("0");
    }

}
