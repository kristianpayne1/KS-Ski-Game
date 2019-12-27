using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fps : MonoBehaviour
{
    public Text fpsCounter;

    // Update is called once per frame
    void Update()
    {
        fpsCounter.text = "FPS: " + (1.0f / Time.deltaTime).ToString("0");
    }
}
