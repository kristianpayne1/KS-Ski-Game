using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public Rigidbody rigidbody;

    private GameObject ski1;
    private GameObject ski2;

    void Start()
    {
        ski1 = transform.GetChild(0).gameObject;
        ski2 = transform.GetChild(1).gameObject;
    }

    void OnCollisionEnter(Collision other) 
    {
        float speed = rigidbody.velocity.magnitude;
        if (other.collider.tag == "Obstacle")
        {
            Debug.Log(speed);
            if(speed > 5f)
            {
                killPlayer();
            }
        }
    }

    void dropSkis()
    {
        ski1.AddComponent<Rigidbody>(); 
        ski2.AddComponent<Rigidbody>(); 

        ski1.GetComponent<Rigidbody>().AddForce(ski1.transform.forward * 1000 * Time.deltaTime);
        ski2.GetComponent<Rigidbody>().AddForce(ski2.transform.forward * 1000 * Time.deltaTime);

        ski1.transform.parent = null;
        ski2.transform.parent = null;
    }

    public void killPlayer()
    {
        Debug.Log("Bailed!!");
        dropSkis();
        movement.enabled = false;
        FindObjectOfType<GameManager>().endGame();
    }
}
