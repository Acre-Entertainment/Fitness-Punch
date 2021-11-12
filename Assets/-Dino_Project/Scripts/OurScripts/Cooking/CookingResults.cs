using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookingResults : MonoBehaviour
{
    private DataHolder dataHolder;
    private CookingGameMaster cookingGameMaster;
    public Text proteinaText;
    public Text carboidratoText;
    public Text lipidioText;
    public Text mineralText;
    public Text vitaminaText;
    public Text fibraText;
    public Text disposicaoText;
    void Start()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        cookingGameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<CookingGameMaster>();

        proteinaText.text = "Proteínas: +" + cookingGameMaster.changingPro;
        carboidratoText.text = "Carboidratos:+" + cookingGameMaster.changingCar;
        lipidioText.text = "Lipídios: +" + cookingGameMaster.changingLip;
        mineralText.text = "Minerais: +" + cookingGameMaster.changingMin;
        vitaminaText.text = "Vitaminas: +" + cookingGameMaster.changingVit;
        fibraText.text = "Fibras: +" + cookingGameMaster.changingFib;
        if(cookingGameMaster.changingDis >= 0)
        {
            disposicaoText.text = "Disposição: +" + cookingGameMaster.changingDis;
        }
        if(cookingGameMaster.changingDis < 0)
        {
            disposicaoText.text = "Disposição: -" + -cookingGameMaster.changingDis;
        }
    }
}
