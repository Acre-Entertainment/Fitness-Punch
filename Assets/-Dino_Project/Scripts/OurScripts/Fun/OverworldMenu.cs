using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldMenu : MonoBehaviour
{
    private DataHolder dataHolder;
    void Start()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
    }

    public void onGoClick()
    {
        dataHolder.actions = dataHolder.actions - 1;
        dataHolder.funThisDay = dataHolder.funThisDay + 1;
        dataHolder.saiuDoApartamento = true;
    }
}
