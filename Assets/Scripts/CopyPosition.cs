using UnityEngine;

public class CopyPosition : MonoBehaviour
{
    [SerializeField] private Transform targetObject; // Assign this in the Inspector

    private void Update()
    {
        if (targetObject != null)
        {
            transform.position = targetObject.position;
        }
    }
}
