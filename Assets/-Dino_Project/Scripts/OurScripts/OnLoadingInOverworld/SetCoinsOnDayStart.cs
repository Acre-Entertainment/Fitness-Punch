using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCoinsOnDayStart : MonoBehaviour
{
    private DataHolder dataHolder;
    public GameObject[] coins;
    public int oddsThatCoinSpawnOutOf100;
    private int currentCoin = 0;
    void Start()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        if(dataHolder.actions == 4)
        {
            foreach(GameObject go in coins)
            {
                int randy = Random.Range(1, 101);
                if(oddsThatCoinSpawnOutOf100 >= randy)
                {
                    go.SetActive(true);
                    dataHolder.coinActivation[currentCoin] = true;
                }
                else
                {
                    dataHolder.coinActivation[currentCoin] = false;
                }
                currentCoin++;
            }
        }
        else
        {
            foreach(GameObject go in coins)
            {
                if(dataHolder.coinActivation[currentCoin] == true)
                {
                    go.SetActive(true);
                }
                currentCoin++;
            }
        }
    } 
}
