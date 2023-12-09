using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackEnemy : MonoBehaviour
{
    public EnemyHealth enemyHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2"){
            Debug.Log("Enemy attacks players");
            enemyHealth.EnemyTakeDamage(1);
            //Debug.Log("This is the player's health:");
            //Debug.Log(playerHealth.health);
        }
    }
}
