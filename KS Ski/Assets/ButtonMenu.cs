using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMenu : MonoBehaviour
{
    public void restart()
    {
        FindObjectOfType<PlayerCollision>().killPlayer();
    }

    public void pause()
    {
        FindObjectOfType<GameManager>().pauseGame();
        GameObject[] textList = GameObject.FindGameObjectsWithTag("PausedText");
        textList[0].SetActive(true);
    }    
}
