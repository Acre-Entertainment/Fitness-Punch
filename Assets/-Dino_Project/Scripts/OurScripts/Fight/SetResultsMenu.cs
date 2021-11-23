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
        forcaText.text = "Força: " + dataHolder.forca + "/12";
        resistenciaText.text = "Resistência: " + dataHolder.resistencia + "/12";
        proteinaText.text = "Proteínas: " + dataHolder.proteina + "/10";
        carboidratoText.text = "Carboidratos: " + dataHolder.carboidrato + "/10";
        lipidioText.text = "Lipídios: " + dataHolder.lipidio + "/10";
        mineralText.text = "Minerais: " + dataHolder.mineral + "/10";
        vitaminaText.text = "Vitaminas: " + dataHolder.vitamina + "/10";
        fibraText.text = "Fibras: " + dataHolder.fibra + "/10";
    }
}
