using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damageRadius = 2f;
    public float damageRange = 5f;
    public float damageAmount = 10f;
    public float damageInterval = 1f;

    private float lastDamageTime;
    void Start()
    {
        lastDamageTime = Time.time;
    }

    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, damageRange);
    
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Player"))
            {
                PlayerHealth playerHealth = hitCollider.GetComponentInParent<PlayerHealth>();
                if (playerHealth != null && Time.time - lastDamageTime >= damageInterval)
                {
                    playerHealth.TakeDamage(damageAmount);
                    lastDamageTime = Time.time;

                    Destroy(gameObject);
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, damageRadius);
    }
}