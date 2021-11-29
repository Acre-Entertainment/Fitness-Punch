using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaDormirMano : MonoBehaviour
{
    public GameObject[] junk;
    public GameObject text;
    private DataHolder dataHolder;
    void Start()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        if(dataHolder.actions == 0)
        {
            foreach(GameObject go in junk)
            {
                go.SetActive(false);
            }
            text.SetActive(true);
        }
    }

}
