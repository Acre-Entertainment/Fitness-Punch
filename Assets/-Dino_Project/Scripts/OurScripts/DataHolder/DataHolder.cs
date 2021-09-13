using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataHolder : MonoBehaviour
//Guarda todas as informações do jogo
//não coloque tag no objeto desse script
{
    private GameObject _dt;
    //Coloque as informações que voce quer salvar abaixo como um valor publico.
    public int dayOfTheMonth;
    public int dayOfTheWeek;
    public int year;
    public int actions;
    public bool dayTime;

    public int stepsTaken;

    public int money;

    public int proteina;
    public int carboidrato;
    public int lipidio;
    public int mineral;
    public int vitamina;
    public int fibra;

    public int disposicao;

    public int forca;
    public int resistencia;

    public int[] inventorySlots = new int[10];

    //Grocer Minigame
    [HideInInspector] public int[] selectedGrocerFood = new int[4];

    void Awake() //Garante que ha apenas um DataHolder por cena e que ele não e destroido ao mudar de cena.
    {
        _dt = GameObject.FindWithTag("DataHolder");
        if(_dt == null)
        {
            transform.gameObject.tag = "DataHolder";
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        };
    }

    public void organizeInventory()
    {
        Array.Reverse(inventorySlots);
    }

}
