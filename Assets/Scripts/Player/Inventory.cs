using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    private Dictionary<ResourceType, int> resources = new Dictionary<ResourceType, int>();
    [SerializeField] PickupUI pickupUI;

    void Awake()
    {
        foreach (ResourceType type in System.Enum.GetValues(typeof(ResourceType)))
        {
            resources[type] = 0;
        }
    }

    public void Add(ResourceType type, int amount)
    {
        resources[type] += amount;
        Debug.Log(type + ": +" + amount + " (" + resources[type] + ")");

        int total = resources[type];
        pickupUI.ShowPickup(type, amount, total);

    }

    public int Get(ResourceType type)
    {
        return resources[type];
    }

    public bool HasEnough(ResourceType type, int amount)
    {
        return resources[type] >= amount;
    }

    public void Remove(ResourceType type, int amount)
    {
        resources[type] -= amount;

        int total = resources[type];

        pickupUI.ShowPickup(type, -amount, total);
    }

}
