using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public PlayerHealth pH;
    public static HealthManager healthManager;

     void Awake()
    {
        if (healthManager == null)
        {
            healthManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("This is the player's health:");
        //Debug.Log(pH.health);
        healthBar.fillAmount = pH.health /100f;
        
        
        
        
        //}

        /*if(Input.GetKeyDown(KeyCode.Y))
        {
            healthAmount += 5;
            healthAmount = Mathf.Clamp(healthAmount, 0, 100);
            healthBar.fillAmount = healthAmount / 100f;
        }*/
    }

    
}
