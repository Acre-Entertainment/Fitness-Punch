using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverworldTabAerobic : MonoBehaviour
{
    private DataHolder dataHolder;
    public Text dispositionText;
    public Text otherText;
    public GameObject goButton;
    void Start()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        doTheThing();
    }
    public void doTheThing()
    {
        if(dataHolder.forcaThisDay == 0)
        {
            dispositionText.text = "Já que é sua primeira vez fazendo este exercicio hoje, ele custa apenas 2 disposição!";
        }
        else
        {
            dispositionText.text = "Isso vai custar " + (2 + dataHolder.forcaThisDay) + " de disposição.";
        }
//---------------------------------------------------------------------------------
        if(dataHolder.actions == 0)
        {
            goButton.SetActive(false);
            otherText.text = "Você está sem ações por hoje!";
        }
        else
        {
            if(dataHolder.disposicao < 2 + dataHolder.forcaThisDay)
            {
                goButton.SetActive(false);
                otherText.text = "Você está sem disposição para isso!";
            }
            else
            {
                if(dataHolder.lipidio == 0)
                {
                    goButton.SetActive(false);
                    otherText.text = "Você não tem Lipídio para isso!";
                }
                else
                {
                    if(dataHolder.mineral == 0)
                    {
                        goButton.SetActive(false);
                        otherText.text = "Você não tem Mineral para isso!";
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
