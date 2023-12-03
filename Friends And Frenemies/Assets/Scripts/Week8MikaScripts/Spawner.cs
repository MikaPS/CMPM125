using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    private int numberOfObjectsToSpawn;
    private float spawnCooldown = 1f; // Cooldown time in seconds
    private float lastSpawnTime;
    private float duration = 15f;
    private float totalSpawn = 0;
    private float maxAttempts = 20; // max number of attempts to find a position to spawn
    public float scalingPercentage = 100f;
    public int minProb = 1;
    public int maxProb = 3;


    void start() {
    
    }
    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (Time.time - lastSpawnTime > spawnCooldown)
        {
            numberOfObjectsToSpawn = Random.Range(minProb, maxProb);
            totalSpawn += numberOfObjectsToSpawn;
            if (duration <= totalSpawn) {
                Destroy(gameObject);
            }

            for (int i = 0; i < numberOfObjectsToSpawn; i++)
            {
                Spawn();
                lastSpawnTime = Time.time;    
            }
            
        }
        
    }

    private void Spawn()
    {
        // Has multiple attemps to find a location with no other objects
        for (int j = 0; j < maxAttempts; j++) {
            // Spawns it in an offset from the spawner
            Vector3 offset = new Vector3(Random.Range(-6, 6), Random.Range(-6, 6), 0);
            Vector3 spawnPosition = transform.position + offset;
            // Check if tehre are objects in the area 
            if (!PlayerCollision(spawnPosition))
            {
                // Changes size of the spawner based on the duration
                scalingPercentage = 1f - (totalSpawn / duration);
                scalingPercentage = Mathf.Clamp01(scalingPercentage);
                float finalScale = Mathf.Lerp(0.9f, 1f, scalingPercentage);
                transform.localScale = transform.localScale * (finalScale);
                // Spawns the object
                Instantiate(objectToSpawn, spawnPosition, Quaternion.identity).SetActive(true);
                break;
            }
        }   
    }

    // Check if there's an object in the locations before spawning a new object
    private bool PlayerCollision(Vector3 position)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 1.0f);
        if (colliders.Length > 0)
        {
                return true;
        }
        return false; 
    }
}
