using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public KeyCode MoveUp;
    public KeyCode MoveDown;
    public KeyCode MoveLeft;
    public KeyCode MoveRight;
    public float speed;
    public KeyCode Attack;
    public bool attack;

    public EnemyHealth eH;
    public RabbitHealth rH;

    void Start()
    {
        speed = 10f;
        attack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(MoveUp)){
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        if(Input.GetKey(MoveDown)){
            transform.Translate(-Vector2.up * speed * Time.deltaTime);
        }
        if(Input.GetKey(MoveLeft)){
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
        }
        if(Input.GetKey(MoveRight)){
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        if(Input.GetKeyDown(Attack)){
            attack = true;
        }
        

    }

     private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "enemy" && attack)
        //if(collision.gameObject.name == "pinksquare")
        {
            Debug.Log("Enemy gonna get attacked homie");
            eH.enemyHealth -= 1;
            Debug.Log("Health of enemy:");
            Debug.Log(eH.enemyHealth);

        }

        if(collision.gameObject.name == "rabbit" && attack)
        {
            rH.rabbitHealth -= 1;
            Debug.Log("Attacking rabbit");
            //Rabbit health go down
        }
    }
}
