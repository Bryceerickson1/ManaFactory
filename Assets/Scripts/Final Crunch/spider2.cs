using UnityEngine;

public class SpiderAI : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            Debug.LogWarning("SpiderAI could not find Player by tag!");
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Example behavior: move toward player
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 2f * Time.deltaTime);
        }
    }
}