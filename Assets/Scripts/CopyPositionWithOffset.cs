using UnityEngine;

public class CopyPositionWithOffset : MonoBehaviour
{
    public Transform target; // The object to copy position from

    [SerializeField] private float offsetX; // Offset to apply on X-axis
    [SerializeField] private float offsetY; // Offset to apply on Y-axis
    [SerializeField] private float offsetZ; // Offset to apply on Z-axis

    void Update()
    {
        if (target != null)
        {
            transform.position = new Vector3(
                target.position.x + offsetX,
                target.position.y + offsetY,
                target.position.z + offsetZ
            );
        }
    }
}
