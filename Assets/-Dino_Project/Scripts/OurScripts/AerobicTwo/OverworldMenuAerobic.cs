using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldMenuAerobic : MonoBehaviour
{
    private DataHolder dataHolder;
    void Start()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
    }
    public void onPressGo()
    {
        dataHolder.lipidio = dataHolder.lipidio - 1;
        dataHolder.mineral = dataHolder.mineral - 1;
        dataHolder.actions = dataHolder.actions - 1;
        dataHolder.disposicao = dataHolder.disposicao - (2 + dataHolder.forcaThisDay);
        dataHolder.aerobicoThisDay++;
        dataHolder.saiuDaAcademia = true;
    }
}
