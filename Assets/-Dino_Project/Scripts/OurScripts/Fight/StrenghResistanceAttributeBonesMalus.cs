using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrenghResistanceAttributeBonesMalus : MonoBehaviour
{
    private DataHolder dataHolder;
    public Text strenghText;
    public Text lipidioText;
    public Text mineralText;
    public Text resistenciaText;
    public Text vitaminaText;
    public Text fibraText;
    void Start()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        dataHolder.strenghBeforeFight = dataHolder.forca;
        dataHolder.resistenciaBeforeFight = dataHolder.resistencia;
        //lipidio
        if(dataHolder.lipidio == 7 || dataHolder.lipidio == 8)
        {
            dataHolder.forca += 1;
            lipidioText.text = "+1 of Strength due to the amount of balanced Lipids";
        }
        if(dataHolder.lipidio == 0 || dataHolder.lipidio == 10)
        {
            dataHolder.forca -= 1;
            lipidioText.text = "-1 of Strength due to the amount of unbalanced Lipids";
        }
        //mineral
        if(dataHolder.mineral == 7 || dataHolder.mineral == 8)
        {
            dataHolder.forca += 1;
            mineralText.text = "+1 of Strength due to the amount of balanced Minerals";
        }
        if(dataHolder.mineral == 0 || dataHolder.mineral == 10)
        {
            dataHolder.forca -= 1;
            mineralText.text = "-1 of Strength due to the amount of unbalanced Minerals";
        }
        //vitamina
        if(dataHolder.vitamina == 7 || dataHolder.vitamina == 8)
        {
            dataHolder.resistencia += 1;
            vitaminaText.text = "+1 of Resistance due to the amount of balanced Vitamins";
        }
        if(dataHolder.vitamina == 0 || dataHolder.vitamina == 10)
        {
            dataHolder.resistencia -= 1;
            vitaminaText.text = "-1 of Resistance due to the amount of unbalanced Vitamins";
        }
        //fibra
        if(dataHolder.fibra == 7 || dataHolder.fibra == 8)
        {
            dataHolder.resistencia += 1;
            fibraText.text = "+1 of Resistance due to the amount of balanced Fibers";
        }
        if(dataHolder.fibra == 0 || dataHolder.fibra == 10)
        {
            dataHolder.resistencia -= 1;
            fibraText.text = "-1 of Resistance due to the amount of unbalanced Fibers";
        }
        if(dataHolder.forca < 0)
        {
            dataHolder.forca = 0;
        }
        if(dataHolder.resistencia < 0)
        {
            dataHolder.resistencia = 0;
        }
        strenghText.text = "" + dataHolder.forca;
        resistenciaText.text = "" + dataHolder.resistencia;
    }
}
