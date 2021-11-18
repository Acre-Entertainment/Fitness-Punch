using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouDispositionAndInventoryCheck : MonoBehaviour
{
    [HideInInspector] public DataHolder DT;
    [SerializeField] private GameObject goButton;
    [SerializeField] private GameObject noDispositionText;
    [SerializeField] private GameObject noInvetoryText;
    [SerializeField] private int neededDisposition;
    [SerializeField] private int invetorySize;
    void Start()
    {
        DT = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
    }
    public void doCheckAndAct()
    {
        DT.organizeInventory();
        if(DT.inventorySlots[9] != 0)
        {
            goButton.SetActive(false);
            noDispositionText.SetActive(false);
            noInvetoryText.SetActive(true);
        }
        else
        {
            if(DT.disposicao >= neededDisposition)
            {
                goButton.SetActive(true);
                noDispositionText.SetActive(false);
                noInvetoryText.SetActive(false);
            }
            else
            {
                goButton.SetActive(false);
                noDispositionText.SetActive(true);
                noInvetoryText.SetActive(false);
            }
        }
    }
}
