using UnityEngine;

public class SpawnMoveDestroy : MonoBehaviour
{
    public GameObject objectPrefab; // Prefab to spawn
    public GameObject objectPrefab2; // Prefab to spawn

    [SerializeField] private Transform spawnPoint; // Spawn location
    [SerializeField] private Vector3 moveDirection = Vector3.forward; // Movement direction
    [SerializeField] private float moveSpeed = 5f; // Speed of movement
    [SerializeField] private float lifetime = 3f; // Time before deletion
    [SerializeField] private float spawnDelay = 3f; // Time before deletion

    [SerializeField] private GameObject[] objects;

    private float delay = 0;

    void Start()
    {
        SpawnObject(true);
    }

    void Update()
    {
        delay += Time.deltaTime;

        if (delay > spawnDelay)
        {

            delay = 0;
            SpawnObject(Random.Range(1, 101) < 80);
        }
    }

    void SpawnObject(bool spawn)
    {
        if (spawnPoint == null) return;

        GameObject spawnedObject = null;  // Declare outside the if/else block

        if (spawn)
        {
            spawnedObject = Instantiate(objectPrefab, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            spawnedObject = Instantiate(objectPrefab2, spawnPoint.position, Quaternion.identity); // spawn 2
        }

        if (spawnedObject != null)
        {
            StartCoroutine(MoveAndDestroy(spawnedObject)); // Start the movement and destruction coroutine
        }
    }

    System.Collections.IEnumerator MoveAndDestroy(GameObject obj)
    {
        float elapsedTime = 0f;
        while (elapsedTime < lifetime)
        {
            obj.transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Destroy(obj);
    }
}
