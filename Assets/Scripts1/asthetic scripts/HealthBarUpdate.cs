using UnityEngine;
using UnityEngine.UI;

public class HealthBarUpdate : MonoBehaviour
{
    [SerializeField] Slider _healthbar;

    public void SetMax(int _max)
    {
        _healthbar.maxValue = _max;
    }

    public void DecreaseHealth(int _damaged)
    {
        _healthbar.value -= _damaged;
    }
}
