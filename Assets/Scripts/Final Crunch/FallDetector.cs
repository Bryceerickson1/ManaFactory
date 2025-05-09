using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDetector : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < -200f)
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
