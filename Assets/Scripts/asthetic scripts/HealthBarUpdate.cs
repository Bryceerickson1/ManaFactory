using UnityEngine;
using UnityEngine.UI;

public class HealthBarUpdate : MonoBehaviour
{
    [SerializeField] Slider _healthbar;

    public void SetMax(float _max)
    {
        _healthbar.maxValue = _max;
        _healthbar.value = _max;
    }

    public void DecreaseHealth(float _damaged)
    {
        _healthbar.value -= _damaged;
    }
}
