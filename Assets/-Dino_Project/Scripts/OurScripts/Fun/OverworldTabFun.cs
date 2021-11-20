using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldTabFun : MonoBehaviour
{
    private DataHolder dataHolder;
    public GameObject goButton;
    public GameObject noText;
    void Start()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
    }
    public void checkActions()
    {
        if(dataHolder.actions == 0)
        {
            noText.SetActive(true);
            goButton.SetActive(false);
        }
        else
        {
            noText.SetActive(false);
            goButton.SetActive(true);
        }
    }
}
