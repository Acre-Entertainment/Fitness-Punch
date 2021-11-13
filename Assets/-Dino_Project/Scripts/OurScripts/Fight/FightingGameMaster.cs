using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingGameMaster : MonoBehaviour
{
    private DataHolder dataHolder;
    void Start()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
