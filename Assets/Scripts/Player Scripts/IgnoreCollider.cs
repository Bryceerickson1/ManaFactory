using UnityEngine;

public class IgnoreSpecificCollision : MonoBehaviour
{
    [Header("Fist Collider")]
    public GameObject fistObject; // The fist object (any GameObject) that will interact with other objects

    [Header("GameObject to Ignore")]
    public GameObject objectToIgnore; // GameObject to ignore during collisions (assigned in Inspector)

    private Collider fistCollider; // The fist's collider component
    private Collider objectToIgnoreCollider; // The collider of the object to ignore

    void Start()
    {
        // Ensure fistObject is assigned
        if (fistObject != null)
        {
            // Get the fist's collider from the GameObject (assumes it has a Collider attached)
            fistCollider = fistObject.GetComponent<Collider>();

            if (fistCollider == null)
            {
                Debug.LogWarning("The fist object does not have a Collider.");
            }
        }
        else
        {
            Debug.LogWarning("Fist object is not assigned.");
        }

        // Ensure objectToIgnore is assigned and not null
        if (objectToIgnore != null)
        {
            // Get the collider of the objectToIgnore GameObject
            objectToIgnoreCollider = objectToIgnore.GetComponent<Collider>();

            if (objectToIgnoreCollider != null)
            {
                // Ignore collision between the fist and the colliderToIgnore
                Physics.IgnoreCollision(fistCollider, objectToIgnoreCollider);
            }
            else
            {
                Debug.LogWarning("The assigned object to ignore does not have a Collider.");
            }
        }
        else
        {
            Debug.LogWarning("No object assigned to ignore in the inspector.");
        }
    }

    // Optionally, re-enable the collision if needed
    public void ReenableCollision()
    {
        if (fistCollider != null && objectToIgnoreCollider != null)
        {
            Physics.IgnoreCollision(fistCollider, objectToIgnoreCollider, false);
        }
    }

    // Update the object to ignore dynamically during gameplay
    public void UpdateObjectToIgnore(GameObject newObjectToIgnore)
    {
        // Disable collision with the old object
        if (objectToIgnoreCollider != null)
        {
            Physics.IgnoreCollision(fistCollider, objectToIgnoreCollider, false);
        }

        // Update the object to ignore
        objectToIgnore = newObjectToIgnore;
        objectToIgnoreCollider = objectToIgnore.GetComponent<Collider>();

        if (objectToIgnoreCollider != null)
        {
            // Start ignoring collision with the new object
            Physics.IgnoreCollision(fistCollider, objectToIgnoreCollider);
        }
        else
        {
            Debug.LogWarning("The new object to ignore does not have a Collider!");
        }
    }
}
