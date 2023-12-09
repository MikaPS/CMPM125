using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnDeath : MonoBehaviour
{
    private PlayerHealth health;
    private FoodBar food;
    private HealthManager hM;
    private bool switched = false;

    public static OnDeath deathManager;
     void Awake()
    {
        if (deathManager == null)
        {
            deathManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        health = FindObjectOfType<PlayerHealth>();    
        food = FindObjectOfType<FoodBar>();  
        hM = FindObjectOfType<HealthManager>();  
    }

    // Update is called once per frame
    void Update()
    {
        if(health.health <= 0 || food.foodSlider.value <= 0){
            if(!switched){
                // Debug.Log("called");
                //Destroy(hM);
                switched = true;
                food.gameObject.SetActive(false);
                SceneManager.LoadScene("Death");
            }
        }
    }
}
