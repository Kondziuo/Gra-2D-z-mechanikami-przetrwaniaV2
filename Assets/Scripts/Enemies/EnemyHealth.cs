using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float maxHealth = 100f;
    [SerializeField] Slider healthSlider;
    [SerializeField] GameObject healthBarUI;
    public float currentHealth;





    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        healthBarUI.SetActive(false);
    }

    public void TakeDamage(float damage)
    {
        healthBarUI.SetActive(true);
        currentHealth -= damage;
        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }


}
