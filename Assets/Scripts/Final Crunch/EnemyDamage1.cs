using UnityEngine;

public class EnemyDamage1 : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private float delay = 1f; // Seconds between damage ticks

    private float lastDamageTime = -Mathf.Infinity;

    private void OnCollisionEnter(Collision collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();

        if (health != null && Time.time >= lastDamageTime + delay)
        {
            health.TakeDamage(damage);
            lastDamageTime = Time.time;
        }
    }
}