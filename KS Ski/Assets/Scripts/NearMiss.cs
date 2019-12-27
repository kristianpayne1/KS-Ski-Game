using UnityEngine;
using System.Collections;

public class NearMiss : MonoBehaviour
{
    private GameObject Points;
    private Points pointsScript;
    bool hasBeenMissed = false;

    void Start() {
        Points = GameObject.FindWithTag("Points");
        pointsScript = Points.GetComponent<Points>();
    }

    void Update()
    {
        if(hasBeenMissed == true)
        {
            StartCoroutine(wait());
            hasBeenMissed = false;
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(3);
    }

    void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<Collider>().tag == "Player" && hasBeenMissed == false && FindObjectOfType<GameManager>().gameEnded == false)
        {
            pointsScript.gainPoints(10);
            Debug.Log("Near miss!");
            // avoids player gaining double near misses
            hasBeenMissed = true;
        }
    }
}
