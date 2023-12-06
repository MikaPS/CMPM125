using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool attacking = false;
    private float timeToAttack = 0.25f;
    private float timer = 0f;
    public int playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            Debug.Log("Attacking is occuring!!!!!");
            playerHealth -= 5;
            //Debug.Log(playerHealth);
            //Attack();
        }    
        /*if(attacking){
            timer += Time.deltaTime;

            if(timer >= timeToAttack){
                timer = 0;
                attacking = false;
            }
        }*/
    }

    /*private void Attack(){
        attacking = true;
    }*/
}
