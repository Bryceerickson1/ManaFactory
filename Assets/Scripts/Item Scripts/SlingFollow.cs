using UnityEngine;

public class SlingFollow : MonoBehaviour
{
    [SerializeField] private GameObject chased;  // Player as a GameObject
    [SerializeField] private float sSpeed = 5f;   // Speed of following
    [SerializeField] private float inertia = 0.1f; // Inertia for smooth motion
    [SerializeField] private float offsetX = 0f; // X offset
    [SerializeField] private float offsetY = 0f; // Y offset
    [SerializeField] private float offsetZ = 0f; // Z offset

    private Vector3 velocity = Vector3.zero; // SmoothDamp velocity reference

    private void Update()
    {
        if (chased != null)
        {
            // Get the player's transform
            Transform playerTransform = chased.transform;

            // Define target position with offset
            Vector3 targetPosition = playerTransform.position + new Vector3(offsetX, offsetY, offsetZ);

            // Smooth movement with inertia overshoot
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, inertia, sSpeed);
        }
        else
        {
            Debug.LogWarning("Player GameObject is not assigned in FollowPlayer script!");
        }
    }
}
