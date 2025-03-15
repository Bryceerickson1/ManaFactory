using UnityEngine;

public class AppleCollec : MonoBehaviour
{
    [SerializeField]
    int AppleHeal = 0;
    [SerializeField]
    Stats PlayerStats;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Apple")
        {
            PlayerStats.TakeDamage(-AppleHeal);
            Destroy(other.gameObject);
        }
    }
}
