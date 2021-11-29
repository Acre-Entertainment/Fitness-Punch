using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private DataHolder dataHolder;
    private int coinMarker;
    void Start()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Coin")
        {
            coinMarker = other.gameObject.GetComponent<CoinMark>().coinNumber;
            dataHolder.coinActivation[coinMarker] = false;
            other.gameObject.SetActive(false);
            dataHolder.coins++;
        }
    }
}
