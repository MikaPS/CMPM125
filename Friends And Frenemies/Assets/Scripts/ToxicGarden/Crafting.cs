using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour
{
    public static Crafting craftingManager;

    private int currentSelect = -1; // 0=right, 1=left, 2=eat
    public Button rightItem;
    public Button leftItem;
    public Button eatItem;
    public Sprite sprite;

    void Awake()
    {
        // gameObject.SetActive(!gameObject.activeSelf);
        if (craftingManager == null)
        {
            craftingManager = this;
            DontDestroyOnLoad(gameObject);
            // openWindow();
            closeWindow();
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
        } else if (currentSelect == 2) {
            eatItem.image.sprite = sprite;
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

    public void eat() {
        string food = eatItem.image.sprite.name;
        if (food == "apple") {
            if (InventoryManager.inventoryManager.hasResource(InventoryManager.ResourceType.Apple)) {
                InventoryManager.inventoryManager.useResource(InventoryManager.ResourceType.Apple);
                FoodBar.foodManager.UpdateFood(5);
            }
        }
        else if (food == "redflower") {
            if (InventoryManager.inventoryManager.hasResource(InventoryManager.ResourceType.RedFlower)) {
                InventoryManager.inventoryManager.useResource(InventoryManager.ResourceType.RedFlower);
                FoodBar.foodManager.UpdateFood(7);
            }
        }
        else if (food == "yellowflower") {
            if (InventoryManager.inventoryManager.hasResource(InventoryManager.ResourceType.ToxicMushroom)) {
                InventoryManager.inventoryManager.useResource(InventoryManager.ResourceType.ToxicMushroom);
                FoodBar.foodManager.UpdateFood(-2);
            }
        }
        else if (food == "purpleflower") {
            if (InventoryManager.inventoryManager.hasResource(InventoryManager.ResourceType.MovingThorneBush)) {
                InventoryManager.inventoryManager.useResource(InventoryManager.ResourceType.MovingThorneBush);
                FoodBar.foodManager.UpdateFood(3);
                // also increase health
            }
        }
        else if (food == "gray") {
            if (InventoryManager.inventoryManager.hasResource(InventoryManager.ResourceType.badWater)) {
                InventoryManager.inventoryManager.useResource(InventoryManager.ResourceType.badWater);
                FoodBar.foodManager.UpdateFood(-10);
                SoundEffects.AudioManager.playDrinkWater();
            }
        }
        else if (food == "brightblue") {
            if (InventoryManager.inventoryManager.hasResource(InventoryManager.ResourceType.cleanWater)) {
                InventoryManager.inventoryManager.useResource(InventoryManager.ResourceType.cleanWater);
                FoodBar.foodManager.UpdateFood(5);
                SoundEffects.AudioManager.playDrinkWater();
            }
        }
        else if (food == "darkblue") {
            if (InventoryManager.inventoryManager.hasResource(InventoryManager.ResourceType.darkestWater)) {
                InventoryManager.inventoryManager.useResource(InventoryManager.ResourceType.darkestWater);
                FoodBar.foodManager.UpdateFood(5);
                SoundEffects.AudioManager.playDrinkWater();
            }
        }
        else if (food == "bluegray") {
            if (InventoryManager.inventoryManager.hasResource(InventoryManager.ResourceType.medWater)) {
                InventoryManager.inventoryManager.useResource(InventoryManager.ResourceType.medWater);
                FoodBar.foodManager.UpdateFood(-3);
                SoundEffects.AudioManager.playDrinkWater();
            }
        }
        InventoryManager.inventoryManager.PrintInventory();
    }

    private bool hasItems(string left, string right) {
        if (rightItem.image.sprite.name == left && leftItem.image.sprite.name == right || leftItem.image.sprite.name == left && rightItem.image.sprite.name == right) {
            return true;
        }
        return false;
    }

    public void closeWindow() {
        gameObject.SetActive(false);
    }

     public void openWindow() {
        gameObject.SetActive(true);
    }

    public void toggleVisibility() {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
