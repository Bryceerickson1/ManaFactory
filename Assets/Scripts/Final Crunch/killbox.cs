using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverOnTouch : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
