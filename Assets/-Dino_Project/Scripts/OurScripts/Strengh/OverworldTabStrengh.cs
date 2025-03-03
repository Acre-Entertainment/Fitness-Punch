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
            dispositionText.text = "Since it's your first time doing this exercise today, it only costs 1 disposition!";
        }
        else
        {
            dispositionText.text = "This will cost " + (1 + dataHolder.forcaThisDay) + " disposition.";
        }
//---------------------------------------------------------------------------------
        if(dataHolder.actions == 0)
        {
            goButton.SetActive(false);
            otherText.text = "You're out of moves for today!";
        }
        else
        {
            if(dataHolder.disposicao < 1 + dataHolder.forcaThisDay)
            {
                goButton.SetActive(false);
                otherText.text = "You don't have enough disposition for that!";
            }
            else
            {
                if(dataHolder.vitamina == 0)
                {
                    goButton.SetActive(false);
                    otherText.text = "You don't have enough Vitamin for that!";
                }
                else
                {
                    if(dataHolder.vitamina == 0)
                    {
                        goButton.SetActive(false);
                        otherText.text = "You don't have enough Fiber for that!";
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
