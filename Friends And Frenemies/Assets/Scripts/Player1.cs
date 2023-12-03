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


    void Start()
    {
        speed = 10f;
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
        if(Input.GetKey(Attack)){
            Debug.Log("Attack");
        }

    }
}
