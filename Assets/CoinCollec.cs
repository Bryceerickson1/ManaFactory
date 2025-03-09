using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCollec : MonoBehaviour
{

    //collect coin UI
    private int Coin = 0;

    public TextMeshProUGUI coinText;

    //create ping Effect
    [SerializeField]
    private GameObject objectToSpawn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Coin")
        {
            Coin++;
            coinText.text = "Gold: " + Coin.ToString();
            Debug.Log("Coin");

            Instantiate(objectToSpawn, other.transform.position, transform.rotation);

            Destroy(other.gameObject);

        }
    }

}
