using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingThorneBush : MonoBehaviour
{
    private GameObject player1;
    private GameObject player2;

    private float xRange = 3f;
    private float yRange = 3f;

    private float maxDist = 3.5f;
    private Transform playerLocation1;
    private Transform playerLocation2;


    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");

        playerLocation1 = player1.transform;
        playerLocation2 = player2.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float dist1 = Vector2.Distance(transform.position, playerLocation1.position);
        float dist2 = Vector2.Distance(transform.position, playerLocation2.position);

        if (dist1 <= maxDist || dist2 <= maxDist) {
            Vector3 currentPos = transform.position;
            // Calculate the new position
            Vector3 newPosition = new Vector3(currentPos.x + Random.Range(-xRange, xRange), currentPos.y + Random.Range(-yRange, yRange), currentPos.z);
            // Move the object to the new position
            transform.position = newPosition;
        }
    }
}
