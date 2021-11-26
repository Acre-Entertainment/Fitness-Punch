using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_Animation : MonoBehaviour
{
    public GameObject enable;
    public GameObject disable;


    public void loadMenu()
    {
        enable.SetActive(true);
    }

    public void exitMenu()
    {
        disable.SetActive(false);
    }

    public void button_touch()
    {
        GetComponent<Animation>().Play("Button_click");
    }

    public void button_play()
    {
        GetComponent<Animation>().Play("Play_click");
    }

    public void exitTouch()
    {
        GetComponent<Animation>().Play("Exit_click");
    }

}
