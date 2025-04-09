using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public float speed = 5f;  // Speed at which the object follows the player

    private void Update()
    {
        // Ensure the player is assigned
        if (player != null)
        {
            // Move the object towards the player's position
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            Debug.LogWarning("Player not assigned in FollowPlayer script!");
        }
    }
}