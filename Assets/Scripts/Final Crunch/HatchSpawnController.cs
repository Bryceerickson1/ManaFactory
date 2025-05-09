using UnityEngine;
using System.Collections;

public class RandomActivator : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToActivate = new GameObject[6];
    [SerializeField] private int spawnChance = 1;           // Activation happens if RNG <= this
    [SerializeField] private int startRange = 1000;          // Initial upper range
    [SerializeField] private int minRange = 10;              // Final upper range
    [SerializeField] private float rampTime = 60f;           // Time in seconds until max speed

    private float elapsedTime = 0f;

    void Start()
    {
        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(false);
        }
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        // Linearly reduce the random range
        int currentRange = Mathf.RoundToInt(Mathf.Lerp(startRange, minRange, elapsedTime / rampTime));

        int roll = Random.Range(0, currentRange);
        if (roll <= spawnChance)
        {
            ActivateRandomObject();
        }
    }

    void ActivateRandomObject()
    {
        int index = Random.Range(0, objectsToActivate.Length);
        GameObject selected = objectsToActivate[index];

        if (!selected.activeSelf)
        {
            selected.SetActive(true);
            StartCoroutine(DeactivateAfterDelay(selected, 3f));
        }
    }

    IEnumerator DeactivateAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(false);
    }
}
