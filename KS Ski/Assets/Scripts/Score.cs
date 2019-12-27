using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform movObject;
    public Text scoreText;
    public float scoreValue;
    // Update is called once per frame

    void Update()
    {
        scoreValue = (-movObject.position.z);
        scoreText.text = "Distance: " + scoreValue.ToString("0");
    }

}
