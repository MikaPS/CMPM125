using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFlowerToInv : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("here");
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2")) {
            InventoryManager.ResourceType objectToAdd = InventoryManager.ResourceType.MovingThorneBush;
            if (tag == "RedFlower") {  objectToAdd = InventoryManager.ResourceType.RedFlower;}
            else if (tag == "ToxicMushroom") {  objectToAdd = InventoryManager.ResourceType.ToxicMushroom;}

            InventoryManager.inventoryManager.AddResource(objectToAdd, 1);
            InventoryManager.inventoryManager.PrintInventory();
            Destroy(gameObject);
        }
    }
}
