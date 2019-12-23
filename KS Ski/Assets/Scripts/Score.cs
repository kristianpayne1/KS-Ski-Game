using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform movObject;
    public Text scoreText;
    // Update is called once per frame
    void Update()
    {
        float scoreNo = -movObject.position.z / 10;
        scoreText.text = scoreNo.ToString("0");
    }
}
