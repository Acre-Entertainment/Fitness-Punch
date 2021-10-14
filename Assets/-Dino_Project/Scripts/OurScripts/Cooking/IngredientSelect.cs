using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientSelect : MonoBehaviour
{
    //caraca, esse codigo que eu fiz ta horrivel

    private DataHolder dt;
    private CookingGameMaster cgm;

    public GameObject button1;
    public GameObject button1Text;
    private Text _button1Text;
    public GameObject button2;
    public GameObject button2Text;
    private Text _button2Text;
    public GameObject button3;
    public GameObject button3Text;
    private Text _button3Text;
    public GameObject button4;
    public GameObject button4Text;
    private Text _button4Text;
    public GameObject button5;
    public GameObject button5Text;
    private Text _button5Text;
    public GameObject button6;
    public GameObject button6Text;
    private Text _button6Text;
    public GameObject button7;
    public GameObject button7Text;
    private Text _button7Text;
    public GameObject button8;
    public GameObject button8Text;
    private Text _button8Text;
    public GameObject button9;
    public GameObject button9Text;
    private Text _button9Text;
    public GameObject button10;
    public GameObject button10Text;
    private Text _button10Text;

    public GameObject proceedButton;

    private int selectedButton;
    private int selectedFoodID;
    public int[] selectedFoodsID = new int[3];

    public GameObject textTitle;
    private Text _textTitle;
    public GameObject textBody;
    private Text _textBody;

    public GameObject added1Text;
    private Text _added1Text;
    public GameObject added2Text;
    private Text _added2Text;
    public GameObject added3Text;
    private Text _added3Text;

    private int numberOfFoodAdded = 0;
    
    void Start()
    {
        cgm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<CookingGameMaster>();
        dt = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        dt.organizeInventory();

        _button1Text = button1Text.GetComponent<Text>();
        _button2Text = button2Text.GetComponent<Text>();
        _button3Text = button3Text.GetComponent<Text>();
        _button4Text = button4Text.GetComponent<Text>();
        _button5Text = button5Text.GetComponent<Text>();
        _button6Text = button6Text.GetComponent<Text>();
        _button7Text = button7Text.GetComponent<Text>();
        _button8Text = button8Text.GetComponent<Text>();
        _button9Text = button9Text.GetComponent<Text>();
        _button10Text = button10Text.GetComponent<Text>();
        _added1Text = added1Text.GetComponent<Text>();
        _added2Text = added2Text.GetComponent<Text>();
        _added3Text = added3Text.GetComponent<Text>();
        _textTitle = textTitle.GetComponent<Text>();

        //to do: make icons of inventory itens show up.
        if(dt.inventorySlots[9] != 0){button10.SetActive(true); _button10Text.text = "" + dt.inventorySlots[9];}
        if(dt.inventorySlots[8] != 0){button9.SetActive(true); _button9Text.text = "" + dt.inventorySlots[8];}
        if(dt.inventorySlots[7] != 0){button8.SetActive(true); _button8Text.text = "" + dt.inventorySlots[7];}
        if(dt.inventorySlots[6] != 0){button7.SetActive(true); _button7Text.text = "" + dt.inventorySlots[6];}
        if(dt.inventorySlots[5] != 0){button6.SetActive(true); _button6Text.text = "" + dt.inventorySlots[5];}
        if(dt.inventorySlots[4] != 0){button5.SetActive(true); _button5Text.text = "" + dt.inventorySlots[4];}
        if(dt.inventorySlots[3] != 0){button4.SetActive(true); _button4Text.text = "" + dt.inventorySlots[3];}
        if(dt.inventorySlots[2] != 0){button3.SetActive(true); _button3Text.text = "" + dt.inventorySlots[2];}
        if(dt.inventorySlots[1] != 0){button2.SetActive(true); _button2Text.text = "" + dt.inventorySlots[1];}
        if(dt.inventorySlots[0] != 0){button1.SetActive(true); _button1Text.text = "" + dt.inventorySlots[0];}
    }

    public void addSelectedFoodToAddedList()
    {
        switch (selectedButton)
        {
            case 1: button1.SetActive(false); break;
            case 2: button2.SetActive(false); break;
            case 3: button3.SetActive(false); break;
            case 4: button4.SetActive(false); break;
            case 5: button5.SetActive(false); break;
            case 6: button6.SetActive(false); break;
            case 7: button7.SetActive(false); break;
            case 8: button8.SetActive(false); break;
            case 9: button9.SetActive(false); break;
            case 10: button10.SetActive(false); break;
        }
        switch (numberOfFoodAdded)
        {
            case 0:
                selectedFoodsID[0] = selectedFoodID;
                _added1Text.text = "" + selectedFoodID;
                break;
            case 1:
                selectedFoodsID[1] = selectedFoodID;
                _added2Text.text = "" + selectedFoodID;
                break;
            case 2:
                selectedFoodsID[2] = selectedFoodID;
                _added3Text.text = "" + selectedFoodID;
                button1.SetActive(false);
                button2.SetActive(false);
                button3.SetActive(false);
                button4.SetActive(false);
                button5.SetActive(false);
                button6.SetActive(false);
                button7.SetActive(false);
                button8.SetActive(false);
                button9.SetActive(false);
                button10.SetActive(false);
                proceedButton.SetActive(true);

                cgm.selectedFoodsID = selectedFoodsID;

                break;
        }
        numberOfFoodAdded++;
    }


    public void selectButton1()
    {
        selectedFoodID = dt.inventorySlots[0];
        selectedButton = 1;
        _textTitle.text = "" + selectedFoodID;
    }
    public void selectButton2()
    {
        selectedFoodID = dt.inventorySlots[1];
        selectedButton = 2;
        _textTitle.text = "" + selectedFoodID;
    }
    public void selectButton3()
    {
        selectedFoodID = dt.inventorySlots[2];
        selectedButton = 3;
        _textTitle.text = "" + selectedFoodID;
    }
    public void selectButton4()
    {
        selectedFoodID = dt.inventorySlots[3];
        selectedButton = 4;
        _textTitle.text = "" + selectedFoodID;
    }
    public void selectButton5()
    {
        selectedFoodID = dt.inventorySlots[4];
        selectedButton = 5;
        _textTitle.text = "" + selectedFoodID;
    }
    public void selectButton6()
    {
        selectedFoodID = dt.inventorySlots[5];
        selectedButton = 6;
        _textTitle.text = "" + selectedFoodID;
    }
    public void selectButton7()
    {
        selectedFoodID = dt.inventorySlots[6];
        selectedButton = 7;
        _textTitle.text = "" + selectedFoodID;
    }
    public void selectButton8()
    {
        selectedFoodID = dt.inventorySlots[7];
        selectedButton = 8;
        _textTitle.text = "" + selectedFoodID;
    }
    public void selectButton9()
    {
        selectedFoodID = dt.inventorySlots[8];
        selectedButton = 9;
        _textTitle.text = "" + selectedFoodID;
    }
    public void selectButton10()
    {
        selectedFoodID = dt.inventorySlots[9];
        selectedButton = 10;
        _textTitle.text = "" + selectedFoodID;
    }
}
