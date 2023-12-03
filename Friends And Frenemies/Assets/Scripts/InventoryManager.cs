using UnityEngine;
using System.Collections.Generic;


public class InventoryManager : MonoBehaviour
{
    public static InventoryManager inventoryManager;

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
        Water,
        Food,
        RawFood,
        ToxicMushroom,
        RedFlower,
        MovingThorneBush,
    }

    [System.Serializable]
    public class Resource
    {
        public ResourceType type;
        public int amount;
    }

    public List<Resource> resources = new List<Resource>();

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
        foreach (Resource resource in resources)
        {
            Debug.Log(resource.type + ": " + resource.amount);
        }
    }

    void Start()
    {
    }
}
