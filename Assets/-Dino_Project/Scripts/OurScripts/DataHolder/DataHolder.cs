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
    public float dayOfTheWeek;
    public bool dayTime;
    public int money;
    public int fats;
    public int carbohydrates;
    public int stepsTaken; //taken
    //etc

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

}
