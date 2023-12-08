using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollower : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    public float speed;
    public float distanceBetween;

    private float distance;

    public int playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 100;    
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if(distance < distanceBetween){
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            animator.SetBool("follow", true);
        }
                    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player1" || collision.collider.tag == "Player2")
        //if(collision.gameObject.name == "pinksquare")
        {
            animator.SetBool("attacking", true);
            playerHealth -= 5;
            //Debug.Log("This is the player's health");
            //Debug.Log(playerHealth);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player1" || collision.collider.tag == "Player2")
        //if(collision.gameObject.name == "pinksquare")
        {
            animator.SetBool("attacking", false);
            
            //playerHealth -= 5;
            //Debug.Log("This is the player's health");
            //Debug.Log(playerHealth);
        }
    }
}
