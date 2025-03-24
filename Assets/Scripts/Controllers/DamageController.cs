using UnityEngine;

public class DamageController : MonoBehaviour
{
    public int maxHealth = 100; // Max health of the object
    private int currentHealth; // Current health of the object
    public bool isAlive = true; // If the object is alive
    public float invincibilityTime = 0.5f; // Time to be invincible after taking damage (if you want a brief invincibility frame)
    private float lastDamageTime; // Timer to track invincibility

    // Events
    public delegate void OnDamageTaken(int damage);
    public event OnDamageTaken DamageTaken;

    public delegate void OnDeath();
    public event OnDeath Death;

    void Start()
    {
        currentHealth = maxHealth; // Initialize current health
    }

    void Update()
    {
        // Check if the object is still alive and invincibility time has passed
        if (Time.time - lastDamageTime > invincibilityTime && !isAlive)
        {
            isAlive = true;
        }
    }

    // Call this method to apply damage to the object
    public void TakeDamage(int damage)
    {
        if (!isAlive) return; // Ignore damage if already dead
        if (Time.time - lastDamageTime <= invincibilityTime) return; // Ignore damage during invincibility period

        currentHealth -= damage; // Subtract the damage from health

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die(); // Call the Die method if health is below 0
        }
        else
        {
            lastDamageTime = Time.time; // Track the time of the last damage
            isAlive = true; // Ensure the object is alive
        }

        // Trigger DamageTaken event if subscribed
        DamageTaken?.Invoke(damage);

        // Log health for debugging purposes
        Debug.Log($"{gameObject.name} took {damage} damage. Current health: {currentHealth}");
    }

    void Die()
    {
        isAlive = false;
        currentHealth = 0;

        // Trigger the death event if subscribed
        Death?.Invoke();

        // Add any additional death logic here (e.g., play death animation, destroy object, etc.)
        Debug.Log($"{gameObject.name} has died.");
        // For example, destroy the object after death:
        // Destroy(gameObject);
    }

    public void Heal(int amount)
    {
        if (!isAlive) return; // Can't heal if the object is dead

        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth; // Clamp health to max

        // Log healing for debugging purposes
        Debug.Log($"{gameObject.name} healed {amount}. Current health: {currentHealth}");
    }

    // Optional: If you want to check if the object is alive
    public bool IsAlive()
    {
        return isAlive;
    }
}
