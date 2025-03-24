using UnityEngine;

public class PersistentObject : MonoBehaviour
{
    private void Awake()
    {
        // Check if a duplicate exists and destroy it to avoid multiple instances
        if (FindObjectsOfType<PersistentObject>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
