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
    private int selectStage;
    private int[] selectedInventorySlots = new int[3];
    private int currentSelectedButton;
    private int currentSelectedInventoryID;
    void Start()
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
        if(dataHolder.inventorySlots[whichOne] != 0)
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
        if(selectStage == 4)
        {
            cookButton.SetActive(true);
            foreach(GameObject go in inventoryButtons)
            {
                go.SetActive(false);
            }
        }
        else
        {
            switch(selectStage)
            {
                case 1:

                    selectedOne.sprite = giveSpriteOfItenID(currentSelectedInventoryID);
                    if(currentSelectedInventoryID > 300)
                    {
                        selectedOneGlow.SetActive(true);
                    }
                    selectedCookingButtonOne = currentSelectedButton;
                    break;
                case 2:
                    selectedTwo.sprite = giveSpriteOfItenID(currentSelectedInventoryID);
                    if(currentSelectedInventoryID > 300)
                    {
                        selectedTwoGlow.SetActive(true);
                    }
                    selectedCookingButtonTwo = currentSelectedButton;
                    break;
                case 3:
                    selectedTwo.sprite = giveSpriteOfItenID(currentSelectedInventoryID);
                    if(currentSelectedInventoryID > 300)
                    {
                        selectedTwoGlow.SetActive(true);
                    }
                    selectedCookingButtonThree = currentSelectedButton;
                    break;
                
            }
        }
    }
    public void clickedCook()
    {
        dataHolder.selectedCookingFood[0] = dataHolder.inventorySlots[selectedCookingButtonOne - 1];
        dataHolder.inventorySlots[selectedCookingButtonOne - 1] = 0;
        dataHolder.selectedCookingFood[1] = dataHolder.inventorySlots[selectedCookingButtonTwo - 1];
        dataHolder.inventorySlots[selectedCookingButtonTwo - 1] = 0;
        dataHolder.selectedCookingFood[2] = dataHolder.inventorySlots[selectedCookingButtonThree - 1];
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
                showText1.text = "Amendoim de Baixa Qualidade:";
                showText2.text = "+1 Proteína";
                showText3.text = "+1 Fibra";
                return;
            case 102:
                showText1.text = "Carne Magra de Baixa Qualidade:";
                showText2.text = "+1 Proteína";
                showText3.text = "+1 Vitamina";
                return;
            case 103:
                showText1.text = "Ovo de Baixa Qualidade:";
                showText2.text = "+1 Proteína";
                showText3.text = "+1 Lipídio";
                return;
            case 104:
                showText1.text = "Arroz de Baixa Qualidade:";
                showText2.text = "+1 Proteína";
                showText3.text = "+1 Carboidrato";
                return;
            case 105:
                showText1.text = "Queijo de Baixa Qualidade:";
                showText2.text = "+1 Proteína";
                showText3.text = "+1 Mineral";
                return;
            case 106:
                showText1.text = "Brócolis de Baixa Qualidade:";
                showText2.text = "+1 Vitamina";
                showText3.text = "+1 Fibra";
                return;
            case 107:
                showText1.text = "Milho de Baixa Qualidade:";
                showText2.text = "+1 Mineral";
                showText3.text = "+1 Vitamina";
                return;
            case 108:
                showText1.text = "Chocolate de Baixa Qualidade:";
                showText2.text = "+1 Carboidrato";
                showText3.text = "+1 Lipídio";
                return;
            case 109:
                showText1.text = "Leite de Baixa Qualidade:";
                showText2.text = "+1 Lipídio";
                showText3.text = "+1 Mineral";
                return;
            case 110:
                showText1.text = "Cenoura de Baixa Qualidade:";
                showText2.text = "+1 Lipídio";
                showText3.text = "+1 Vitamina";
                return;
            case 111:
                showText1.text = "Pão de Baixa Qualidade:";
                showText2.text = "+1 Lipídio";
                showText3.text = "+1 Fibra";
                return;
            case 112:
                showText1.text = "Laranja de Baixa Qualidade:";
                showText2.text = "+1 Carboidrato";
                showText3.text = "+1 Vitamina";
                return;
            case 113:
                showText1.text = "Abacate de Baixa Qualidade:";
                showText2.text = "+1 Carboidrato";
                showText3.text = "+1 Fibra";
                return;
            case 114:
                showText1.text = "Batata de Baixa Qualidade:";
                showText2.text = "+1 Carboidrato";
                showText3.text = "+1 Mineral";
                return;
            case 115:
                showText1.text = "Amendoin de Baixa Qualidade:";
                showText2.text = "+1 Proteína";
                showText3.text = "+1 Fibra";
                return;
            case 201:
                showText1.text = "Amendoim de Média Qualidade:";
                showText2.text = "+2 Proteínas";
                showText3.text = "+2 Fibras";
                return;
            case 202:
                showText1.text = "Carne Magra de Média Qualidade:";
                showText2.text = "+2 Proteínas";
                showText3.text = "+2 Vitaminas";
                return;
            case 203:
                showText1.text = "Ovo de Média Qualidade:";
                showText2.text = "+2 Proteínas";
                showText3.text = "+2 Lipídios";
                return;
            case 204:
                showText1.text = "Arroz de Média Qualidade:";
                showText2.text = "+2 Proteínas";
                showText3.text = "+2 Carboidratos";
                return;
            case 205:
                showText1.text = "Queijo de Média Qualidade:";
                showText2.text = "+2 Proteínas";
                showText3.text = "+2 Minerais";
                return;
            case 206:
                showText1.text = "Brócolis de Média Qualidade:";
                showText2.text = "+2 Vitaminas";
                showText3.text = "+2 Fibras";
                return;
            case 207:
                showText1.text = "Milho de Média Qualidade:";
                showText2.text = "+2 Minerals";
                showText3.text = "+2 Vitaminas";
                return;
            case 208:
                showText1.text = "Chocolate de Média Qualidade:";
                showText2.text = "+2 Carboidratos";
                showText3.text = "+2 Lipídios";
                return;
            case 209:
                showText1.text = "Leite de Média Qualidade:";
                showText2.text = "+2 Lipídios";
                showText3.text = "+2 Minerais";
                return;
            case 210:
                showText1.text = "Cenoura de Média Qualidade:";
                showText2.text = "+2 Lipídios";
                showText3.text = "+2 Vitaminas";
                return;
            case 211:
                showText1.text = "Pão de Média Qualidade:";
                showText2.text = "+2 Lipídios";
                showText3.text = "+2 Fibras";
                return;
            case 212:
                showText1.text = "Laranja de Média Qualidade:";
                showText2.text = "+2 Carboidratos";
                showText3.text = "+2 Vitaminas";
                return;
            case 213:
                showText1.text = "Abacate de Média Qualidade:";
                showText2.text = "+2 Carboidratos";
                showText3.text = "+2 Fibras";
                return;
            case 214:
                showText1.text = "Batata de Média Qualidade:";
                showText2.text = "+2 Carboidratos";
                showText3.text = "+2 Minerais";
                return;
            case 215:
                showText1.text = "Amendoin de Média Qualidade:";
                showText2.text = "+2 Proteínas";
                showText3.text = "+2 Fibras";
                return;
            case 301:
                showText1.text = "Amendoim de Alta Qualidade:";
                showText2.text = "+2 Proteínas";
                showText3.text = "+2 Fibras";
                return;
            case 302:
                showText1.text = "Carne Magra de Alta Qualidade:";
                showText2.text = "+2 Proteínas";
                showText3.text = "+2 Vitaminas";
                return;
            case 303:
                showText1.text = "Ovo de Alta Qualidade:";
                showText2.text = "+2 Proteínas";
                showText3.text = "+2 Lipídios";
                return;
            case 304:
                showText1.text = "Arroz de Alta Qualidade:";
                showText2.text = "+2 Proteínas";
                showText3.text = "+2 Carboidratos";
                return;
            case 305:
                showText1.text = "Queijo de Alta Qualidade:";
                showText2.text = "+2 Proteínas";
                showText3.text = "+2 Minerais";
                return;
            case 306:
                showText1.text = "Brócolis de Alta Qualidade:";
                showText2.text = "+2 Vitaminas";
                showText3.text = "+2 Fibras";
                return;
            case 307:
                showText1.text = "Milho de Alta Qualidade:";
                showText2.text = "+2 Minerals";
                showText3.text = "+2 Vitaminas";
                return;
            case 308:
                showText1.text = "Chocolate de Alta Qualidade:";
                showText2.text = "+2 Carboidratos";
                showText3.text = "+2 Lipídios";
                return;
            case 309:
                showText1.text = "Leite de Alta Qualidade:";
                showText2.text = "+2 Lipídios";
                showText3.text = "+2 Minerais";
                return;
            case 310:
                showText1.text = "Cenoura de Alta Qualidade:";
                showText2.text = "+2 Lipídios";
                showText3.text = "+2 Vitaminas";
                return;
            case 311:
                showText1.text = "Pão de Alta Qualidade:";
                showText2.text = "+2 Lipídios";
                showText3.text = "+2 Fibras";
                return;
            case 312:
                showText1.text = "Laranja de Alta Qualidade:";
                showText2.text = "+2 Carboidratos";
                showText3.text = "+2 Vitaminas";
                return;
            case 313:
                showText1.text = "Abacate de Alta Qualidade:";
                showText2.text = "+2 Carboidratos";
                showText3.text = "+2 Fibras";
                return;
            case 314:
                showText1.text = "Batata de Alta Qualidade:";
                showText2.text = "+2 Carboidratos";
                showText3.text = "+2 Minerais";
                return;
            case 315:
                showText1.text = "Amendoin de Alta Qualidade:";
                showText2.text = "+2 Proteínas";
                showText3.text = "+2 Fibras";
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
