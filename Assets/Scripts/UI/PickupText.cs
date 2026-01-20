using UnityEngine;
using TMPro;
public class PickupText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMesh;

    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    public void Setup(ResourceType type, int amount, int total)
    {
        textMesh.text = "+" + amount + " " + type + " (" + total + ")";


    }
}