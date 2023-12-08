using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;


public class InventoryManager : MonoBehaviour
{
    public static InventoryManager inventoryManager;
    public Text[] texts;
    public Text winText;

    void Awake()
    {
        if (inventoryManager == null)
        {
            inventoryManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public enum ResourceType
    {
        Wood,
        Stone,
        Apple,
        MovingThorneBush,
        ToxicMushroom,
        RedFlower,
        badWater,
        cleanWater,
        medWater,
        darkestWater,
        
    }

    // [System.Serializable]
    public class Resource
    {
        public ResourceType type;
        public int amount;
    }

    public static List<Resource> resources = new List<Resource>();

    void Start() {
        foreach (ResourceType r in Enum.GetValues(typeof(ResourceType)))
        {
            Resource existingResource = new Resource { type = r, amount = 0 };
            resources.Add(existingResource);
        }
    }

    public void AddResource(ResourceType type, int amount)
    {
        Resource existingResource = resources.Find(r => r.type == type);

        if (existingResource != null)
        {
            existingResource.amount += amount;
        }
        else
        {
            Resource newResource = new Resource { type = type, amount = amount };
            resources.Add(newResource);
        }

    }

    public void RemoveResource(ResourceType type, int amount)
    {
        Resource existingResource = resources.Find(r => r.type == type);

        if (existingResource != null)
        {
            existingResource.amount -= amount;

            if (existingResource.amount <= 0)
            {
                resources.Remove(existingResource);
            }

        }
        else
        {
            Debug.LogWarning("Attempted to remove non-existent resource: " + type);
        }
    }

    public void PrintInventory()
    {
        int count = 0;
        foreach (Resource resource in resources)
        {
            if (count < texts.Length) {
                texts[count].text = "x " + resource.amount;
            }
            count += 1;
        }
        if (GoalsManager.GoalManager.CheckPlayerGoals(GoalsManager.GoalManager.player1Goals) == 2) {
            winText.text = "PLAYER 1 WON!!";
            }
        if (GoalsManager.GoalManager.CheckPlayerGoals(GoalsManager.GoalManager.player2Goals) == 2) {
            winText.text = "PLAYER 2 WON!!";
        }
        
    }

    public bool hasResource(ResourceType t) {
        Resource existingResource = resources.Find(r => r.type == t);
        if (existingResource.amount > 0) {
            return true;
        }
        return false;
    }

    public void useResource(ResourceType t) {
        Resource existingResource = resources.Find(r => r.type == t);
        existingResource.amount -= 1;
    }

    public int numOfResource(ResourceType t) {
        Resource existingResource = resources.Find(r => r.type == t);
        return existingResource.amount;
    }
}
