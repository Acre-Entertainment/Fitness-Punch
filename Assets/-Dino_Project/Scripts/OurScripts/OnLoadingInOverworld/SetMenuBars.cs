using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetMenuBars : MonoBehaviour
{
    private DataHolder dataHolder;
    public Slider resistencia;
    public Slider forca;
    public Slider disposição;
    public Slider carboidrato;
    public Slider vitamina;
    public Slider lipidio;
    public Slider mineral;
    public Slider fibra;
    public Slider proteina;
    void Start()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        forca.value = dataHolder.forca;
        resistencia.value = dataHolder.resistencia;
        disposição.value = dataHolder.disposicao;
        carboidrato.value = dataHolder.carboidrato;
        vitamina.value = dataHolder.vitamina;
        lipidio.value = dataHolder.lipidio;
        mineral.value = dataHolder.mineral;
        fibra.value = dataHolder.fibra;
        proteina.value = dataHolder.proteina;
    }
}
