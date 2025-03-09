using UnityEngine;

public class SpinObject : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float speed = 100f; // Rotation speed (degrees per second)
    public Vector3 direction = Vector3.up; // Axis of rotation

    [Header("Rotation Mode")]
    public Transform orientationPoint; // If set, rotates around this point

    void Update()
    {
        if (orientationPoint != null)
        {
            // Rotate around an external point
            transform.RotateAround(orientationPoint.position, direction.normalized, speed * Time.deltaTime);
        }
        else
        {
            // Rotate around itself
            transform.Rotate(direction.normalized * speed * Time.deltaTime);
        }
    }
}
