using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameEnded = false;

    public void endGame()
    {
        if(!gameEnded)
        {
            Debug.Log("GAME OVER");
            gameEnded = true;
            StartCoroutine(restartGame());
        }
    }

    IEnumerator restartGame()
    {
        Debug.Log("Game restart");
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
    }

    public void resumeGame()
    {
        Time.timeScale = 1;    }
}
