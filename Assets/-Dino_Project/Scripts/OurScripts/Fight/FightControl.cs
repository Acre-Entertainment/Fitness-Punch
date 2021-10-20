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
    [SerializeField] private float punchNoReactionTime;
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

    //soco
    public void punch() //botao de socar
    {
        if(canAct == true && canPunch == true)
        {
            punchCollider.GetComponent<Rigidbody2D>().velocity = new Vector2(0, punchColliderSpeed);
            canAct = false;
            returnPunchCollider();
        }
    }
    private IEnumerator returnPunchCollider() //retorna o colider do soco depois de um tempo e faz poder agir de novo
    {
        yield return new WaitForSeconds(punchColliderTime);
        punchCollider.transform.localPosition = new Vector3(0, 0, 0);
        canAct = true;
    }
    private void cancelPunch() //chamado quando o soco é intenrompido
    {
        StopCoroutine(returnPunchCollider());
        punchCollider.transform.localPosition = new Vector3(0, 0, 0);
    }
    //bloquear attaques
    public void block() //funcao de bloquear
    {
        if(canAct == true && canBlock == true)
        {
            isBlocking = true;
            canAct = false;
        }
    }
    private IEnumerator lowerBlock() //chamado guando o block acaba
    {
        yield return new WaitForSeconds(blockingTime);
        canAct = true;
        isBlocking = false;
    }
    private void cancelBlock()
    {
        StopCoroutine(lowerBlock());
        isBlocking = false;
    }
    //esquivar para a esquerda
    public void dodgeLeft()
    {
        if(canAct == true && canDodge == true)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-lateralDodgeSpeed, 0);
            canAct = false;
            stopAtRightDodgePosition();
        }
    }
    private IEnumerator stopAtLeftDodgePosition()
    {
        yield return new WaitForSeconds(lateralDodgeTimeToStop);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        returnToNormalPositionAfterLeftDodge();
    }
    private IEnumerator returnToNormalPositionAfterLeftDodge()
    {
        yield return new WaitForSeconds(lateralDodgeTimeToReturn);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(lateralDodgeSpeed, 0);
        stayAtNormalPositionAfterLeftDodge();
    }
    private IEnumerator stayAtNormalPositionAfterLeftDodge()
    {
        yield return new WaitForSeconds(lateralDodgeTimeToStop);
        canAct = true;
        gameObject.transform.position = new Vector3(startingX, startingY, 0);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
    private void cancelLeftDodge()
    {
        gameObject.transform.position = new Vector3(startingX, startingY, 0);
        StopCoroutine(stopAtLeftDodgePosition());
        StopCoroutine(returnToNormalPositionAfterLeftDodge());
        StopCoroutine(stayAtNormalPositionAfterLeftDodge());
    }
    //esquivar para a direita
    public void dodgeRight()
    {
        if(canAct == true && canDodge == true)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(lateralDodgeSpeed, 0);
            canAct = false;
            stopAtRightDodgePosition();
        }
    }
    private IEnumerator stopAtRightDodgePosition()
    {
        yield return new WaitForSeconds(lateralDodgeTimeToStop);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        returnToNormalPositionAfterRightDodge();
    }
    private IEnumerator returnToNormalPositionAfterRightDodge()
    {
        yield return new WaitForSeconds(lateralDodgeTimeToReturn);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-lateralDodgeSpeed, 0);
        stayAtNormalPositionAfterRightDodge();
    }
    private IEnumerator stayAtNormalPositionAfterRightDodge()
    {
        yield return new WaitForSeconds(lateralDodgeTimeToStop);
        canAct = true;
        gameObject.transform.position = new Vector3(startingX, startingY, 0);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
    private void cancelRightDodge()
    {
        gameObject.transform.position = new Vector3(startingX, startingY, 0);
        StopCoroutine(stopAtRightDodgePosition());
        StopCoroutine(returnToNormalPositionAfterRightDodge());
        StopCoroutine(stayAtNormalPositionAfterRightDodge());
    }
    //esquivar para baixo
    public void dodgeDown()
    {
        if(canAct == true && canDodge == true)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -downwardsDodgeSpeed);
            canAct = false;
            stopAtDownDodgePosition();
        }
    }
    private IEnumerator stopAtDownDodgePosition()
    {
        yield return new WaitForSeconds(downwardsDodgeTimeToStop);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        returnToNormalPositionAfterDownDodge();
    }
    private IEnumerator returnToNormalPositionAfterDownDodge()
    {
        yield return new WaitForSeconds(downwardsDodgeTimeToReturn);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, downwardsDodgeSpeed);

    }
    private IEnumerator stayAtNormalPositionAfterDownDodge()
    {
        yield return new WaitForSeconds(downwardsDodgeTimeToStop);
        canAct = true;
        gameObject.transform.position = new Vector3(startingX, startingY, 0);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
    private void cancelDownDodge()
    {
        gameObject.transform.position = new Vector3(startingX, startingY, 0);
        StopCoroutine(stopAtDownDodgePosition());
        StopCoroutine(returnToNormalPositionAfterDownDodge());
        StopCoroutine(stayAtNormalPositionAfterDownDodge());
    }
}
