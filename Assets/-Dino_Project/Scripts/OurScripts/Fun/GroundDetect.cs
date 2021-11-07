using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetect : MonoBehaviour
{
    private CharacterJump pg;

    void Start()
    {
        pg = GameObject.FindGameObjectWithTag("PlayerFun").GetComponent<CharacterJump>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GroundFun")
        {

            pg.canJump = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GroundFun")
        {
            pg.canJump = false;
        }
    }

}

