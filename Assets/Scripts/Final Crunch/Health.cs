using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{

    public int health;
    public int maxHealth = 100;

    private string gameoverScreen = "game over";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public int GetHealth()
    {
        return health;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0) { Destroy(gameObject); }

        if (health <= 0) { SceneManager.LoadScene(gameoverScreen);}
    }
}
