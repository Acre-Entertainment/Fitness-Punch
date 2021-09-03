using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouObjectsCatched : MonoBehaviour
//faz uma lista automatica com os nomes e quantidades de frutas pegas pelo jogador
{
    [HideInInspector] public string newFood;
    public List<string> foodListName;
    public List<int> foodListQuantity;
    [HideInInspector] public bool processNewFood;
    private bool addQuantity;
    private int addWhere;
    void Update()
    {
        if(processNewFood == true)
        {
            for (int i = 0; i < foodListName.Count; i++)
            {
                if(newFood == foodListName[i])
                {
                    addQuantity = true;
                    addWhere = i;
                }
            }
            if(addQuantity == true)
            {
                foodListQuantity[addWhere] = foodListQuantity[addWhere] + 1;
            }
            else
            {
                foodListName.Add(newFood);
                foodListQuantity.Add(1);
            }
            newFood = null;
            addQuantity = false;
            processNewFood = false;
        }
    }
}
