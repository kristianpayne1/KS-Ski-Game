using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other) 
    {
        Debug.Log(other.GetComponent<Rigidbody>().velocity.magnitude);
    }
}
