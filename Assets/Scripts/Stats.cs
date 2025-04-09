using UnityEngine;
using UnityEngine.Events;

public class Stats : MonoBehaviour
{

    [SerializeField] int _health;
    [SerializeField] UnityEvent<int> OnDamaged;
    [SerializeField] UnityEvent<int> OnCreate;
    public int Health => _health;

    void Start()
    {
        OnCreate?.Invoke(_health);
    }

    public void TakeDamage(int damaged)
    {
        _health -= damaged;
        OnDamaged?.Invoke(damaged);
    }
}
