using UnityEngine;

public class Spider : MonoBehaviour
{

    [SerializeField] private int damage = 10;
    [SerializeField] private int damageDelay = 50;
    private int delay = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {




        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                //if (delay <0) { -= damage; }
                // Do something when colliding with an object tagged "Player"
            }
        }


    }

}
