using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public Player1 p;
    public GameObject enemy;
    //public bool dead;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        //dead = false;      
    }

    void Update(){
        
    }

    public void EnemyTakeDamage(int amount){
        health -= amount;
        if(health <= 0){
            enemy.SetActive(false);
            //Debug.Log("Enemy dies");
            //dead = true;
        }
    }
}
