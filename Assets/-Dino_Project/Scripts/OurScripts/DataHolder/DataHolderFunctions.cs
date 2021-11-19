using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataHolderFunctions : MonoBehaviour
//use esse script para chamar funções que altera o DataHolder
{
    [HideInInspector] public DataHolder DT;

    [SerializeField] private GameObject proteinaMainMenuBar;
    [SerializeField] private GameObject carboidratoMainMenuBar;
    [SerializeField] private GameObject lipidioMainMenuBar;
    [SerializeField] private GameObject mineralMainMenuBar;
    [SerializeField] private GameObject vitaminaMainMenuBar;
    [SerializeField] private GameObject fibraMainMenuBar;
    [SerializeField] private GameObject disposicaoMainMenuBar;
    [SerializeField] private GameObject forcaMainMenuBar;
    [SerializeField] private GameObject resistenciaMainMenuBar;


    void Start()
    {
        DT = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
    }
    public void MainMenuSliderAdjustments()
    {
        proteinaMainMenuBar.GetComponent<Slider>().value = DT.proteina;
        carboidratoMainMenuBar.GetComponent<Slider>().value = DT.carboidrato;
        lipidioMainMenuBar.GetComponent<Slider>().value = DT.lipidio;
        mineralMainMenuBar.GetComponent<Slider>().value = DT.mineral;
        vitaminaMainMenuBar.GetComponent<Slider>().value = DT.vitamina;
        fibraMainMenuBar.GetComponent<Slider>().value = DT.fibra;
        disposicaoMainMenuBar.GetComponent<Slider>().value = DT.disposicao;
        forcaMainMenuBar.GetComponent<Slider>().value = DT.forca;
        resistenciaMainMenuBar.GetComponent<Slider>().value = DT.resistencia;
    }
    public void removeOneAction()
    {
        DT.actions = DT.actions - 1;
    }
    public void removeDisposition(int howMuch)
    {
        DT.disposicao = DT.disposicao - howMuch;
    }
    public void removeHealthThings(int pro, int car, int lip, int min, int vit, int fib)
    {
        DT.proteina = DT.proteina - pro;
        DT.carboidrato = DT.carboidrato - car;
        DT.lipidio = DT.lipidio - lip;
        DT.mineral = DT.mineral - min;
        DT.vitamina = DT.vitamina - vit;
        DT.fibra = DT.fibra - fib;
    }
    public void newDay()
    {
        DT.grocerThisDay = 0;
        DT.cookingThisDay = 0;
        DT.aerobicoThisDay = 0;
        DT.forcaThisDay = 0;
        DT.actions = 4;
    }
}
