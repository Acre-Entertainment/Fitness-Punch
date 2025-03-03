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
                textoAMudar.text = "Peanut: Protein and Fiber.";
                break;
            case 2:
                textoAMudar.text = "Lean Meat: Protein and Vitamins.";
                break;
            case 3:
                textoAMudar.text = "Egg: Protein and Lipids.";
                break;
            case 4:
                textoAMudar.text = "Rice: Protein and Carbohydrates.";
                break;
            case 5:
                textoAMudar.text = "Cheese: Protein and Minerals.";
                break;
            case 6:
                textoAMudar.text = "Broccoli: Vitamins and Fiber.";
                break;
            case 7:
                textoAMudar.text = "Corn: Minerals and Vitamins.";
                break;
            case 8:
                textoAMudar.text = "Chocolate: Carbohydrates and Lipids.";
                break;
            case 9:
                textoAMudar.text = "Milk: Lipids and Minerals.";
                break;
            case 10:
                textoAMudar.text = "Carrot: Lipids and Vitamins.";
                break;
            case 11:
                textoAMudar.text = "Bread: Lipids and Fiber.";
                break;
            case 12:
                textoAMudar.text = "Orange: Carbohydrates and Vitamins.";
                break;
            case 13:
                textoAMudar.text = "Avocado: Carbohydrates and Fiber.";
                break;
            case 14:
                textoAMudar.text = "Potato: Carbohydrates and Minerals.";
                break;
            case 15:
                textoAMudar.text = "Lettuce: Minerals and Fiber.";
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

        DT.disposicao = DT.disposicao - (1 + DT.grocerThisDay);
        DT.grocerThisDay++;
        DT.actions = DT.actions - 1;
        DT.saiuDoGrocer = true;
    }
}
