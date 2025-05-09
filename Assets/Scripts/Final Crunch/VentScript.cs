using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private float spawnInterval = 2f;

    private float nextSpawnTime;

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            Instantiate(objectToSpawn, transform.position, transform.rotation);
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
}
