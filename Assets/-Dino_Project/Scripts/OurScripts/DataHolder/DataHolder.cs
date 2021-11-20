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
    public bool primeiraVezAbrindoOJogo = true;
    public bool saiuDoApartamento;
    public bool saiuDaAcademia;
    public bool saiuDaLoja;
    public bool saiuDoGrocer;
    public int dayOfTheWeek;
    public int actions;
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
    public int[] selectedGrocerFood = new int[4];
    public int[] selectedCookingFood = new int[3];
    public int grocerThisDay;
    public int cookingThisDay;
    public int aerobicoThisDay;
    public int forcaThisDay;
    public int funThisDay;

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
        for(int i = 0; i < 10; i++)
        {
            for(int i2 = 0; i2 < 9; i2++)
            {
                if(inventorySlots[i2] == 0)
                {
                    inventorySlots[i2] = inventorySlots[i2 + 1];
                    inventorySlots[i2 + 1] = 0;
                }
            }
        }
    }

}
