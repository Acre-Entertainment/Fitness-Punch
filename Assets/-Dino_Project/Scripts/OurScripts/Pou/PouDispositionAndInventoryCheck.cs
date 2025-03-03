using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PouDispositionAndInventoryCheck : MonoBehaviour
{
    [HideInInspector] public DataHolder DT;
    [SerializeField] private GameObject goButton;
    [SerializeField] private GameObject noDispositionText;
    [SerializeField] private GameObject dispositionText;
    [SerializeField] private GameObject noInvetoryText;
    [SerializeField] private GameObject noActionsText;
    [SerializeField] private int neededDisposition;
    [SerializeField] private int invetorySize;
    void Start()
    {
        DT = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        neededDisposition = 1 + DT.grocerThisDay;
        noDispositionText.GetComponent<Text>().text = "Your disposition level isn't high enough! You need  and you have  " + (1 + DT.grocerThisDay) + " and you have " + DT.disposicao + "!";
        if(DT.grocerThisDay == 0)
        {
            dispositionText.GetComponent<Text>().text = "Your first purchase of the day costs 1 energy.";
        }
        else
        {
            dispositionText.GetComponent<Text>().text = "-" + neededDisposition + " disposition";
        }
    }
    public void doCheckAndAct()
    {
        DT.organizeInventory();
        DT.selectedGrocerFood[0] = 1;
        DT.selectedGrocerFood[0] = 2;
        DT.selectedGrocerFood[0] = 3;
        DT.selectedGrocerFood[0] = 4;
        if(DT.actions == 0)
        {
            goButton.SetActive(false);
            noDispositionText.SetActive(false);
            noActionsText.SetActive(true);
            noInvetoryText.SetActive(true);
        }
        else
        {
            if(DT.inventorySlots[9] != 0)
            {
                goButton.SetActive(false);
                noDispositionText.SetActive(false);
                noActionsText.SetActive(false);
                noInvetoryText.SetActive(true);
            }
            else
            {
                if(DT.disposicao >= neededDisposition)
                {
                    goButton.SetActive(true);
                    noDispositionText.SetActive(false);
                    noActionsText.SetActive(false);
                    noInvetoryText.SetActive(false);
                }
                else
                {
                    goButton.SetActive(false);
                    noDispositionText.SetActive(true);
                    noActionsText.SetActive(false);
                    noInvetoryText.SetActive(false);
                }
            }
        }
    }
}
