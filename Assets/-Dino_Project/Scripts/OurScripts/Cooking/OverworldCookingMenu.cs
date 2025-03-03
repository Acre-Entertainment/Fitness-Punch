using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverworldCookingMenu : MonoBehaviour
{
    private DataHolder dataHolder;
    public Sprite[] invetorySprites;
    public GameObject[] inventoryButtons;
    public Image[] inventoryButtonsImage;
    public GameObject[] inventoryButtonsImageGlow;
    public GameObject showImage;
    public GameObject showImageGlow;
    private Image showImageComponent;
    public Text showText1;
    public Text showText2;
    public Text showText3;
    public GameObject SelectedOneGameobject;
    private Image selectedOne;
    public GameObject selectedOneGlow;
    public GameObject SelectedTwoGameobject;
    private Image selectedTwo;
    public GameObject selectedTwoGlow;
    public GameObject SelectedThreeGameobject;
    private Image selectedThree;
    public GameObject selectedThreeGlow;
    public GameObject addButton;
    public GameObject cookButton;
    private int selectedCookingButtonOne, selectedCookingButtonTwo, selectedCookingButtonThree;
    [SerializeField] private int selectStage;
    private int[] selectedInventorySlots = new int[3];
    private int currentSelectedButton;
    private int currentSelectedInventoryID;
    void Awake()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        showImageComponent = showImage.GetComponent<Image>();
        selectedOne = SelectedOneGameobject.GetComponent<Image>();
        selectedTwo = SelectedTwoGameobject.GetComponent<Image>();
        selectedThree = SelectedThreeGameobject.GetComponent<Image>();
    }
    void OnEnable()
    {
        selectStage = 0; selectedCookingButtonOne = 0; selectedCookingButtonTwo = 0; selectedCookingButtonThree = 0;
        foreach(GameObject go in inventoryButtons)
        {
            go.SetActive(false);
        }
        activateButtons(0);
        activateButtons(1);
        activateButtons(2);
        activateButtons(3);
        activateButtons(4);
        activateButtons(5);
        activateButtons(6);
        activateButtons(7);
        activateButtons(8);
        activateButtons(9);
        
    }
    void activateButtons(int whichOne)
    {
        if(dataHolder.inventorySlots[whichOne] > 0)
        {
            inventoryButtons[whichOne].SetActive(true);
            inventoryButtonsImage[whichOne].sprite = giveSpriteOfItenID(dataHolder.inventorySlots[whichOne]);
            if(dataHolder.inventorySlots[whichOne] > 300)
            {
                inventoryButtonsImageGlow[whichOne].SetActive(true);
            }
        }
    }
    public void clickedInventory1()
    {
        SetShowImage(1);
    }
    public void clickedInventory2()
    {
        SetShowImage(2);
    }
    public void clickedInventory3()
    {
        SetShowImage(3);
    }
    public void clickedInventory4()
    {
        SetShowImage(4);
    }
    public void clickedInventory5()
    {
        SetShowImage(5);
    }
    public void clickedInventory6()
    {
        SetShowImage(6);
    }
    public void clickedInventory7()
    {
        SetShowImage(7);
    }
    public void clickedInventory8()
    {
        SetShowImage(8);
    }
    public void clickedInventory9()
    {
        SetShowImage(9);
    }
    public void clickedInventory10()
    {
        SetShowImage(10);
    }
    public void clickedAdd()
    {
        addButton.SetActive(false);
        inventoryButtons[currentSelectedButton -1].SetActive(false);
        dataHolder.selectedCookingFood[selectStage] = currentSelectedInventoryID;
        selectStage++;
        switch(selectStage)
        {
            case 1:
                SelectedOneGameobject.SetActive(true);
                selectedOne.sprite = giveSpriteOfItenID(currentSelectedInventoryID);
                if(currentSelectedInventoryID > 300)
                {
                    selectedOneGlow.SetActive(true);
                }
                selectedCookingButtonOne = currentSelectedButton;
                break;
            case 2:
                SelectedTwoGameobject.SetActive(true);
                selectedTwo.sprite = giveSpriteOfItenID(currentSelectedInventoryID);
                if(currentSelectedInventoryID > 300)
                {
                    selectedTwoGlow.SetActive(true);
                }
                selectedCookingButtonTwo = currentSelectedButton;
                break;
            case 3:
                SelectedThreeGameobject.SetActive(true);
                selectedThree.sprite = giveSpriteOfItenID(currentSelectedInventoryID);
                if(currentSelectedInventoryID > 300)
                {
                    selectedTwoGlow.SetActive(true);
                }
                selectedCookingButtonThree = currentSelectedButton;

                cookButton.SetActive(true);
                foreach(GameObject go in inventoryButtons)
                {
                    go.SetActive(false);
                }
                break;
            }
    }
    public void clickedCook()
    {
        dataHolder.inventorySlots[selectedCookingButtonOne - 1] = 0;
        dataHolder.inventorySlots[selectedCookingButtonTwo - 1] = 0;
        dataHolder.inventorySlots[selectedCookingButtonThree - 1] = 0;
        dataHolder.organizeInventory();
        dataHolder.actions = dataHolder.actions - 1;
        dataHolder.disposicao = dataHolder.disposicao - dataHolder.cookingThisDay;
        dataHolder.cookingThisDay++;
        dataHolder.saiuDoApartamento = true;
    }
    public void setTextToNothing()
    {
        showText1.text = "";
        showText2.text = "";
        showText3.text = "";
    }
    private void SetShowImage(int button)
    {
        showImage.SetActive(true);
        currentSelectedButton = button;
        currentSelectedInventoryID = dataHolder.inventorySlots[button - 1];
        showImageComponent.sprite = giveSpriteOfItenID(dataHolder.inventorySlots[button - 1]);
        SetShowText(dataHolder.inventorySlots[button - 1]);
        if(dataHolder.inventorySlots[button - 1] > 300)
        {
            showImageGlow.SetActive(true);
        }
        else
        {
            showImageGlow.SetActive(false);
        }
        addButton.SetActive(true);
    }
    private void SetShowText(int foodID)
    {
        switch(foodID)
        {
            case 101:
                showText1.text = "Low-Quality Peanut:";
                showText2.text = "+1 Protein";
                showText3.text = "+1 Fiber";
                return;
            case 102:
                showText1.text = "Low-Quality Lean Meat:";
                showText2.text = "+1 Protein";
                showText3.text = "+1 Vitamin";
                return;
            case 103:
                showText1.text = "Low-Quality Egg:";
                showText2.text = "+1 Protein";
                showText3.text = "+1 Lipid";
                return;
            case 104:
                showText1.text = "Low-Quality Rice:";
                showText2.text = "+1 Protein";
                showText3.text = "+1 Carbohydrate";
                return;
            case 105:
                showText1.text = "Low-Quality Cheese:";
                showText2.text = "+1 Protein";
                showText3.text = "+1 Mineral";
                return;
            case 106:
                showText1.text = "Low-Quality Broccoli:";
                showText2.text = "+1 Vitamin";
                showText3.text = "+1 Fiber";
                return;
            case 107:
                showText1.text = "Low-Quality Corn:";
                showText2.text = "+1 Mineral";
                showText3.text = "+1 Vitamin";
                return;
            case 108:
                showText1.text = "Low-Quality Chocolate:";
                showText2.text = "+1 Carbohydrate";
                showText3.text = "+1 Lipid";
                return;
            case 109:
                showText1.text = "Low-Quality Milk:";
                showText2.text = "+1 Lipid";
                showText3.text = "+1 Mineral";
                return;
            case 110:
                showText1.text = "Low-Quality Carrot:";
                showText2.text = "+1 Lipid";
                showText3.text = "+1 Vitamin";
                return;
            case 111:
                showText1.text = "Low-Quality Bread:";
                showText2.text = "+1 Lipid";
                showText3.text = "+1 Fiber";
                return;
            case 112:
                showText1.text = "Low-Quality Orange:";
                showText2.text = "+1 Carbohydrate";
                showText3.text = "+1 Vitamin";
                return;
            case 113:
                showText1.text = "Low-Quality Avocado:";
                showText2.text = "+1 Carbohydrate";
                showText3.text = "+1 Fiber";
                return;
            case 114:
                showText1.text = "Low-Quality Potato:";
                showText2.text = "+1 Carbohydrate";
                showText3.text = "+1 Mineral";
                return;
            case 115:
                showText1.text = "Low-Quality Peanut:";
                showText2.text = "+1 Protein";
                showText3.text = "+1 Fiber";
                return;
            case 201:
                showText1.text = "Medium-Quality Peanut:";
                showText2.text = "+2 Protein";
                showText3.text = "+2 Fiber";
                return;
            case 202:
                showText1.text = "Medium-Quality Lean Meat:";
                showText2.text = "+2 Protein";
                showText3.text = "+2 Vitamin";
                return;
            case 203:
                showText1.text = "Medium-Quality Egg:";
                showText2.text = "+2 Protein";
                showText3.text = "+2 Lipid";
                return;
            case 204:
                showText1.text = "Medium-Quality Rice:";
                showText2.text = "+2 Protein";
                showText3.text = "+2 Carbohydrate";
                return;
            case 205:
                showText1.text = "Medium-Quality Cheese:";
                showText2.text = "+2 Protein";
                showText3.text = "+2 Mineral";
                return;
            case 206:
                showText1.text = "Medium-Quality Broccoli:";
                showText2.text = "+2 Vitamin";
                showText3.text = "+2 Fiber";
                return;
            case 207:
                showText1.text = "Medium-Quality Corn:";
                showText2.text = "+2 Mineral";
                showText3.text = "+2 Vitamin";
                return;
            case 208:
                showText1.text = "Medium-Quality Chocolate:";
                showText2.text = "+2 Carbohydrate";
                showText3.text = "+2 Lipid";
                return;
            case 209:
                showText1.text = "Medium-Quality Milk:";
                showText2.text = "+2 Lipid";
                showText3.text = "+2 Mineral";
                return;
            case 210:
                showText1.text = "Medium-Quality Carrot:";
                showText2.text = "+2 Lipid";
                showText3.text = "+2 Vitamin";
                return;
            case 211:
                showText1.text = "Medium-Quality Bread:";
                showText2.text = "+2 Lipid";
                showText3.text = "+2 Fiber";
                return;
            case 212:
                showText1.text = "Medium-Quality Orange:";
                showText2.text = "+2 Carbohydrate";
                showText3.text = "+2 Vitamin";
                return;
            case 213:
                showText1.text = "Medium-Quality Avocado:";
                showText2.text = "+2 Carbohydrate";
                showText3.text = "+2 Fiber";
                return;
            case 214:
                showText1.text = "Medium-Quality Potato:";
                showText2.text = "+2 Carbohydrate";
                showText3.text = "+2 Mineral";
                return;
            case 215:
                showText1.text = "Medium-Quality Peanut:";
                showText2.text = "+2 Protein";
                showText3.text = "+2 Fiber";
                return;
            case 301:
                showText1.text = "High-Quality Peanut:";
                showText2.text = "+3 Protein";
                showText3.text = "+3 Fiber";
                return;
            case 302:
                showText1.text = "High-Quality Lean Meat:";
                showText2.text = "+3 Protein";
                showText3.text = "+3 Vitamin";
                return;
            case 303:
                showText1.text = "High-Quality Egg:";
                showText2.text = "+3 Protein";
                showText3.text = "+3 Lipid";
                return;
            case 304:
                showText1.text = "High-Quality Rice:";
                showText2.text = "+3 Protein";
                showText3.text = "+3 Carbohydrate";
                return;
            case 305:
                showText1.text = "High-Quality Cheese:";
                showText2.text = "+3 Protein";
                showText3.text = "+3 Mineral";
                return;
            case 306:
                showText1.text = "High-Quality Broccoli:";
                showText2.text = "+3 Vitamin";
                showText3.text = "+3 Fiber";
                return;
            case 307:
                showText1.text = "High-Quality Corn:";
                showText2.text = "+3 Mineral";
                showText3.text = "+3 Vitamin";
                return;
            case 308:
                showText1.text = "High-Quality Chocolate:";
                showText2.text = "+3 Carbohydrate";
                showText3.text = "+3 Lipid";
                return;
            case 309:
                showText1.text = "High-Quality Milk:";
                showText2.text = "+3 Lipid";
                showText3.text = "+3 Mineral";
                return;
            case 310:
                showText1.text = "High-Quality Carrot:";
                showText2.text = "+3 Lipid";
                showText3.text = "+3 Vitamin";
                return;
            case 311:
                showText1.text = "High-Quality Bread:";
                showText2.text = "+3 Lipid";
                showText3.text = "+3 Fiber";
                return;
            case 312:
                showText1.text = "High-Quality Orange:";
                showText2.text = "+3 Carbohydrate";
                showText3.text = "+3 Vitamin";
                return;
            case 313:
                showText1.text = "High-Quality Avocado:";
                showText2.text = "+3 Carbohydrate";
                showText3.text = "+3 Fiber";
                return;
            case 314:
                showText1.text = "High-Quality Potato:";
                showText2.text = "+3 Carbohydrate";
                showText3.text = "+3 Mineral";
                return;
            case 315:
                showText1.text = "High-Quality Peanut:";
                showText2.text = "+3 Protein";
                showText3.text = "+3 Fiber";
                return;
            
        }
    }
    Sprite giveSpriteOfItenID(int itenID)
    {
        switch(itenID)
        {
            case 101:
                return invetorySprites[0];
            case 102:
                return invetorySprites[1];
            case 103:
                return invetorySprites[2];
            case 104:
                return invetorySprites[3];
            case 105:
                return invetorySprites[4];
            case 106:
                return invetorySprites[5];
            case 107:
                return invetorySprites[6];
            case 108:
                return invetorySprites[7];
            case 109:
                return invetorySprites[8];
            case 110:
                return invetorySprites[9];
            case 111:
                return invetorySprites[10];
            case 112:
                return invetorySprites[11];
            case 113:
                return invetorySprites[12];
            case 114:
                return invetorySprites[13];
            case 115:
                return invetorySprites[14];
            case 201:
                return invetorySprites[15];
            case 202:
                return invetorySprites[16];
            case 203:
                return invetorySprites[17];
            case 204:
                return invetorySprites[18];
            case 205:
                return invetorySprites[19];
            case 206:
                return invetorySprites[20];
            case 207:
                return invetorySprites[21];
            case 208:
                return invetorySprites[22];
            case 209:
                return invetorySprites[23];
            case 210:
                return invetorySprites[24];
            case 211:
                return invetorySprites[25];
            case 212:
                return invetorySprites[26];
            case 213:
                return invetorySprites[27];
            case 214:
                return invetorySprites[28];
            case 215:
                return invetorySprites[29];
            case 301:
                return invetorySprites[15];
            case 302:
                return invetorySprites[16];
            case 303:
                return invetorySprites[17];
            case 304:
                return invetorySprites[18];
            case 305:
                return invetorySprites[19];
            case 306:
                return invetorySprites[20];
            case 307:
                return invetorySprites[21];
            case 308:
                return invetorySprites[22];
            case 309:
                return invetorySprites[23];
            case 310:
                return invetorySprites[24];
            case 311:
                return invetorySprites[25];
            case 312:
                return invetorySprites[26];
            case 313:
                return invetorySprites[27];
            case 314:
                return invetorySprites[28];
            case 315:
                return invetorySprites[29];
            
            
            default:
                return invetorySprites[0];
        }
    }
}
