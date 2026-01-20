using System.Globalization;
using UnityEngine;

[System.Serializable] public struct ItemGraphic
{
    public ResourceType resourceType;
    public Sprite icon;
}

public class ItemData : MonoBehaviour
{
    public ItemGraphic[] item;

    public Sprite GetSprite(ResourceType type)
    {
        foreach (var item in item)
        {
            if (item.resourceType == type) return item.icon;
        }
        return null;
    }

 

}