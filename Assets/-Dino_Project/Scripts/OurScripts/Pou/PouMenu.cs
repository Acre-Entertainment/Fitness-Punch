using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PouMenu : MonoBehaviour
{
    public Image display1;
    public Image display2;
    public Image display3;
    public Image display4;
    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    public Sprite[] foodSprites;
    [SerializeField] private int numberOfFoodInTheGame;
    private int number1 = 1;
    private int number2 = 1;
    private int number3 = 1;
    private int number4 = 1;
    private DataHolder DT;

    public void addNumber1()
    {
        number1++;
        if(number1 > numberOfFoodInTheGame)
        {
            number1 = 1;
        }
        display1.sprite = foodSprites[number1 - 1];
        setText(1);
    }
    public void subtractNumber1()
    {
        number1--;
        if(number1 == 0)
        {
            number1 = numberOfFoodInTheGame;
        }
        display1.sprite = foodSprites[number1 - 1];
        setText(1);
    }
    public void addNumber2()
    {
        number2++;
        if(number2 > numberOfFoodInTheGame)
        {
            number2 = 1;
        }
        display2.sprite = foodSprites[number2 - 1];
        setText(2);
    }
    public void subtractNumber2()
    {
        number2--;
        if(number2 == 0)
        {
            number2 = numberOfFoodInTheGame;
        }
        display2.sprite = foodSprites[number2 - 1];
        setText(2);
    }
    public void addNumber3()
    {
        number3++;
        if(number3 > numberOfFoodInTheGame)
        {
            number3 = 1;
        }
        display3.sprite = foodSprites[number3 - 1];
        setText(3);
    }
    public void subtractNumber3()
    {
        number3--;
        if(number3 == 0)
        {
            number3 = numberOfFoodInTheGame;
        }
        display3.sprite = foodSprites[number3 - 1];
        setText(3);
    }
    public void addNumber4()
    {
        number4++;
        if(number4 > numberOfFoodInTheGame)
        {
            number4 = 1;
        }
        display4.sprite = foodSprites[number4 - 1];
        setText(4);
    }
    public void subtractNumber4()
    {
        number4--;
        if(number4 == 0)
        {
            number4 = numberOfFoodInTheGame;
        }
        display4.sprite = foodSprites[number4 - 1];
        setText(4);
    }
    private void setText(int whichFood)
    {
        Text textoAMudar = text1;
        int IDDaComidaAMudar = 0;
        switch(whichFood)
        {
            case 1:
                textoAMudar = text1;
                IDDaComidaAMudar = number1;
                break;
            case 2:
                textoAMudar = text2;
                IDDaComidaAMudar = number2;
                break;
            case 3:
                textoAMudar = text3;
                IDDaComidaAMudar = number3;
                break;
            case 4:
                textoAMudar = text4;
                IDDaComidaAMudar = number4;
                break;
        }
        switch(IDDaComidaAMudar)
        {
            case 1:
                textoAMudar.text = "Amendoin: Proteínas e Fibras";
                break;
            case 2:
                textoAMudar.text = "Carne Magra: Proteínas e Vitaminas";
                break;
            case 3:
                textoAMudar.text = "Ovo: Proteínas e Lipídios";
                break;
            case 4:
                textoAMudar.text = "Arroz: Proteínas e Carboidratos";
                break;
            case 5:
                textoAMudar.text = "Queijo: Proteínas e Minerais";
                break;
            case 6:
                textoAMudar.text = "Brócolis: Vitaminas e Fibras";
                break;
            case 7:
                textoAMudar.text = "Milho: Minerais e Vitaminas";
                break;
            case 8:
                textoAMudar.text = "Chocolate: Carboidratos e Lipídios";
                break;
            case 9:
                textoAMudar.text = "Leite: Lipídios e Minerais";
                break;
            case 10:
                textoAMudar.text = "Cenoura: Lipídios e Vitaminas";
                break;
            case 11:
                textoAMudar.text = "Pão: Lipídios e Fibras";
                break;
            case 12:
                textoAMudar.text = "Laranja: Carboidratos e Vitaminas";
                break;
            case 13:
                textoAMudar.text = "Abacate: Carboidratos e Fibras";
                break;
            case 14:
                textoAMudar.text = "Batata: Carboidratos e Minerais";
                break;
            case 15:
                textoAMudar.text = "Alfaçe: Minerais e Fibras";
                break;
        }
    }
    public void saveGrocerChoice()
    {
        DT = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        DT.selectedGrocerFood[0] = number1;
        DT.selectedGrocerFood[1] = number2;
        DT.selectedGrocerFood[2] = number3;
        DT.selectedGrocerFood[3] = number4;
    }
}
