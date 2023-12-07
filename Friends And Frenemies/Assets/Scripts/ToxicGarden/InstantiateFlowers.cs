using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateFlowers : MonoBehaviour
{
    public GameObject objectToSpawn;
    public int numberOfObjects = 10;
    public float xMinRange = -50;
    public float xMaxRange = 60;
    public float yMinRange = -40;
    public float yMaxRange = 25;
    private float maxAttempts = 20; // max number of attempts to find a position to spawn

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        // Debug.Log("xmin: " + xMinRange + " xmax: " + xMaxRange  + " ymin: " + yMinRange  + " ymax: " +  yMaxRange);
        for (int i = 0; i < numberOfObjects; i++)
        {
            spawn();
        }
    }

    private void spawn() {
        // Has multiple attemps to find a location with no other objects
        for (int j = 0; j < maxAttempts; j++) {
            // Spawns it in an offset from the spawner
            Vector3 spawnPosition = new Vector3(Random.Range(xMinRange, xMaxRange), Random.Range(yMinRange, yMaxRange), 0f);
            // Check if there are objects in the area 
            if (!ObjectsInArea(spawnPosition))
            {
                // Instantiate the object at the calculated position
                GameObject newObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

                // Optionally, you can parent the new object to the spawner
                newObject.transform.parent = transform;
                break;
            }
        }   
    }

     private bool ObjectsInArea(Vector3 position)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 1.0f);
        if (colliders.Length > 0)
        {
                return true;
        }
        return false; 
    }
}
