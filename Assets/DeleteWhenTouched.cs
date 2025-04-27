using UnityEngine;

public class DeleteWhenTouched : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Delete"))
        {
            Destroy(gameObject);
        }
    }

}
