using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardForce;
    public float maxVelocity = 25;
    private float sqrMaxVelocity;
    public float rotSpeed = 10;
    public Rigidbody rigidbody;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        sqrMaxVelocity = maxVelocity * maxVelocity;
    }

    void FixedUpdate()
    {
        float downhillPower = Vector3.Dot(transform.forward, Vector3.forward);
        movePlayer(downhillPower);

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            movementControls(touch.position);
        }else if (Input.GetMouseButton(0)){
            movementControls(Input.mousePosition);
        }

        if(rigidbody.position.y < -1f)
        {
            FindObjectOfType<GameManager>().endGame();
        }

        if(rigidbody.velocity.sqrMagnitude > sqrMaxVelocity)
        {
            rigidbody.velocity = rigidbody.velocity.normalized * maxVelocity;
        }
    }

    void movementControls(Vector3 tPos)
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(tPos);
        Plane groundPlane = new Plane (Vector3.up, Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);

            Debug.DrawLine(cameraRay.origin, pointToLook, Color.red);

            Vector3 target = new Vector3(pointToLook.x, transform.position.y, pointToLook.z);
            Quaternion targetRotation = Quaternion.LookRotation(target - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotSpeed*Time.deltaTime);
        }
    }

    void movePlayer(float downhillPower)
    {
        if(downhillPower > 0)
        {
            if(downhillPower >= 0.9)
            {
                rigidbody.AddForce(transform.forward * forwardForce * Time.deltaTime);
            }else if(downhillPower < 0.9 && downhillPower >= 0.7)
            {
                rigidbody.drag = 1;
                rigidbody.AddForce(transform.forward * (forwardForce * 0.8f) * Time.deltaTime);
            }else if(downhillPower < 0.7 && downhillPower >= 0.5)
            {
                rigidbody.drag = 2;
                rigidbody.AddForce(transform.forward * (forwardForce * 0.7f) * Time.deltaTime);
            }else if(downhillPower < 0.5 && downhillPower >= 0.3)
            {
                rigidbody.drag = 3;
                rigidbody.AddForce(transform.forward * (forwardForce * 0.6f) * Time.deltaTime);
            }
        }else{
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
