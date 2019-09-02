using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offSet;
    public float maxSpeed = 20;

    private Rigidbody rb;
    private Vector3 cameraZoom; 

    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
        cameraZoom = new Vector3(0f, offSet.y * 2.5f, offSet.z *2f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // follows player with some lag for that extra smoothness
        float zoomPercentage = (rb.velocity.magnitude / maxSpeed);
        Vector3 tPos =  player.position + (offSet + (cameraZoom * zoomPercentage));
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, tPos, 0.125f);
        transform.position = smoothedPosition;
    }
}

