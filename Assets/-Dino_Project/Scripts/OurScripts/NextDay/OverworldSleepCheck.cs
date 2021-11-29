using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldSleepCheck : MonoBehaviour
{
    private DataHolder dataHolder;
    public GameObject sleepButton;
    public GameObject stillActionText;
    public GameObject theDayText;
    public GameObject[] otherJunk;
    void Start()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        if(dataHolder.dayOfTheWeek == 7)
        {
            foreach(GameObject go in otherJunk)
            {
                go.SetActive(false);
            }
            theDayText.SetActive(true);
            stillActionText.SetActive(false);
            sleepButton.SetActive(false);
        }
        else
        {
            if(dataHolder.actions == 0)
            {
                foreach(GameObject go in otherJunk)
            {
                go.SetActive(false);
            }
                stillActionText.SetActive(false);
                sleepButton.SetActive(true);
            }
        }
    }
}
