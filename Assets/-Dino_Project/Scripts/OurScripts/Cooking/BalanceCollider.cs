using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceCollider : MonoBehaviour
{
    CookingGameMaster cgm;
    public GameObject shineSprite;
    private bool isShining;
    void Start()
    {
        cgm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<CookingGameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cgm.isInContact == true)
        {
            if(isShining == false)
            {
                shineSprite.SetActive(true);
                isShining = true;
            }
        }
        else
        {
            if(isShining == true)
            {
                shineSprite.SetActive(false);
                isShining = false;
            }
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        cgm.isInContact = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        cgm.isInContact = false;
    }
}
