using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightFadeOut : MonoBehaviour
{
    public Text fadeOutText;
    private DataHolder dataHolder;
    void Start()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        fadeOutText.text = "Dia " + dataHolder.dayOfEverything + 1;
    }
}
