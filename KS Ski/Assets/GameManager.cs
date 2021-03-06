﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameEnded = false;
    [SerializeField]
    private GameObject player = null;
    [SerializeField]
    private new GameObject camera = null;
    private Transform playerTransform;

    void Start()
    {
        playerTransform = player.transform;
        Application.targetFrameRate = 60;
    }

    public void endGame()
    {
        if(!gameEnded)
        {
            Debug.Log("GAME OVER");
            gameEnded = true;
            camera.GetComponent<CameraShaker>().shouldShake = true;
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
        Time.timeScale = 1;    
    }

    // private void rerootWorld()
    // {
    //     Debug.Log("Re-rooting world");
    //     Vector3 cameraOffset = camera.GetComponent<FollowPlayer>().getCurrentOffset();
    //     player.SetActive(false);
    //     TrailRenderer[] trails = player.GetComponentsInChildren<TrailRenderer>();
    //     foreach (TrailRenderer t in trails)
    //     {
    //         t.Clear();
    //     }
    //     playerTransform.position = new Vector3(0,playerTransform.position.y,0);
    //     player.SetActive(true);
    //     camera.transform.position = new Vector3(playerTransform.position.x+cameraOffset.x, playerTransform.position.y+cameraOffset.y, playerTransform.position.z+cameraOffset.z);
    // }
}
