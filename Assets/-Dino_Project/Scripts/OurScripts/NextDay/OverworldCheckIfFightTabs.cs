using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldCheckIfFightTabs : MonoBehaviour
{
    private DataHolder dataHolder;
    public GameObject[] junkToBeDeactivatedOnSeventhDay;
    public GameObject TheText;
    void Start()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        if(dataHolder.dayOfTheWeek == 7)
        {
            foreach(GameObject go in junkToBeDeactivatedOnSeventhDay)
            {
                go.SetActive(false);
            }
            TheText.SetActive(true);
        }
    }
}
