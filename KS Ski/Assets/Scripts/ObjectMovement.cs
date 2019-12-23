using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private PlayerMovement playerMov;
    public GameObject player;
    public Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerMov = player.GetComponent<PlayerMovement>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.AddForce(-playerMov.playerForce);
        rigidbody.drag = playerMov.playerDrag;
    }
}
