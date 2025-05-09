using System;
using UnityEngine;
using UnityEngine.UI;

public class StaminaManager : MonoBehaviour
{
    [Header("Stamina Settings")]
    [SerializeField] private float maxStamina = 100f;
    [SerializeField] private float staminaDrain = 20f;
    [SerializeField] private float staminaRegenRate = 10f;
    [SerializeField] private float regenDelay = 1f;

    public Boolean hasStamina;
    [SerializeField] private float drainCooldown = 0.2f; // seconds between stamina drains
    private float lastDrainTime = 0f;



    [Header("UI")]
    [SerializeField] private Image staminaBar;

    private float currentStamina;
    public bool playerCanUseStamina = true;
    private float regenTimer;

    void Start()
    {
        currentStamina = maxStamina;
        UpdateStaminaUI();
    }

    void Update()
    {
        if (playerCanUseStamina && Input.GetKey(KeyCode.LeftShift))
        {
            UseStamina();
        }

        // Regenerate if not using space
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            regenTimer += Time.deltaTime;
            if (regenTimer >= regenDelay)
            {
                RegenerateStamina();
            }
        }
        else
        {
            regenTimer = 0f; // reset timer when using stamina
        }
    }

    void UseStamina()
    {
        if (Time.time - lastDrainTime >= drainCooldown && playerCanUseStamina)
        {
            currentStamina -= staminaDrain;
            lastDrainTime = Time.time;

            if (currentStamina <= 0f)
            {
                currentStamina = 0f;
                playerCanUseStamina = false;
                hasStamina = false;
            }

            UpdateStaminaUI();
        }
    }



    void RegenerateStamina()
    {
        if (currentStamina < maxStamina)
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
            if (currentStamina >= maxStamina * 0.25f) // regain control after reaching 25%
            {
                playerCanUseStamina = true;
            }

            if (currentStamina > maxStamina)
                currentStamina = maxStamina;

            UpdateStaminaUI();
        }
    }

    void UpdateStaminaUI()
    {
        if (staminaBar != null)
        {
            staminaBar.fillAmount = currentStamina / maxStamina;
        }
    }
}
