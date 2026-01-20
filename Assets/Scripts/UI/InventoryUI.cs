using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InventoryUI : MonoBehaviour
{
    [System.Serializable] public struct ResourceUI
    {
        public ResourceType type;
        public Image iconImage;
        public TMP_Text text;
    }
    
    [SerializeField] Inventory inventory;
    [SerializeField] ItemData itemData;
    [SerializeField] ResourceUI[] resourceUI;

    void Start()
    {
        foreach (var element in resourceUI)
        {
            if (element.iconImage != null)
            {
                element.iconImage.sprite = itemData.GetSprite(element.type);
            }
        }
    }


    void Update()
    {
            foreach(var element in resourceUI)
            {
                if(element.text != null)
                {

                    int amount = inventory.Get(element.type);
                    element.text.text = amount.ToString();
                }
            }
    }
}
