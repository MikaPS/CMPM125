using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth;
    public Player1 currentHealth;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth.eH.enemyHealth == 0){
            enemy.SetActive(false);    
        }
    }
}
