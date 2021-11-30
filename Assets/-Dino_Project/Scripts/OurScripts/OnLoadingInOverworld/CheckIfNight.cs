using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfNight : MonoBehaviour
{
    private DataHolder dataHolder;
    public GameObject night;
    public GameObject[] lights;
    void Start()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        if(dataHolder.actions < 3)
        {
            night.SetActive(true);
            foreach(GameObject gameObject in lights)
            {
                gameObject.SetActive(true);
            }
        }
    }
}
