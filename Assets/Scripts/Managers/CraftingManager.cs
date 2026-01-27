using System;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    public List<CraftingRecipe> recipes;
    [SerializeField] Inventory inventory;
    [SerializeField] Transform spawnPoint;


    public void Craft(int recipeIndex)
    {

        CraftingRecipe currentRecipe = recipes[recipeIndex];

        foreach (CraftingRequirement req in currentRecipe.requirements)
        {
            if (!inventory.HasEnough(req.resourceType, req.amount))
            {
                Debug.Log("Brakuje surowca");
                return;
            }
        }

        foreach (CraftingRequirement req in currentRecipe.requirements)
        {
            inventory.Remove(req.resourceType, req.amount);
        }

        if (currentRecipe.prefabToSpawn != null)
        {
            Instantiate(currentRecipe.prefabToSpawn, spawnPoint.position, Quaternion.identity);
            Debug.Log("Zbudowano: " + currentRecipe.itemName);
        }




    }

    public bool AvailableCraft(int index) {
        CraftingRecipe currentRecipe = recipes[index];

        foreach (CraftingRequirement req in currentRecipe.requirements)
        {
            if (!inventory.HasEnough(req.resourceType, req.amount))
            {
                return false;
            }
        }
        return true;
    } 

}
