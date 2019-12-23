using UnityEngine;
using System.Collections;

public class NearMiss : MonoBehaviour
{
    private GameObject score;
    bool hasBeenMissed = false;

    void Start() {
        score = GameObject.FindWithTag("Score");
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
        if(other.GetComponent<Collider>().tag == "Player" && hasBeenMissed == false)
        {
            Score.points += 10;
            Debug.Log("Near miss!");
            // avoids player gaining double near misses
            hasBeenMissed = true;
        }
    }
}
