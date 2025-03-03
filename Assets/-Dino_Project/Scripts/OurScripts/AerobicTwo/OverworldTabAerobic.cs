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
            dispositionText.text = "Since it's your first time doing this exercise today, it only costs 2 disposition!";
        }
        else
        {
            dispositionText.text = "This will cost " + (2 + dataHolder.forcaThisDay) + " disposition.";
        }
//---------------------------------------------------------------------------------
        if(dataHolder.actions == 0)
        {
            goButton.SetActive(false);
            otherText.text = "You're out of moves for today!";
        }
        else
        {
            if(dataHolder.disposicao < 2 + dataHolder.forcaThisDay)
            {
                goButton.SetActive(false);
                otherText.text = "You don't have enough disposition for that!";
            }
            else
            {
                if(dataHolder.lipidio == 0)
                {
                    goButton.SetActive(false);
                    otherText.text = "You don't have enough Lipid for that!";
                }
                else
                {
                    if(dataHolder.mineral == 0)
                    {
                        goButton.SetActive(false);
                        otherText.text = "You don't have enough Mineral for that!";
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
