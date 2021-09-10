using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PouMenu : MonoBehaviour
{
    public GameObject display1;
    public GameObject display2;
    public GameObject display3;
    public GameObject display4;
    private Text text1;
    private Text text2;
    private Text text3;
    private Text text4;
    [SerializeField] private int numberOfFoodInTheGame;
    private int number1 = 1;
    private int number2 = 1;
    private int number3 = 1;
    private int number4 = 1;
    private DataHolder DT;
    void Start()
    {
        text1 = display1.GetComponent<Text>();
        text2 = display2.GetComponent<Text>();
        text3 = display3.GetComponent<Text>();
        text4 = display4.GetComponent<Text>();
    }

    public void addNumber1()
    {
        number1++;
        if(number1 > numberOfFoodInTheGame)
        {
            number1 = 1;
        }
        text1.text = "" + number1;
    }
    public void subtractNumber1()
    {
        number1--;
        if(number1 == 0)
        {
            number1 = numberOfFoodInTheGame;
        }
        text1.text = "" + number1;
    }
    public void addNumber2()
    {
        number2++;
        if(number2 > numberOfFoodInTheGame)
        {
            number2 = 1;
        }
        text2.text = "" + number2;
    }
    public void subtractNumber2()
    {
        number2--;
        if(number2 == 0)
        {
            number2 = numberOfFoodInTheGame;
        }
        text2.text = "" + number2;
    }
    public void addNumber3()
    {
        number3++;
        if(number3 > numberOfFoodInTheGame)
        {
            number3 = 1;
        }
        text3.text = "" + number3;
    }
    public void subtractNumber3()
    {
        number3--;
        if(number3 == 0)
        {
            number3 = numberOfFoodInTheGame;
        }
        text3.text = "" + number3;
    }
    public void addNumber4()
    {
        number4++;
        if(number4 > numberOfFoodInTheGame)
        {
            number4 = 1;
        }
        text4.text = "" + number4;
    }
    public void subtractNumber4()
    {
        number4--;
        if(number4 == 0)
        {
            number4 = numberOfFoodInTheGame;
        }
        text4.text = "" + number4;
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
