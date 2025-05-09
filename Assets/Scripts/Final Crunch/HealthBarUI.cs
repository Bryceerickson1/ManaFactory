using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public PlayerHealth playerHealth; // Drag reference to PlayerHealth script
    public RectTransform healthBarFill; // The RectTransform of the health fill bar

    public float maxHealth = 100f;

    void Update()
    {
        float healthRatio = Mathf.Clamp01(playerHealth.health / maxHealth);
        Vector3 newScale = healthBarFill.localScale;
        newScale.x = healthRatio;
        healthBarFill.localScale = newScale;
    }
}
