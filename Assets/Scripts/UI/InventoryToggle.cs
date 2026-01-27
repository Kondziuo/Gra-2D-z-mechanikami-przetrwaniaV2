using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryToggle : MonoBehaviour
{
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] CraftingButtonUI inventoryButton;
    [SerializeField] CraftingManager inventoryManager;
    void Start()
    {
        inventoryPanel.SetActive(false);
    }

    void Update()
    {
        if (Keyboard.current.iKey.wasPressedThisFrame)
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
           
        }
        if (inventoryPanel.activeSelf)
        {
            bool canCraft = inventoryManager.AvailableCraft(inventoryButton.craftingIndex);
            inventoryButton.ColorSwitch(canCraft);
        }



    }



}



