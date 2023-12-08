using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public static SoundEffects AudioManager;
    public AudioSource source;
    public AudioClip pickup, runningWater, drinkWater, hit;
    // Start is called before the first frame update
    void Awake()
    {
        if (AudioManager == null)
            AudioManager = this;
        else
            Destroy(AudioManager);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playRunningWater() {
        source.clip = runningWater;
        source.Play();
    }
    
    public void playPickUp() {
        source.clip = pickup;
        source.Play();
    }

    public void playDrinkWater() {
        source.clip = drinkWater;
        source.Play();
    }
    
     public void playHit() {
        source.clip = hit;
        source.Play();
    }
}
