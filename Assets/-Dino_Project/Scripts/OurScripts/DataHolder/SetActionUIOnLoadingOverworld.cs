using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActionUIOnLoadingOverworld : MonoBehaviour
{
    private DataHolder dataHolder;
    public GameObject action4Spent;
    public GameObject action3Spent;
    public GameObject action2Spent;
    public GameObject action1Spent;
    void Start()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        switch(dataHolder.actions)
        {
            case 4:
                break;
            case 3:
                action4Spent.SetActive(true);
                break;
            case 2:
                action4Spent.SetActive(true);
                action3Spent.SetActive(true);
                break;
            case 1:
                action4Spent.SetActive(true);
                action3Spent.SetActive(true);
                action2Spent.SetActive(true);
                break;
            case 0:
                action4Spent.SetActive(true);
                action3Spent.SetActive(true);
                action2Spent.SetActive(true);
                action1Spent.SetActive(true);
                break;
        }
    }
}
