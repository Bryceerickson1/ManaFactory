using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ConverorBeltManager : MonoBehaviour
{
    [SerializeField] GameObject BeltPrefab;
    [Tooltip("Offset for the items that spawn")]
    [SerializeField] Vector3 ItemsOffset;
    [Tooltip("What the belt touches to be deleted")]
    [SerializeField] BoxCollider DeletionObject;
    [SerializeField] ConverorBeltItems[] SpawnableItems;
    [Tooltip("Sort this from the rarest to the highest")]
    Queue<GameObject> CreatedBelts = new Queue<GameObject>();
    [Header("Time Management")]
    [Tooltip("Changing Belt Speed also changes spawn speed")]
    [SerializeField] float BeltSpeed;

    void Start()
    {
        StartCoroutine(SpawnObject());
        StartCoroutine(MoveObjects());
    }

    IEnumerator SpawnObject()
    {
        //setup
        GameObject CurrentBelt = Instantiate(BeltPrefab, transform.position, Quaternion.identity);
        CreatedBelts.Enqueue(CurrentBelt);

        int randomNumber = Random.Range(1, 1001);
        for (int I = 0; I < SpawnableItems.Length; I++)
        {
            if(SpawnableItems[I].TopRange >= randomNumber)
            {
                if(SpawnableItems[I].Item == null) break;
                Debug.Log(ItemsOffset);
                GameObject createdItem = Instantiate(SpawnableItems[I].Item, ItemsOffset + transform.position, Quaternion.identity);
                break;
            }
        }

        yield return new WaitForSeconds(1/(BeltSpeed * 1.4f));
        StartCoroutine(SpawnObject());
    }

    IEnumerator MoveObjects()
    {
        while (true)
        {
            foreach (var belt in CreatedBelts)
            {
                if (belt != null)
                {
                    belt.transform.position += Vector3.left * BeltSpeed * Time.deltaTime;
                }
            }
            yield return null;
        }
    }
}

[System.Serializable]
public struct ConverorBeltItems
{
    /*
    the bottom range is used for probability
    for example, it would work by generating a random number from 
    1-100 then it would pick a random number like 5, the first number
    that falls below that range would be the selected item
    */
    public int TopRange;
    public string test;
    public GameObject Item;
}