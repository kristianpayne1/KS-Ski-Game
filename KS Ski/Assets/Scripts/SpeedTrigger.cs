using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedTrigger : MonoBehaviour
{
    //this was only used for testing player speeds
    void OnTriggerEnter(Collider other) 
    {
        Debug.Log(other.GetComponent<Rigidbody>().velocity.magnitude);
    }
}
