using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimThingy : MonoBehaviour
{
    private bool inside, close, near, center;
    public float reverseRange, insideRange, closeRange, nearRange, centerRange;
    private float startingX;
    private Rigidbody2D rb;
    private CookingGameMaster cgm;
    public float velocity;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        cgm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<CookingGameMaster>();
        rb.velocity = new Vector2(velocity, 0);
        startingX = gameObject.transform.position.x;
    }
    void Update()
    {
        if(gameObject.transform.position.x >= reverseRange)
        {
            rb.velocity = new Vector2(-velocity, 0);
        }
        if(gameObject.transform.position.x <= - reverseRange)
        {
            rb.velocity = new Vector2(velocity, 0);
        }
    }
    public void hit()
    {
        //verifica onde o Aim esta e faz a ação apropriada
        if(gameObject.transform.position.x >= -centerRange && gameObject.transform.position.x <= centerRange)
        {
            cgm.points = cgm.points + cgm.pointsForCenterThrow;
        }
        else
        {
            if(gameObject.transform.position.x >= -nearRange && gameObject.transform.position.x <= nearRange)
            {
                cgm.points = cgm.points + cgm.pointsForNearThrow;
            }
            else
            {
                if(gameObject.transform.position.x >= -closeRange && gameObject.transform.position.x <= closeRange)
                {
                    cgm.points = cgm.points + cgm.pointsForCloseThrow;
                }
                else
                {
                    if(gameObject.transform.position.x >= -insideRange && gameObject.transform.position.x <= insideRange)
                    {
                        cgm.points = cgm.points + cgm.pointsForInsideThrow;
                    }
                    else
                    {

                    }
                }
            }
        }
    }
    public void setToStartingX()
    {
        gameObject.transform.position = new Vector3(startingX, gameObject.transform.position.y, 0);
    }
}
