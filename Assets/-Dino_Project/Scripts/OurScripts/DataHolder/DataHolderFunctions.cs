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
    public void endTheDay()
    {
        //salva os valores do dia anterior
        DT.proteinaBefore = DT.proteina;
        DT.carboidratoBefore = DT.carboidrato;
        DT.lipidioBefore = DT.lipidio;
        DT.mineralBefore = DT.mineral;
        DT.vitaminaBefore = DT.vitamina;
        DT.fibraBefore = DT.fibra;
        DT.disposicaoBefore = DT.disposicao;
        //cheka se ha bonus ou debuff de disposição
        if(DT.proteina == 7 || DT.proteina == 8)
        {
            DT.disposicao += 1;
            DT.proteinaBonus = true;
        }
        else
        {
            DT.proteinaBonus = false;
        }
        if(DT.proteina == 0 || DT.proteina == 10)
        {
            DT.disposicao -= 1;
            DT.proteinaMalus = true;
        }
        else
        {
            DT.proteinaMalus = false;
        }
        if(DT.carboidrato == 7 || DT.carboidrato == 8)
        {
            DT.disposicao += 1;
            DT.carboidratoBonus = true;
        }
        else
        {
            DT.carboidratoBonus = false;
        }
        if(DT.carboidrato == 0 || DT.carboidrato == 10)
        {
            DT.disposicao -= 1;
            DT.carboidratoBonus = true;
        }
        else
        {
            DT.carboidratoMalus = false;
        }
        
        //diminui os atributos
        if(DT.forcaThisDay == 0 && DT.aerobicoThisDay == 0 && DT.dayOfTheWeek != 7)
        {
            DT.noExerciceBefore = true;
            DT.proteina -= 3;
            DT.carboidrato -= 3;
            DT.lipidio -= 3;
            DT.mineral -= 3;
            DT.vitamina -= 3;
            DT.fibra -= 3;
        }
        else
        {
            DT.noExerciceBefore = false;
            DT.proteina -= 1;
            DT.carboidrato -= 1;
            DT.lipidio -= 1;
            DT.mineral -= 1;
            DT.vitamina -= 1;
            DT.fibra -= 1;
        }
        //diminui força ou resistencia se n fez exercicio
        if(DT.aerobicoThisDay == 0 && DT.dayOfTheWeek != 7)
        {
            DT.resistencia -= 1;
            DT.noAerobicBefore = true;
        }
        else
        {
            DT.noAerobicBefore = false;
        }
        if(DT.forcaThisDay == 0 && DT.dayOfTheWeek != 7)
        {
            DT.forca -= 1;
            DT.noStrenghBefore = true;
        }
        else
        {
            DT.noStrenghBefore = false;
        }
        //reseta os valores
        DT.grocerThisDay = 0;
        DT.cookingThisDay = 0;
        DT.aerobicoThisDay = 0;
        DT.forcaThisDay = 0;
        DT.funThisDay = 0;
        DT.actions = 4;
        DT.dayOfTheWeek++;
        DT.dayOfEverything++;

        if(DT.proteina < 0){DT.proteina = 0;}
        if(DT.carboidrato < 0){DT.carboidrato = 0;}
        if(DT.lipidio < 0){DT.lipidio = 0;}
        if(DT.mineral < 0){DT.mineral = 0;}
        if(DT.vitamina < 0){DT.vitamina = 0;}
        if(DT.fibra < 0){DT.fibra = 0;}
        if(DT.forca < 0){DT.forca = 0;}
        if(DT.forca > 10){DT.forca = 10;}
        if(DT.resistencia < 0){DT.resistencia = 0;}
        if(DT.resistencia > 10){DT.resistencia = 10;}
        if(DT.disposicao < 0){DT.disposicao = 0;}
        if(DT.disposicao > 10){DT.disposicao = 10;}
        if(DT.dayOfTheWeek == 8){DT.dayOfTheWeek = 1;}
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
}
