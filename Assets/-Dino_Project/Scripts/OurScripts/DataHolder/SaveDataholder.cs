using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveDataholder : MonoBehaviour
{
    private DataHolder dataHolder;
    private DataHolderSavefile dataHolderSavefile;
    void Start()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        transferData();
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string savePath = Application.persistentDataPath + "/FitnessPunch.fit";
        FileStream fileStream = new FileStream(savePath, FileMode.Create);
        binaryFormatter.Serialize(fileStream, dataHolderSavefile);
        fileStream.Close();
    }
    private void transferData()
    {
            dataHolderSavefile.primeiraVezAbrindoOJogo = dataHolder.primeiraVezAbrindoOJogo;
            dataHolderSavefile.saiuDoApartamento = dataHolder.saiuDoApartamento;
            dataHolderSavefile.saiuDaAcademia = dataHolder.saiuDaAcademia;
            dataHolderSavefile.saiuDaLoja = dataHolder.saiuDaLoja;
            dataHolderSavefile.saiuDoGrocer = dataHolder.saiuDoGrocer;
            dataHolderSavefile.primeiraVezAbrindoOJogo = dataHolder.primeiraVezAbrindoOJogo;
            dataHolderSavefile.dayOfTheWeek = dataHolder.dayOfTheWeek;
            dataHolderSavefile.dayOfEverything = dataHolder.dayOfEverything;
            dataHolderSavefile.actions = dataHolder.actions;
            dataHolderSavefile.money = dataHolder.money;
            dataHolderSavefile.proteina = dataHolder.proteina;
            dataHolderSavefile.carboidrato = dataHolder.carboidrato;
            dataHolderSavefile.lipidio = dataHolder.lipidio;
            dataHolderSavefile.mineral = dataHolder.mineral;
            dataHolderSavefile.vitamina = dataHolder.vitamina;
            dataHolderSavefile.fibra = dataHolder.fibra;
            dataHolderSavefile.disposicao = dataHolder.disposicao;
            dataHolderSavefile.forca = dataHolder.forca;
            dataHolderSavefile.resistencia = dataHolder.resistencia;
            dataHolderSavefile.inventorySlots = dataHolder.inventorySlots;
            dataHolderSavefile.selectedGrocerFood = dataHolder.selectedGrocerFood;
            dataHolderSavefile.selectedCookingFood = dataHolder.selectedCookingFood;
            dataHolderSavefile.grocerThisDay = dataHolder.grocerThisDay;
            dataHolderSavefile.cookingThisDay = dataHolder.cookingThisDay;
            dataHolderSavefile.aerobicoThisDay = dataHolder.aerobicoThisDay;
            dataHolderSavefile.forcaThisDay = dataHolder.forcaThisDay;
            dataHolderSavefile.funThisDay = dataHolder.funThisDay;
            dataHolderSavefile.proteinaBefore = dataHolder.proteinaBefore;
            dataHolderSavefile.carboidratoBefore = dataHolder.carboidratoBefore;
            dataHolderSavefile.lipidioBefore = dataHolder.lipidioBefore;
            dataHolderSavefile.mineralBefore = dataHolder.mineralBefore;
            dataHolderSavefile.vitaminaBefore = dataHolder.vitaminaBefore;
            dataHolderSavefile.fibraBefore = dataHolder.fibraBefore;
            dataHolderSavefile.disposicaoBefore = dataHolder.disposicaoBefore;
            dataHolderSavefile.noExerciceBefore = dataHolder.noExerciceBefore;
            dataHolderSavefile.noAerobicBefore = dataHolder.noAerobicBefore;
            dataHolderSavefile.noStrenghBefore = dataHolder.noStrenghBefore;
            dataHolderSavefile.proteinaBonus = dataHolder.proteinaBonus;
            dataHolderSavefile.proteinaMalus = dataHolder.proteinaMalus;
            dataHolderSavefile.carboidratoBonus = dataHolder.carboidratoBonus;
            dataHolderSavefile.carboidratoMalus = dataHolder.carboidratoMalus;
            dataHolderSavefile.strenghBeforeFight = dataHolder.strenghBeforeFight;
            dataHolderSavefile.resistenciaBeforeFight = dataHolder.resistenciaBeforeFight;
            dataHolderSavefile.funHighScore = dataHolder.funHighScore;
    }
}
