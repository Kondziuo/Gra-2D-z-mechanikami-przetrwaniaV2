using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float maxHealth = 100;
    [SerializeField] GameObject DeathPanel;
    public float currentHealth;
    
    public Slider healthSlider;
    

    void Start()
    {
        currentHealth = maxHealth;

        if(healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = maxHealth;
        }
    }

    public void Regen(float healthRegen) {
        currentHealth += healthRegen;

        if (currentHealth > maxHealth) 
        {
            currentHealth = maxHealth;

        }
        healthSlider.value = currentHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
        {
            DeathPanel.SetActive(true);
            gameObject.SetActive(false);
        }
    





}
