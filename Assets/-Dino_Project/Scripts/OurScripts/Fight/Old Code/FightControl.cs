using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightControl : MonoBehaviour
{
    [SerializeField] private bool canDodge = true;
    [SerializeField] private bool canPunch = true;
    [SerializeField] private bool canBlock = true;
    private bool canAct = true;
    public GameObject punchCollider;
    [SerializeField] private float punchColliderSpeed;
    [SerializeField] private float punchColliderTime;
    private bool isBlocking;
    [SerializeField] private float blockingTime;
    private float startingX, startingY;

    [SerializeField] private float lateralDodgeSpeed;
    [SerializeField] private float lateralDodgeTimeToStop;
    [SerializeField] private float lateralDodgeTimeToReturn;
    [SerializeField] private float downwardsDodgeSpeed;
    [SerializeField] private float downwardsDodgeTimeToStop;
    [SerializeField] private float downwardsDodgeTimeToReturn;
    void Start()
    {
        startingX = gameObject.transform.position.x;
        startingY = gameObject.transform.position.y;
    }

    //soco-------------------------------------------------------------
    public void punch() //botao de socar
    {
        if(canAct == true && canPunch == true)
        {
            punchCollider.GetComponent<Rigidbody2D>().velocity = new Vector2(0, punchColliderSpeed);
            canAct = false;
            StartCoroutine(returnPunchCollider());
        }
    }
    private IEnumerator returnPunchCollider() //retorna o colider do soco depois de um tempo e faz poder agir de novo
    {
        yield return new WaitForSeconds(punchColliderTime);
        punchCollider.transform.localPosition = new Vector3(0, 0, 0);
        punchCollider.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        canAct = true;
        StopCoroutine(returnPunchCollider());
    }
    private void cancelPunch() //chamado quando o soco é intenrompido
    {
        StopCoroutine(returnPunchCollider());
        punchCollider.transform.localPosition = new Vector3(0, 0, 0);
        punchCollider.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        canAct = true;
    }
    //bloquear attaques----------------------------------------------------------------
    public void block() //funcao de bloquear
    {
        if(canAct == true && canBlock == true)
        {
            isBlocking = true;
            canAct = false;
            StartCoroutine(lowerBlock());
        }
    }
    private IEnumerator lowerBlock()
    {
        yield return new WaitForSeconds(blockingTime);
        canAct = true;
        isBlocking = false;
        StartCoroutine(lowerBlock());
    }
    private void cancelBlock()
    {
        StopCoroutine(lowerBlock());
        isBlocking = false;
        canAct = true;
    }
    //esquivar para a esquerda---------------------------------------------------------------------
    public void dodgeLeft()
    {
        if(canAct == true && canDodge == true)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-lateralDodgeSpeed, 0);
            canAct = false;
            StartCoroutine(dodgeLeftRotine());
        }
    }
    private IEnumerator dodgeLeftRotine()
    {
        yield return new WaitForSeconds(lateralDodgeTimeToStop);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(lateralDodgeTimeToReturn);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(lateralDodgeSpeed, 0);
        yield return new WaitForSeconds(lateralDodgeTimeToStop);
        canAct = true;
        gameObject.transform.position = new Vector3(startingX, startingY, 0);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        StopCoroutine(dodgeLeftRotine());
    }
    private void cancelLeftDodge()
    {
        gameObject.transform.position = new Vector3(startingX, startingY, 0);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        canAct = true;
        StopCoroutine(dodgeLeftRotine());
    }
    //esquivar para a direita----------------------------------------------------------------------------------
    public void dodgeRight()
    {
        if(canAct == true && canDodge == true)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(lateralDodgeSpeed, 0);
            canAct = false;
            StartCoroutine(dodgeRightRotine());
        }
    }
    private IEnumerator dodgeRightRotine()
    {
        yield return new WaitForSeconds(lateralDodgeTimeToStop);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(lateralDodgeTimeToReturn);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-lateralDodgeSpeed, 0);
        yield return new WaitForSeconds(lateralDodgeTimeToStop);
        canAct = true;
        gameObject.transform.position = new Vector3(startingX, startingY, 0);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        StopCoroutine(dodgeRightRotine());
    }
    private void cancelRightDodge()
    {
        gameObject.transform.position = new Vector3(startingX, startingY, 0);
        canAct = true;
        StopCoroutine(dodgeRightRotine());
    }
    //esquivar para baixo
    public void dodgeDown()
    {
        if(canAct == true && canDodge == true)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -downwardsDodgeSpeed);
            canAct = false;
            StartCoroutine(dodgeDownRotine());
        }
    }
    private IEnumerator dodgeDownRotine()
    {
        yield return new WaitForSeconds(downwardsDodgeTimeToStop);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(downwardsDodgeTimeToReturn);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, downwardsDodgeSpeed);
        yield return new WaitForSeconds(downwardsDodgeTimeToStop);
        canAct = true;
        gameObject.transform.position = new Vector3(startingX, startingY, 0);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        StopCoroutine(dodgeDownRotine());
    }
    private void cancelDownDodge()
    {
        gameObject.transform.position = new Vector3(startingX, startingY, 0);
        StopCoroutine(dodgeDownRotine());
        canAct = true;
    }
}
