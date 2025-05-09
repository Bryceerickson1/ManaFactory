using UnityEngine;
using System.Collections;

public class VentScript : MonoBehaviour
{
    public float spawnInterval = 2f;
    [SerializeField] private GameObject objectToSpawn;

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            Instantiate(objectToSpawn, transform.position, transform.rotation);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}