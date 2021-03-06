using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class DataHolder : MonoBehaviour
//Guarda todas as informações do jogo
//não coloque tag no objeto desse script
{
    //Coloque as informações que voce quer salvar abaixo como um valor publico.
    public bool primeiraVezAbrindoOJogo;
    public bool saiuDoApartamento;
    public bool saiuDaAcademia;
    public bool saiuDaLoja;
    public bool saiuDoGrocer;
    public int dayOfTheWeek;
    public int dayOfEverything;
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
    public int coins;

    public int[] inventorySlots = new int[10];
    public bool[] coinActivation = new bool[25];

    //Grocer Minigame
    public int[] selectedGrocerFood = new int[4];
    public int[] selectedCookingFood = new int[3];

    public int grocerThisDay;
    public int cookingThisDay;
    public int aerobicoThisDay;
    public int forcaThisDay;
    public int funThisDay;
    [HideInInspector] public int proteinaBefore;
    [HideInInspector] public int carboidratoBefore;
    [HideInInspector] public int lipidioBefore;
    [HideInInspector] public int mineralBefore;
    [HideInInspector] public int vitaminaBefore;
    [HideInInspector] public int fibraBefore;
    [HideInInspector] public int disposicaoBefore;
    [HideInInspector] public bool noExerciceBefore;
    [HideInInspector] public bool noAerobicBefore;
    [HideInInspector] public bool noStrenghBefore;
    [HideInInspector] public bool proteinaBonus;
    [HideInInspector] public bool proteinaMalus;
    [HideInInspector] public bool carboidratoBonus;
    [HideInInspector] public bool carboidratoMalus;
    [HideInInspector] public int strenghBeforeFight;
    [HideInInspector] public int resistenciaBeforeFight;
    [HideInInspector] public int funHighScore;
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
