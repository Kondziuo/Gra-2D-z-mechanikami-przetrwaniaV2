using UnityEngine;
using UnityEngine.UI;
public class PlayerHunger : MonoBehaviour
{

    [SerializeField] float maxHunger = 100;
    
    public Slider hungerSlider;
    public float currentHunger;
    PlayerHealth health;
    float hungerDecrease = 0.4f;
    float regenTimer;




    void Start()
    {
        currentHunger = 80;
        hungerSlider.maxValue = maxHunger;
        hungerSlider.value = currentHunger;
        health = GetComponent<PlayerHealth>();

    }

    void Update()
    {
        float randomVariation = Random.Range(-0.2f, 0.3f);
        currentHunger -= (hungerDecrease + randomVariation) * Time.deltaTime;
        hungerSlider.value = currentHunger;
        regenTimer += Time.deltaTime;
        if (currentHunger > 50 && currentHunger < 80)
        {
            
            if(regenTimer >= 1.0f)
            {
                health.Regen(1);
                regenTimer = 0.0f;
            }
        }
        if (currentHunger >= 80)
        {
            if (regenTimer >= 1.0f)
            {
                health.Regen(2);
                regenTimer = 0.0f;
            }
        }
    }

    public void AddHunger(int amount)
    {
       currentHunger += amount;

        if(currentHunger > maxHunger)
        {
            currentHunger = maxHunger;
        }

    }



}
