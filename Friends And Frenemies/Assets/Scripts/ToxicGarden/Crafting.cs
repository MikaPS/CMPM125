using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour
{
    public static Crafting craftingManager;

    private int currentSelect = -1; // 0=right, 1=left
    public Button rightItem;
    public Button leftItem;
    public Sprite sprite;

    void Awake()
    {
        // gameObject.SetActive(!gameObject.activeSelf);
        if (craftingManager == null)
        {
            craftingManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setItem(Button myButton) {
        // Gets sprite
        Image buttonImage = myButton.image;
        if (buttonImage != null)
        {
            sprite = buttonImage.sprite;
        }
        // Sets sprite
        if (currentSelect == 0) {
            rightItem.image.sprite = sprite;
        } else if (currentSelect == 1) {
            leftItem.image.sprite = sprite;
        }
    }

    public void setCurrent(int num) {
        currentSelect = num;
    }

    public void craft() {
        string right = rightItem.image.sprite.name;
        string left = leftItem.image.sprite.name;
        
        if (hasItems("gray" ,"yellowflower")) {
            if (InventoryManager.inventoryManager.hasResource(InventoryManager.ResourceType.ToxicMushroom) && InventoryManager.inventoryManager.hasResource(InventoryManager.ResourceType.badWater)) {
                InventoryManager.inventoryManager.AddResource(InventoryManager.ResourceType.darkestWater, 1);
                InventoryManager.inventoryManager.useResource(InventoryManager.ResourceType.ToxicMushroom);
                InventoryManager.inventoryManager.useResource(InventoryManager.ResourceType.badWater);
                InventoryManager.inventoryManager.PrintInventory();
            }
        } 
        else if (hasItems("gray" ,"redflower")) {
            if (InventoryManager.inventoryManager.hasResource(InventoryManager.ResourceType.RedFlower) && InventoryManager.inventoryManager.hasResource(InventoryManager.ResourceType.badWater)) {
                InventoryManager.inventoryManager.AddResource(InventoryManager.ResourceType.medWater, 1);
                InventoryManager.inventoryManager.useResource(InventoryManager.ResourceType.RedFlower);
                InventoryManager.inventoryManager.useResource(InventoryManager.ResourceType.badWater);
                InventoryManager.inventoryManager.PrintInventory();
            }
        } 
        else if (hasItems("gray" ,"purpleflower")) {
            if (InventoryManager.inventoryManager.hasResource(InventoryManager.ResourceType.MovingThorneBush) && InventoryManager.inventoryManager.hasResource(InventoryManager.ResourceType.badWater)) {
                InventoryManager.inventoryManager.AddResource(InventoryManager.ResourceType.cleanWater, 1);
                InventoryManager.inventoryManager.useResource(InventoryManager.ResourceType.MovingThorneBush);
                InventoryManager.inventoryManager.useResource(InventoryManager.ResourceType.badWater);
                InventoryManager.inventoryManager.PrintInventory();
            }
        } 
    }

    private bool hasItems(string left, string right) {
        if (rightItem.image.sprite.name == left && leftItem.image.sprite.name == right || leftItem.image.sprite.name == left && rightItem.image.sprite.name == right) {
            return true;
        }
        return false;
    }

    public void closeWindow() {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
