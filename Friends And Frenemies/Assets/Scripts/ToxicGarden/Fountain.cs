using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fountain : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   private void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
        {
            Player1 players = collision.gameObject.GetComponent<Player1>();
            int rand = Random.Range(1, 6);

            if (rand == 1) {
                players.speed += 2;
            }
            else if (rand == 2) {
                players.speed -= 2;
            } 
            else if (rand == 3) {
                // reduce food
            } 
            else {
                InventoryManager.ResourceType objectToAdd = InventoryManager.ResourceType.badWater;
                InventoryManager.inventoryManager.AddResource(objectToAdd, 1);
                InventoryManager.inventoryManager.PrintInventory();
            }

        }
    }
}
