using UnityEngine;

public class BombCollec : MonoBehaviour
{
    [SerializeField]
    int BombDamage = 0;
    [SerializeField]
    Stats PlayerStats;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Bomb")
        {
            PlayerStats.TakeDamage(BombDamage);
            Destroy(other.gameObject);
        }
    }
}
