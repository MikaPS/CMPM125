using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicMushrooms : MonoBehaviour
{
    public ParticleSystem particles;
    public float rotationSpeed = 50f; // Degrees per second
    public float windChangeTime = 3f;
    public int dmg = 4;
    private float timeSinceLastChange;
    public GameObject collisionContainer;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Start particles
        if (!particles.isPlaying)
        {
            particles.Play();
        }
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        collisionContainer.transform.rotation = Quaternion.identity;

    }

    void OnParticleCollision(GameObject other)

    {
                    Debug.Log("taking damage :(");

        // if (collider.CompareTag("Player1") || collider.CompareTag("Player2"))
        // {
        //     Debug.Log("taking damage :(");
        //     // Reduce player's health
        // }
    }
}
