using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTuToriel : MonoBehaviour
{
    private DataHolder dataHolder;
    public GameObject tutorial;
    public GameObject codex;
    public GameObject game;
    void Start()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        if(dataHolder.primeiraVezAbrindoOJogo == true)
        {
            tutorial.SetActive(false);
            codex.SetActive(false);
            game.SetActive(true);
            dataHolder.primeiraVezAbrindoOJogo = false;
        }
    }

}
