using UnityEngine;
using System.Collections.Generic;

[System.Serializable] 
public class CraftingRequirement
{
    public ResourceType resourceType;
    public int amount;
}

[System.Serializable]
public class CraftingRecipe
{
    public string itemName;
    public List<CraftingRequirement> requirements;
    public GameObject prefabToSpawn; 
}