using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOutDayCheck : MonoBehaviour
{
    private DataHolder dataHolder;
    public Text fadeInText;
    public GameObject fadeInObject;
    public Text fadeOutText;
    void Start()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        fadeInText.text = "Dia " + dataHolder.dayOfEverything;
        fadeOutText.text = "Dia " + dataHolder.dayOfEverything + 1;
        if(dataHolder.actions == 4)
        {
            fadeInObject.SetActive(true);
        }
    }
}
