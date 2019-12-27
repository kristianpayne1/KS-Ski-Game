using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    public GameObject Object;
    public GameObject player;
    public Rigidbody rb = null;
    private PlayerMovement playerMov;

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>();
       player = GameObject.FindWithTag("Player");
       playerMov = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Object == null)
        {
            Object = GameObject.FindWithTag("Obstacle");
        }else {
            rb.drag = playerMov.playerDrag;
            rb.AddForce(-playerMov.playerForce);
        }
    }
}
