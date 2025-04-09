using UnityEngine;

public class MouseController : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined; // Keeps the cursor inside the game window
        Cursor.visible = true; // Always visible
    }

    void Update()
    {
        // Ensure the cursor remains confined and visible at all times
        if (Cursor.lockState != CursorLockMode.Confined)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }

        if (!Cursor.visible)
        {
            Cursor.visible = true;
        }
    }
}
