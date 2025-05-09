using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public HealthBarUpdate slider;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        slider.SetMax(maxHealth);
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        slider.DecreaseHealth(amount);
        if (currentHealth <= 0f)
        {
            Debug.Log("Player Died!");
            SceneManager.LoadScene("Game Over");
            Destroy(gameObject);
        }
    }
}
