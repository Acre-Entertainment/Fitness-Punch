using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetResultsMenu : MonoBehaviour
{
    DataHolder dataHolder;
    public Text forcaText;
    public Text resistenciaText;
    public Text proteinaText;
    public Text carboidratoText;
    public Text lipidioText;
    public Text mineralText;
    public Text vitaminaText;
    public Text fibraText;
    void Start()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        forcaText.text = "Force: " + dataHolder.forca + "/12";
        resistenciaText.text = "Resistance: " + dataHolder.resistencia + "/12";
        proteinaText.text = "Proteins: " + dataHolder.proteina + "/10";
        carboidratoText.text = "Carbohydrates: " + dataHolder.carboidrato + "/10";
        lipidioText.text = "Lipids: " + dataHolder.lipidio + "/10";
        mineralText.text = "Minerals: " + dataHolder.mineral + "/10";
        vitaminaText.text = "Vitamins: " + dataHolder.vitamina + "/10";
        fibraText.text = "Fibers: " + dataHolder.fibra + "/10";
    }
}
