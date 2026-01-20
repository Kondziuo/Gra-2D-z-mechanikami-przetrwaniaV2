using UnityEngine;
using UnityEngine.InputSystem;

public class Campfire : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] ResourceType resourceType;
    [SerializeField] GameObject[] meatSlots;

    PlayerHunger hunger;
    float[] cookingTimers = new float[4];
    bool canInteract;
    private void Start()
    {
       if (inventory == null)
        {
    inventory = FindFirstObjectByType<Inventory>();
        }
    }
    void TryPlaceMeat()
    {
        if (inventory.HasEnough(ResourceType.Meat, 1))
        {
            for (int i = 0; i < meatSlots.Length; i++)
            {
                if (meatSlots[i].activeSelf == false)
                {
                    cookingTimers[i] = 0;
                    meatSlots[i].SetActive(true);
                    inventory.Remove(ResourceType.Meat, 1);
                    Debug.Log("Po³o¿y³eœ mieso");
                    return;
                }
                Debug.Log("wszystko zajete");
            }
        }
        else Debug.Log("bratku nie masz miesa");
    }

    void TryEat()
    {
       
        for (int i = 0; i < meatSlots.Length; i++)
        {
            if (meatSlots[i].activeSelf == true)
            {

                if (cookingTimers[i] >= 10f && cookingTimers[i] < 40f)
                {
                    hunger.AddHunger(20);
                    meatSlots[i].SetActive(false);
                    cookingTimers[i] = 0;
                }
                else if (cookingTimers[i] >= 40f)
                {
                    hunger.AddHunger(5);
                    meatSlots[i].SetActive(false);
                    cookingTimers[i] = 0;
                }

                return;
            }

        }
    }


    void Update()
    {
        if (canInteract == true && Keyboard.current.eKey.wasPressedThisFrame) 
        {
            TryPlaceMeat();
        }

        if (canInteract == true && Keyboard.current.fKey.wasPressedThisFrame)
        {
            TryEat();
        }


        for (int i = 0; i < meatSlots.Length; i++)
        {
            if (meatSlots[i].activeSelf)
            {
                cookingTimers[i] += Time.deltaTime;
                UpdateMeatVisual(i);
            }
        }
    }


    void UpdateMeatVisual(int index)
    {
        SpriteRenderer sr = meatSlots[index].GetComponent<SpriteRenderer>();

        if (cookingTimers[index] >= 40f)
        {
            sr.color = Color.black;
        }
        else if (cookingTimers[index] >= 10f)
        {
            sr.color = new Color(0.6f, 0.4f, 0.2f);
        }
        else
        {
            sr.color = Color.white;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canInteract = true;
        hunger = collision.GetComponent<PlayerHunger>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canInteract = false;
        hunger = null;
    }



}
