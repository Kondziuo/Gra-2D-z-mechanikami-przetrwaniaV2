using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Meat : MonoBehaviour
{
    [SerializeField] int hp = 5;
    [SerializeField] ResourceType resourceType = ResourceType.Meat;
    [SerializeField] int baseAmount = 10;


    public void Hit(Inventory inventory)
    {
        int randomExtra = Random.Range(0, 6);
        int amount = baseAmount + randomExtra;

        hp--;
        Debug.Log("Kebab uderzony! HP: " + hp);


        if (hp <= 0)
        {
            inventory.Add(resourceType, amount);
            Destroy(gameObject);
        }
    }
}
