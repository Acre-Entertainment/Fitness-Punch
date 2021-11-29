using System.Collections;

using UnityEngine;

[System.Serializable]
public class DataHolderSavefile
{
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

    public int[] inventorySlots;

    //Grocer Minigame
    public int[] selectedGrocerFood;
    public int[] selectedCookingFood;

    public int grocerThisDay;
    public int cookingThisDay;
    public int aerobicoThisDay;
    public int forcaThisDay;
    public int funThisDay;
    public int proteinaBefore;
    public int carboidratoBefore;
    public int lipidioBefore;
    public int mineralBefore;
    public int vitaminaBefore;
    public int fibraBefore;
    public int disposicaoBefore;
    public bool noExerciceBefore;
    public bool noAerobicBefore;
    public bool noStrenghBefore;
    public bool proteinaBonus;
    public bool proteinaMalus;
    public bool carboidratoBonus;
    public bool carboidratoMalus;
    public int strenghBeforeFight;
    public int resistenciaBeforeFight;
    public int funHighScore;
}
