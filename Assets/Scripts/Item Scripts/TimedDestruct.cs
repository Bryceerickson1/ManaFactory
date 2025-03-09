using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField]
    private float timer = 5f; // Time in seconds before self-destruct

    private void Start()
    {
        // Start the countdown for self-destruction
        Invoke("DestroyObject", timer);
    }

    private void DestroyObject()
    {
        // Destroy the game object
        Destroy(gameObject);
    }
}

