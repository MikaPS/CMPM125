using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnDeath : MonoBehaviour
{
    public PlayerHealth deadOrAlive;
    //private HealthManager healthManager;
    private FoodBar food;
    void Start()
    {
        //healthManager = FindObjectOfType<HealthManager>();    
        food = FindObjectOfType<FoodBar>();  
    }

    // Update is called once per frame
    void Update()
    {
        if(deadOrAlive.dead == true || food.foodSlider.value <= 0){
            SceneManager.LoadScene("Death");
        }
    }
}
