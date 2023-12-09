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

    public PlayerHealth ph;

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
        particles.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            ph.TakeDamage(1);
        }
    }
}
