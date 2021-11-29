using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisposicaoUI : MonoBehaviour
{
    public GameObject disposicao1;
    public GameObject disposicao2;
    public GameObject disposicao3;
    public GameObject disposicao4;
    private DataHolder dataHolder;
    void Start()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        if(dataHolder.disposicao < 4){disposicao4.SetActive(false);}
        if(dataHolder.disposicao < 3){disposicao3.SetActive(false);}
        if(dataHolder.disposicao < 2){disposicao2.SetActive(false);}
        if(dataHolder.disposicao < 1){disposicao1.SetActive(false);}
    }
}
