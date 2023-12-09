using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Collectable : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player1" || collider.gameObject.tag == "Player2")
        {
            if (tag == "Stone") {
                // stoneCount += 1;
                // countText.text = "" + stoneCount;
                InventoryManager.inventoryManager.AddResource(InventoryManager.ResourceType.Stone, 1);
                InventoryManager.inventoryManager.PrintInventory();
                SoundEffects.AudioManager.playPickUp();

            } else if (tag == "Apple") {
                InventoryManager.inventoryManager.AddResource(InventoryManager.ResourceType.Apple, 1);
                InventoryManager.inventoryManager.PrintInventory();
                SoundEffects.AudioManager.playPickUp();
                // FoodBar.foodManager.UpdateFood(5);
            }
             else {
                InventoryManager.inventoryManager.AddResource(InventoryManager.ResourceType.Wood, 1);
                InventoryManager.inventoryManager.PrintInventory();
                SoundEffects.AudioManager.playPickUp();
                // woodCount += 1;
                // countText.text = "" + woodCount;
            }
            Destroy(gameObject);
        }
    }
}
