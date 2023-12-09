using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fountain : MonoBehaviour
{
    public Sprite speedUp;
    public Sprite speedDown;
    public Sprite healthDown;
    public Sprite waterUp;

    public PlayerHealth ph;

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
            string currentPlayer = collision.gameObject.tag;

            Player1 players = collision.gameObject.GetComponent<Player1>();
            int rand = Random.Range(1, 6);
            if (rand == 1) {
                TextNextToPlayer.textEffects.updateSprite(currentPlayer, speedUp);
                players.speed += 2;
            }
            else if (rand == 2) {
                if (players.speed >= 5) {
                    TextNextToPlayer.textEffects.updateSprite(currentPlayer, speedDown);
                    players.speed -= 2;
                }
            } 
            else if (rand == 3) {
                TextNextToPlayer.textEffects.updateSprite(currentPlayer, healthDown);
                ph.TakeDamage(3);
                // reduce health
            } 
            else {
                SoundEffects.AudioManager.playRunningWater();
                TextNextToPlayer.textEffects.updateSprite(currentPlayer, waterUp);
                InventoryManager.ResourceType objectToAdd = InventoryManager.ResourceType.badWater;
                InventoryManager.inventoryManager.AddResource(objectToAdd, 1);
                InventoryManager.inventoryManager.PrintInventory();
            }

        }
    }
}
