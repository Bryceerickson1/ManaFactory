using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{

    [SerializeField] int _health;
    [SerializeField] UnityEvent<int> OnDamaged;
    public int Health => _health;

    void Start()
    {
        TakeDamage(20);
    }

    public void TakeDamage(int damaged)
    {
        _health -= damaged;
        OnDamaged?.Invoke(damaged);
    }
}
