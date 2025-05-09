using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{

    public int health = 100;

    private string gameoverScreen = "Game Over";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (health < 0) { SceneManager.LoadScene(gameoverScreen); }
    }
}
