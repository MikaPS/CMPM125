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
        Debug.Log("Before" + pH.health);
        healthBar.fillAmount = pH.health /100f;
        Debug.Log("After" + pH.health);
    }

    
}
