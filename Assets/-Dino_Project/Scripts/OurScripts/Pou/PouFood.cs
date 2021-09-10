using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouFood : MonoBehaviour
{
    private Rigidbody2D rb;
    private PouGameMaster PGM;
    [SerializeField] private int foodQuality;
    [SerializeField] private float fallSpeed;
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(0, -fallSpeed, 0);
        PGM = GameObject.FindWithTag("GameMaster").GetComponent<PouGameMaster>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            switch(foodQuality)
            {
                case 1:
                    PGM.lowQualityFoodCatched++;
                    break;
                case 2:
                    PGM.mediumQualityFoodCatched++;
                    break;
                case 3:
                    PGM.highQualityFoodCatched++;
                    break;
            }
        }
    }
}
