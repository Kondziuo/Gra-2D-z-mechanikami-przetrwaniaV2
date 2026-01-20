using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Tree : MonoBehaviour
{
    [SerializeField] int hp = 3;
    [SerializeField] ResourceType resourceType = ResourceType.Wood;
    [SerializeField] ResourceType resourceType2 = ResourceType.Stick;
    [SerializeField] int baseAmount = 10;


    public void Hit(Inventory inventory)
    {
        int randomExtra = Random.Range(0, 6);
        int amount = baseAmount + randomExtra;
        int randomExtra2 = Random.Range(0, 3);
        if (randomExtra2 > 0) { 
        inventory.Add(resourceType2, randomExtra2);
    }
        hp--;
        Debug.Log("Drzewo uderzone! HP: " + hp);


        if (hp <= 0)
        {
            inventory.Add(resourceType, amount);
        Destroy(gameObject);
        }
    }
}
