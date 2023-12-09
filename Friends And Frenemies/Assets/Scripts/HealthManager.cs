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
private bool switched = false;
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
        pH = GameObject.FindObjectOfType<PlayerHealth>();
    }

    
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 3) {
            pH = GameObject.FindObjectOfType<PlayerHealth>();
        }
        healthBar.fillAmount = pH.health /100f;
       if(pH.health <= 0){
            if(!switched){
                // Debug.Log("called");
                //Destroy(hM);
                switched = true;
                SceneManager.LoadScene("Death");
            }
        }
    }    
}
