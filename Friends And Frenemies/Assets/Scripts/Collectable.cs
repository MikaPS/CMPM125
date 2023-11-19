using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Collectable : MonoBehaviour
{
    public Text woodCount;
    private static int count = 0; // Static since all wood objects have the script
    public void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player1" || collider.gameObject.tag == "Player2")
        {
            gameObject.SetActive(false);
            count += 1;
            woodCount.text = "Wood: " + count;
        }
    }
}
