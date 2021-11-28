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
            lipidioText.text = "+1 de Força devido a quantidade de Lipídios balanceados";
        }
        if(dataHolder.lipidio == 0 || dataHolder.lipidio == 10)
        {
            dataHolder.forca -= 1;
            lipidioText.text = "-1 de Força devido a quantidade de Lipídios desbalanceados";
        }
        //mineral
        if(dataHolder.mineral == 7 || dataHolder.mineral == 8)
        {
            dataHolder.forca += 1;
            mineralText.text = "+1 de Força devido a quantidade de Minerais balanceados";
        }
        if(dataHolder.mineral == 0 || dataHolder.mineral == 10)
        {
            dataHolder.forca -= 1;
            mineralText.text = "-1 de Força devido a quantidade de Minerais desbalanceados";
        }
        //vitamina
        if(dataHolder.vitamina == 7 || dataHolder.vitamina == 8)
        {
            dataHolder.resistencia += 1;
            vitaminaText.text = "+1 de Resistência devido a quantidade de Vitaminas balanceadas";
        }
        if(dataHolder.vitamina == 0 || dataHolder.vitamina == 10)
        {
            dataHolder.resistencia -= 1;
            vitaminaText.text = "-1 de Resistência devido a quantidade de Vitaminas desbalanceadas";
        }
        //fibra
        if(dataHolder.fibra == 7 || dataHolder.fibra == 8)
        {
            dataHolder.resistencia += 1;
            fibraText.text = "+1 de Resistência devido a quantidade de Fibras balanceadas";
        }
        if(dataHolder.fibra == 0 || dataHolder.fibra == 10)
        {
            dataHolder.resistencia -= 1;
            fibraText.text = "-1 de Resistência devido a quantidade de Fibras desbalanceadas";
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
