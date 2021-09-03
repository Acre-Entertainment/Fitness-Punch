using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolderFunctions : MonoBehaviour
//use esse script para chamar funções que altera o DataHolder
{
    [HideInInspector] public DataHolder DT;
    void Start()
    {
        DT = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
    }
    public void addOneStep()
    {
        DT.stepsTaken++;
    }
}
