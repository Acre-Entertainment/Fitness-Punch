using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFood : MonoBehaviour
{
    //É aplicado a comida que cai. Quando enconsta em um jogador esse objeto é destroido e a lista de objetos pegos no ObjectsCatched é expandida
    public string foodName;
    public float fallSpeed;
    private Rigidbody2D rb;
    private PouObjectsCatched oc;
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(0, -fallSpeed, 0);
        oc = GameObject.FindWithTag("PouFoodCatched").GetComponent<PouObjectsCatched>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            oc.newFood = foodName;
            oc.processNewFood = true;
            Destroy(gameObject);
        }
    }
}
