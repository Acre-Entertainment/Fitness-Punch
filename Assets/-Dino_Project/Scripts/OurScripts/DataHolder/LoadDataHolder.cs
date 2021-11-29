using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class LoadDataHolder : MonoBehaviour
{
    private DataHolder gameDataHolder;
    private DataHolderSavefile savedDataHolder;
    void Start()
    {
        string savePath = Application.persistentDataPath + "/FitnessPunch.fit";
        if(File.Exists(savePath))
        {
            gameDataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(savePath, FileMode.Open);
            savedDataHolder = binaryFormatter.Deserialize(fileStream) as DataHolderSavefile;
            transferSaveData();
            fileStream.Close();
        }
    }
    private void transferSaveData()
    {
        gameDataHolder.primeiraVezAbrindoOJogo = savedDataHolder.primeiraVezAbrindoOJogo;
            gameDataHolder.saiuDoApartamento = savedDataHolder.saiuDoApartamento;
            gameDataHolder.saiuDaAcademia = savedDataHolder.saiuDaAcademia;
            gameDataHolder.saiuDaLoja = savedDataHolder.saiuDaLoja;
            gameDataHolder.saiuDoGrocer = savedDataHolder.saiuDoGrocer;
            gameDataHolder.primeiraVezAbrindoOJogo = savedDataHolder.primeiraVezAbrindoOJogo;
            gameDataHolder.dayOfTheWeek = savedDataHolder.dayOfTheWeek;
            gameDataHolder.dayOfEverything = savedDataHolder.dayOfEverything;
            gameDataHolder.actions = savedDataHolder.actions;
            gameDataHolder.money = savedDataHolder.money;
            gameDataHolder.proteina = savedDataHolder.proteina;
            gameDataHolder.carboidrato = savedDataHolder.carboidrato;
            gameDataHolder.lipidio = savedDataHolder.lipidio;
            gameDataHolder.mineral = savedDataHolder.mineral;
            gameDataHolder.vitamina = savedDataHolder.vitamina;
            gameDataHolder.fibra = savedDataHolder.fibra;
            gameDataHolder.disposicao = savedDataHolder.disposicao;
            gameDataHolder.forca = savedDataHolder.forca;
            gameDataHolder.resistencia = savedDataHolder.resistencia;
            gameDataHolder.coins = savedDataHolder.coins;
            gameDataHolder.inventorySlots = savedDataHolder.inventorySlots;
            gameDataHolder.selectedGrocerFood = savedDataHolder.selectedGrocerFood;
            gameDataHolder.selectedCookingFood = savedDataHolder.selectedCookingFood;
            gameDataHolder.grocerThisDay = savedDataHolder.grocerThisDay;
            gameDataHolder.cookingThisDay = savedDataHolder.cookingThisDay;
            gameDataHolder.aerobicoThisDay = savedDataHolder.aerobicoThisDay;
            gameDataHolder.forcaThisDay = savedDataHolder.forcaThisDay;
            gameDataHolder.funThisDay = savedDataHolder.funThisDay;
            gameDataHolder.proteinaBefore = savedDataHolder.proteinaBefore;
            gameDataHolder.carboidratoBefore = savedDataHolder.carboidratoBefore;
            gameDataHolder.lipidioBefore = savedDataHolder.lipidioBefore;
            gameDataHolder.mineralBefore = savedDataHolder.mineralBefore;
            gameDataHolder.vitaminaBefore = savedDataHolder.vitaminaBefore;
            gameDataHolder.fibraBefore = savedDataHolder.fibraBefore;
            gameDataHolder.disposicaoBefore = savedDataHolder.disposicaoBefore;
            gameDataHolder.noExerciceBefore = savedDataHolder.noExerciceBefore;
            gameDataHolder.noAerobicBefore = savedDataHolder.noAerobicBefore;
            gameDataHolder.noStrenghBefore = savedDataHolder.noStrenghBefore;
            gameDataHolder.proteinaBonus = savedDataHolder.proteinaBonus;
            gameDataHolder.proteinaMalus = savedDataHolder.proteinaMalus;
            gameDataHolder.carboidratoBonus = savedDataHolder.carboidratoBonus;
            gameDataHolder.carboidratoMalus = savedDataHolder.carboidratoMalus;
            gameDataHolder.strenghBeforeFight = savedDataHolder.strenghBeforeFight;
            gameDataHolder.resistenciaBeforeFight = savedDataHolder.resistenciaBeforeFight;
            gameDataHolder.funHighScore = savedDataHolder.funHighScore;
    }
}
