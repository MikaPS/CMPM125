using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public Animator animator;
    public KeyCode MoveUp;
    public KeyCode MoveDown;
    public KeyCode MoveLeft;
    public KeyCode MoveRight;
    public float speed;
    public KeyCode Attack;
    public bool attack;

    //public EnemyHealth eH;
    public RabbitHealth rH;
    public EnemyHealth enemyHealth;


    private bool isFacingRight;
    private float Move;

    public ParticleSystem blood;

    void Start()
    {
        isFacingRight = true;
        speed = 10f;
        attack = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxisRaw("Horizontal");
        bool isMoving = animator.GetBool("moving");
        bool moving = false;
        
        if(Input.GetKey(MoveUp)){
            moving = true;  
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        if(Input.GetKey(MoveDown)){
            moving = true;
            transform.Translate(-Vector2.up * speed * Time.deltaTime);
        }
        if(Input.GetKey(MoveLeft) && !isFacingRight){
            Move = -1;
            moving = true;
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
        }
        if(Input.GetKey(MoveRight) && isFacingRight){
            Move = 1;
            moving = true;
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        if(!isMoving && moving)
        {
            animator.SetBool("moving", true);
        }
        if (isMoving && !moving)
        {
            animator.SetBool("moving", false);
        }

        if (Input.GetKey(Attack)){
            attack = true;
            animator.SetBool("attacking", true);
        } else
        {
            //attack = false;
            animator.SetBool("attacking", false);
        }

        if(!isFacingRight && Move > 0)
        {
            Flip();
        } else if (isFacingRight && Move < 0)
        {
            Flip();
        }
        
    }
    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    private void OnCollisionStay2D(Collision2D collision){
        if(collision.gameObject.name == "rabbit" && attack)
        {
            blood.Play();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "enemy")
        {
            animator.SetBool("damaged", false);
        }
    }

     private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.gameObject.name == "rabbit" && attack)
        //{
        //    blood.Play();
        //}
        if(collision.gameObject.name == "enemy" && attack)
        {
            animator.SetBool("damaged", true);
            enemyHealth.EnemyTakeDamage(1);


        }
        
        /*if(collision.gameObject.name == "enemy")
        //if(collision.gameObject.name == "pinksquare")
        {
            enemyHealth.EnemyTakeDamage(1);
            Debug.Log("INJURED ENEMY");
            //Debug.Log("Enemy gonna get attacked homie");
            //eH.enemyHealth -= 1;
            //Debug.Log("Health of enemy:");
            //Debug.Log(eH.enemyHealth);

        }*/
        
        
       
    }
}
