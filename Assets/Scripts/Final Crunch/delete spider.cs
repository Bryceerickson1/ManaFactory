using UnityEngine;

public class deletespider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
           
            Destroy(other.gameObject);

        }
    }
}
