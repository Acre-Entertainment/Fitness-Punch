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

        proteinaText.text = "Proteins: +" + cookingGameMaster.changingPro;
        carboidratoText.text = "carbohydrates:+" + cookingGameMaster.changingCar;
        lipidioText.text = "lipids: +" + cookingGameMaster.changingLip;
        mineralText.text = "Minerals: +" + cookingGameMaster.changingMin;
        vitaminaText.text = "Vitamins: +" + cookingGameMaster.changingVit;
        fibraText.text = "Fibers: +" + cookingGameMaster.changingFib;
        if(cookingGameMaster.changingDis >= 0)
        {
            disposicaoText.text = "Disposition: +" + cookingGameMaster.changingDis;
        }
        if(cookingGameMaster.changingDis < 0)
        {
            disposicaoText.text = "Disposition: -" + -cookingGameMaster.changingDis;
        }
    }
}
