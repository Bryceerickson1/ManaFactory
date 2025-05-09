using UnityEngine;

public class EnemyProximityDamage : MonoBehaviour
{
    [SerializeField] private float damageRange = 200f;
    [SerializeField] private float damageAmount = 20f;
    [SerializeField] private float damageInterval = .1f;

    private GameObject player;
    private PlayerHealth playerHealth;
    private float lastDamageTime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (playerHealth == null) return;

        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= damageRange && Time.time - lastDamageTime >= damageInterval)
        {
            playerHealth.TakeDamage(damageAmount);
            lastDamageTime = Time.time;
        }
    }
}
