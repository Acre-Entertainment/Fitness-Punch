using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfFirstTime : MonoBehaviour
{
    private DataHolder dataHolder;
    void Start()
    {
        if(dataHolder.primeiraVezAbrindoOJogo == false)
        {
            gameObject.SetActive(false);
        }
        else
        {
            dataHolder.primeiraVezAbrindoOJogo = false;
        }
    }
}
