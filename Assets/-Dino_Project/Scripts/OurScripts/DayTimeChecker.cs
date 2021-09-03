using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTimeChecker : MonoBehaviour
{
    //verifica se esta de dia ou de noite. Ativa o respectivo objeto.
    private DataHolder _dt;
    public GameObject dayStuff;
    public GameObject nightStuff;
    void Start()
    {
        _dt = GameObject.FindWithTag("DataHolder").GetComponent<DataHolder>();
        if(_dt.dayTime == true)
        {
            dayStuff.SetActive(true);
        }
        else
        {
            nightStuff.SetActive(true);
        }
    }
}
