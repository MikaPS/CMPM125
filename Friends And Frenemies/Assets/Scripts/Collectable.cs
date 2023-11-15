using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    public void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player1" || collider.gameObject.tag == "Player2")
        {
            gameObject.SetActive(false);
        }
    }
}
