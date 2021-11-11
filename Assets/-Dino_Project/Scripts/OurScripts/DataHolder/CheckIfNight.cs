using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfNight : MonoBehaviour
{
    private DataHolder dataHolder;
    public GameObject night;
    void Start()
    {
        dataHolder = gameObject.GetComponent<DataHolder>();
        if(dataHolder.actions <= 2)
        {
            night.SetActive(false);
        }
    }
}
