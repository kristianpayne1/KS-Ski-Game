using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjects : MonoBehaviour
{

    [SerializeField]
    private Vector3 worldBoundary = new Vector3 (200,0,200);
    [SerializeField]
    private GameObject[] placeableObjects = null;
    [SerializeField]
    private float numObjects = 50;
    public GameObject player;
    private Vector3 distance = new Vector3 (0,0,0);

    // Start is called before the first frame update
    void Start()
    {
        placeObjects();
    }

    // // Update is called once per frame
    // void Update()
    // {
    //     if(player.transform.position.x > distance.x + (worldBoundary.x / 2) 
    //         || player.transform.position.z > distance.z + (worldBoundary.z / 2)
    //         || player.transform.position.x < -distance.x - (worldBoundary.x / 2))
    //     {
    //         distance = new Vector3(player.transform.position.x, 0, player.transform.position.z + (worldBoundary.z/2));
    //         placeObjects();
    //     }
    // }

    //helper methods below
    void placeObjects()
    {
        for(int i = 0; i < numObjects; i++)
        {
            int prefabType = Random.Range(0, placeableObjects.Length);
            Vector3 startPoint = RandomPointAboveGround();
            RaycastHit hit;
            //makes sure object is above ground
            if (Physics.Raycast(startPoint, Vector3.down, out hit) && hit.collider.CompareTag("Ground")) 
            {
                Instantiate(placeableObjects[prefabType], new Vector3(startPoint.x, hit.point.y + 0.8f, startPoint.z), Quaternion.identity);
            }
        }
    }

    //gets a random point
    private Vector3 RandomPointAboveGround() {
        return new Vector3(
            Random.Range(distance.x - worldBoundary.x / 2, distance.x + worldBoundary.x / 2),
            player.transform.position.y * 2,
            Random.Range(distance.z, distance.z + worldBoundary.z)
        );
    }

}
