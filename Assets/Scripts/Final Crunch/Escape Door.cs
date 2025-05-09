using UnityEngine;
using System.Collections;


public class EscapePeriodController : MonoBehaviour
{
    [Header("Time Range in Seconds")]
    [SerializeField] private int minTime = 3;
    [SerializeField] private int maxTime = 7;

    [Header("Objects to Hide")]
    [SerializeField] private GameObject object1;
    [SerializeField] private GameObject object2;

    [Header("Objects to Show")]
    [SerializeField] private GameObject object3;
    [SerializeField] private GameObject object4;

    [Header("Escape Period Settings")]
    [SerializeField] private float escapeDuration = 5f;
    public bool escapePeriod { get; private set; } = false;

    private void Start()
    {
        object3.SetActive(false);
        object4.SetActive(false);

        StartCoroutine(TriggerEscapePeriodRoutine());
    }

    private IEnumerator TriggerEscapePeriodRoutine()
    {
        while (true)
        {

            int waitTime = Random.Range(minTime, maxTime + 1);
            yield return new WaitForSeconds(waitTime);

            // Enter escape period
            escapePeriod = true;
            object1.SetActive(false);
            object2.SetActive(false);
            object3.SetActive(true);
            object4.SetActive(true);

            yield return new WaitForSeconds(escapeDuration);

            // Exit escape period
            escapePeriod = false;
            object1.SetActive(true);
            object2.SetActive(true);
            object3.SetActive(false);
            object4.SetActive(false);
        }
    }
}
