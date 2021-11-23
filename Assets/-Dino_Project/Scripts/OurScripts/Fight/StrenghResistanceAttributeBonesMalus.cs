using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrenghResistanceAttributeBonesMalus : MonoBehaviour
{
    private DataHolder dataHolder;
    void Start()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        dataHolder.strenghBeforeFight = dataHolder.forca;
        dataHolder.resistenciaBeforeFight = dataHolder.resistencia;
        //lipidio
        if(dataHolder.lipidio == 7 || dataHolder.lipidio == 8)
        {
            dataHolder.forca += 1;
        }
        if(dataHolder.lipidio == 0 || dataHolder.lipidio == 10)
        {
            dataHolder.forca -= 1;
        }
        //mineral
        if(dataHolder.mineral == 7 || dataHolder.mineral == 8)
        {
            dataHolder.forca += 1;
        }
        if(dataHolder.mineral == 0 || dataHolder.mineral == 10)
        {
            dataHolder.forca -= 1;
        }
        //vitamina
        if(dataHolder.vitamina == 7 || dataHolder.vitamina == 8)
        {
            dataHolder.resistencia += 1;
        }
        if(dataHolder.vitamina == 0 || dataHolder.vitamina == 10)
        {
            dataHolder.resistencia -= 1;
        }
        //fibra
        if(dataHolder.fibra == 7 || dataHolder.fibra == 8)
        {
            dataHolder.resistencia += 1;
        }
        if(dataHolder.fibra == 0 || dataHolder.fibra == 10)
        {
            dataHolder.resistencia -= 1;
        }
    }
}
