using UnityEngine;

public class SelfDestructOnTouch : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            // Destroy this object
            Destroy(gameObject);
        }
    }
}
