using UnityEngine;
using TMPro;
public class PickupUI : MonoBehaviour
{
    [SerializeField] GameObject pickupText;
    
    public void ShowPickup(ResourceType type, int amount, int total)
    {
       
        GameObject newPickupText = Instantiate(pickupText, transform);

        newPickupText.GetComponent<PickupText>().Setup(type, amount, total);
    }

}
