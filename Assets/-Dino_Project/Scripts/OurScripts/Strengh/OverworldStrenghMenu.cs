using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldStrenghMenu : MonoBehaviour
{
    private DataHolder dataHolder;
    void Start()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
    }
    public void onPressGo()
    {
        dataHolder.fibra = dataHolder.fibra - 1;
        dataHolder.vitamina = dataHolder.vitamina - 1;
        dataHolder.actions = dataHolder.actions - 1;
    }

}
