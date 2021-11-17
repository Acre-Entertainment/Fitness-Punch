using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerToPosition : MonoBehaviour
{
    public GameObject ApartmentPosition;
    public GameObject GrocerPosition;
    public GameObject ShopPosition;
    public GameObject GymPosition;
    private DataHolder dataHolder;
    void Start()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        if(dataHolder.primeiraVezAbrindoOJogo == true || dataHolder.saiuDoApartamento == true)
        {
            gameObject.transform.position = ApartmentPosition.transform.position;
            dataHolder.saiuDoApartamento = false;
        }
        if(dataHolder.saiuDaLoja == true)
        {
            gameObject.transform.position = ShopPosition.transform.position;
            dataHolder.saiuDaLoja = false;
        }
        if(dataHolder.saiuDaAcademia == true)
        {
            gameObject.transform.position = GymPosition.transform.position;
            dataHolder.saiuDaAcademia = false;
        }
        if(dataHolder.saiuDoGrocer == true)
        {
            gameObject.transform.position = GrocerPosition.transform.position;
            dataHolder.saiuDoGrocer = false;
        }
    }
}
