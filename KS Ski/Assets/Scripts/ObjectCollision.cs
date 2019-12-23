using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= 50)
        {
            transform.position = new Vector3(-transform.position.x + 2, transform.position.y, transform.position.z);
        }else if(transform.position.x <= -50)
        {
            transform.position = new Vector3(-transform.position.x - 2, transform.position.y, transform.position.z);
        }else if (transform.position.z <= -30)
        {
            bool foundGround = false;
            while(foundGround == false)
            {
                Vector3 newPoint = new Vector3(Random.Range(-50, 50), transform.position.y, transform.position.z + 150);
                RaycastHit hit;
                //makes sure object is above ground
                if (Physics.Raycast(newPoint, Vector3.down, out hit) && hit.collider.CompareTag("Ground")) 
                {
                  transform.position = newPoint;
                  foundGround = true;
                }
            }
        }
    }

    void OnCollisonEnter(Collision other)
    {
        Debug.Log("Object hit");
        
    }
}
