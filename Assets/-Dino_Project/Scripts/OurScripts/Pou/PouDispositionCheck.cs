using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouDispositionCheck : MonoBehaviour
{
    [HideInInspector] public DataHolder DT;
    [SerializeField] private GameObject goButton;
    [SerializeField] private GameObject noText;
    [SerializeField] private int neededDisposition;
    void Start()
    {
        DT = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
    }
    public void doCheckAndAct()
    {
        if(DT.disposicao >= neededDisposition)
        {
            goButton.SetActive(true);
            noText.SetActive(false);
        }
        else
        {
            goButton.SetActive(false);
            noText.SetActive(true);
        }
    }
}
