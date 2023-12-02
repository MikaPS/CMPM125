using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(healthAmount <= 0)
        {
            Debug.Log("Game Over");
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            healthAmount -= 5;
            healthBar.fillAmount = healthAmount /100f;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            healthAmount += 5;
            healthAmount = Mathf.Clamp(healthAmount, 0, 100);
            healthBar.fillAmount = healthAmount / 100f;
        }
    }

   
}
