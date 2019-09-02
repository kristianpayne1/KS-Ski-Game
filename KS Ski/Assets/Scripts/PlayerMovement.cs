using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardForce;  // creates acceleration 
    public float maxVelocity = 25;  // used to cap how fast a player can move
    private float sqrMaxVelocity;   // cached square velocity, used because its "quicker"
    public float rotSpeed = 10; // rotation speed
    public Rigidbody rigidbody;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();    // get the camera
        sqrMaxVelocity = maxVelocity * maxVelocity;     // calculate sqr velocity, only done once
    }

    void FixedUpdate()
    {
        // How much the player is facing downwards, returns a float between 0 - 1
        float downhillPower = Vector3.Dot(transform.forward, Vector3.forward);
        movePlayer(downhillPower);

        // touch controls
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            movementControls(touch.position);
        }else if (Input.GetMouseButton(0)){
            //mouse controls 
            movementControls(Input.mousePosition);
        }

        // if player falls through ground (not really possible but just in case)
        if(rigidbody.position.y < -1f)
        {
            FindObjectOfType<GameManager>().endGame();
        }

        // limits player speed (v v naughty, ideally would increase player drag instead)
        if(rigidbody.velocity.sqrMagnitude > sqrMaxVelocity)
        {
            rigidbody.velocity = rigidbody.velocity.normalized * maxVelocity;
        }
    }

    //handles where player looks, using ray casting
    //takes the current position of mouse or finger as param
    void movementControls(Vector3 tPos)
    {
        // create ray from camera
        Ray cameraRay = mainCamera.ScreenPointToRay(tPos);
        // create virtual plane where ground is
        Plane groundPlane = new Plane (Vector3.up, Vector3.zero);
        float rayLength;    //ray length

        // if ray hits ground
        if(groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            // for debugging only
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.red);

            // gets position where ray hit
            Vector3 target = new Vector3(pointToLook.x, transform.position.y, pointToLook.z);

            //rotate player in direction of target (smoothly)
            Quaternion targetRotation = Quaternion.LookRotation(target - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotSpeed*Time.deltaTime);
        }
    }

    // handles speed the player moves
    void movePlayer(float downhillPower)
    {
        // for when the player is facing downhill
        if(downhillPower > 0)
        {
            // facing directly downhill
            if(downhillPower >= 0.9)
            {
                rigidbody.AddForce(transform.forward * forwardForce * Time.deltaTime);
            }
            else if(downhillPower < 0.9 && downhillPower >= 0.7)    //facing bottom left/right of screen
            {
                rigidbody.drag = 1;
                rigidbody.AddForce(transform.forward * (forwardForce * 0.8f) * Time.deltaTime);
            }else if(downhillPower < 0.7 && downhillPower >= 0.5)   //facing mostly right/left-ish
            {
                rigidbody.drag = 2;
                rigidbody.AddForce(transform.forward * (forwardForce * 0.7f) * Time.deltaTime);
            }else if(downhillPower < 0.5 && downhillPower >= 0.3)   // nearly facing completely left/right
            {
                rigidbody.drag = 3;
                rigidbody.AddForce(transform.forward * (forwardForce * 0.6f) * Time.deltaTime);
            }
        }else{  //for backwards movement (a little weird)
            if(downhillPower <= -0.9)
            {
                rigidbody.AddForce(transform.forward * -forwardForce * Time.deltaTime);
            }else if(downhillPower > -0.9 && downhillPower <= -0.7)
            {
                rigidbody.drag = 1;
                rigidbody.AddForce(transform.forward * (-forwardForce * 0.8f) * Time.deltaTime);
            }else if(downhillPower > -0.7 && downhillPower <= -0.5)
            {
                rigidbody.drag = 2;
                rigidbody.AddForce(transform.forward * (-forwardForce * 0.7f) * Time.deltaTime);
            }else if(downhillPower > -0.5 && downhillPower <= -0.3)
            {
                rigidbody.drag = 3;
                rigidbody.AddForce(transform.forward * (-forwardForce * 0.6f) * Time.deltaTime);
            }
        }
    }
}
