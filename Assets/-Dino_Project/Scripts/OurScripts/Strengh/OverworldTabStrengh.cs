using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverworldTabStrengh : MonoBehaviour
{
    public Text dispositionText;
    public Text otherText;
    public GameObject goButton;
    private DataHolder dataHolder;
    void Start()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        DoThisThing();
    }
    public void DoThisThing()
    {
        if(dataHolder.forcaThisDay == 0)
        {
            dispositionText.text = "Já que é sua primeira vez fazendo este exercicio hoje, ele custa apenas 1 disposição!";
        }
        else
        {
            dispositionText.text = "Isso vai custar " + (1 + dataHolder.forcaThisDay) + " de disposição.";
        }
//---------------------------------------------------------------------------------
        if(dataHolder.actions == 0)
        {
            goButton.SetActive(false);
            otherText.text = "Você está sem ações por hoje!";
        }
        else
        {
            if(dataHolder.disposicao < 1 + dataHolder.forcaThisDay)
            {
                goButton.SetActive(false);
                otherText.text = "Você está sem disposição para isso!";
            }
            else
            {
                if(dataHolder.vitamina == 0)
                {
                    goButton.SetActive(false);
                    otherText.text = "Você não tem Vitamina para isso!";
                }
                else
                {
                    if(dataHolder.vitamina == 0)
                    {
                        goButton.SetActive(false);
                        otherText.text = "Você não tem Fibra para isso!";
                    }
                    else
                    {
                        goButton.SetActive(true);
                        otherText.text = "";
                    }
                }
            }
        }
    }

}
