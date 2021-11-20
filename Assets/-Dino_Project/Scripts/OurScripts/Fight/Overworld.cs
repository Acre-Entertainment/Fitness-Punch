using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overworld : MonoBehaviour
{
    private DataHolder dataHolder;
    public GameObject noDayText;
    public GameObject goButton;
    void Start()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        if(dataHolder.dayOfTheWeek == 7)
        {
            noDayText.SetActive(false);
            goButton.SetActive(true);
        }
        else
        {
            noDayText.SetActive(true);
            goButton.SetActive(false);
        }
    }
}
