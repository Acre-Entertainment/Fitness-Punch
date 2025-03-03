using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverworldPopupCooking : MonoBehaviour
{
    private DataHolder dataHolder;
    public GameObject textoDeNoInventory;
    public GameObject textoDeNoDisposition;
    public GameObject textoDeNoAction;
    public GameObject mainButtons;
    public Text disposicaoText;
    void Start()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        checkInventoryAndDoStuff();
    }
    public void checkInventoryAndDoStuff()
    {
        if(dataHolder.cookingThisDay == 0)
        {
            disposicaoText.text = "Your first time cooking of the day doesn't cost energy!";
        }
        else
        {
            disposicaoText.text = "-" + dataHolder.cookingThisDay + " Disposition";
        }
        if(dataHolder.actions == 0)
        {
            mainButtons.SetActive(false);
            textoDeNoDisposition.SetActive(false);
            textoDeNoInventory.SetActive(false);
            textoDeNoAction.SetActive(true);
        }
        else
        {
            if(dataHolder.disposicao < dataHolder.cookingThisDay)
            {
                mainButtons.SetActive(false);
                textoDeNoDisposition.SetActive(true);
                textoDeNoInventory.SetActive(false);
                textoDeNoAction.SetActive(false);

                textoDeNoDisposition.GetComponent<Text>().text = "You don't have enough disposition! You have " + dataHolder.disposicao + " and you need " + dataHolder.cookingThisDay + "!";
            }
            else
            {
                dataHolder.organizeInventory();
                if(dataHolder.inventorySlots[7] == 0)
                {
                    mainButtons.SetActive(false);
                    textoDeNoDisposition.SetActive(false);
                    textoDeNoInventory.SetActive(true);
                    textoDeNoAction.SetActive(false);
                }
                else
                {
                    mainButtons.SetActive(true);
                    textoDeNoDisposition.SetActive(false);
                    textoDeNoInventory.SetActive(false);
                    textoDeNoAction.SetActive(false);
                }
            }
        }
    }
}
