using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public new Rigidbody rigidbody;

    private GameObject ski1;    // left ski
    private GameObject ski2;    // right ski

    void Start()
    {
        // get them ski boi
        ski1 = transform.GetChild(0).gameObject;
        ski2 = transform.GetChild(1).gameObject;
    }

    // if collides with anything
    void OnCollisionEnter(Collision other) 
    {
        //get how fast player was moving
        float speed = rigidbody.velocity.magnitude;
        // if collider was a obstacle
        if (other.collider.tag == "Obstacle")
        {
            Debug.Log(speed);
            // if player was travelling fast enough to bail
            if(speed > 5f)
            {
                Handheld.Vibrate();
                // die b*tch
                killPlayer();
            }
        }
    }

    // for dropping skis when player dies (why don't they keep moving!?!!)
    void dropSkis()
    {
        ski1.AddComponent<Rigidbody>(); 
        ski2.AddComponent<Rigidbody>(); 

        // this doesn't work for some reason ¯\_(ツ)_/¯
        ski1.GetComponent<Rigidbody>().AddForce(ski1.transform.forward * 1000 * Time.deltaTime);
        ski2.GetComponent<Rigidbody>().AddForce(ski2.transform.forward * 1000 * Time.deltaTime);

        // detaches from player
        ski1.transform.parent = null;
        ski2.transform.parent = null;
    }

    // Player bails and restarts game
    public void killPlayer()
    {
        Debug.Log("Bailed!!");
        dropSkis();
        movement.enabled = false;
        FindObjectOfType<GameManager>().endGame();
    }
}
