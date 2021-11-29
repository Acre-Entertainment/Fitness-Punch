using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    private DataHolder dataHolder;
    private int coinMarker;
    public Text[] coinText;
    void Start()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        setCoinNumberText();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Coin")
        {
            coinMarker = other.gameObject.GetComponent<CoinMark>().coinNumber;
            dataHolder.coinActivation[coinMarker] = false;
            Destroy(other.gameObject);
            dataHolder.coins++;
            setCoinNumberText();
        }
    }
    private void setCoinNumberText()
    {
        foreach(Text text in coinText)
        {
            text.text = "" + dataHolder.coins;
        }
    }
}
