using UnityEngine;

public class DestroyPersistent : MonoBehaviour
{
    [Header("Object to Destroy")]
    [SerializeField] private string objectTag;  // Tag of the object to destroy

    private void Start()
    {
        // Find all objects with the specified tag
        GameObject[] persistentObjects = GameObject.FindGameObjectsWithTag(objectTag);

        // Destroy each object found
        foreach (GameObject obj in persistentObjects)
        {
            Destroy(obj);
        }
    }
}
