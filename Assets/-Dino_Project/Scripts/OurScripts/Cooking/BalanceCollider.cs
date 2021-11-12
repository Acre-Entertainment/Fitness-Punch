using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceCollider : MonoBehaviour
{
    CookingGameMaster cgm;
    public GameObject shineSprite;
    private bool isShining;
    public float xPosition, yPosition, zPosition;
    void Start()
    {
        cgm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<CookingGameMaster>();
        xPosition = gameObject.transform.position.x;
        yPosition = gameObject.transform.position.y;
        zPosition = gameObject.transform.position.z;
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
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            xPosition = touch.position.x;
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, 0, 0));
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, yPosition, zPosition);
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
