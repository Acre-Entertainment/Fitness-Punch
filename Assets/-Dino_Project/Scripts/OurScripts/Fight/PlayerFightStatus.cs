using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerFightStatus : MonoBehaviour
{
    [SerializeField] private bool canAct = true;
    [SerializeField] private bool isPunching;
    [SerializeField] private bool isBlocking;
    [SerializeField] private bool isDodging;
    [SerializeField] private bool isRight;
    [SerializeField] private bool isLeft;
    [SerializeField] private bool isDown;
    [SerializeField] private bool isStaggered;
    [SerializeField] private float punch_TimeToDamage;
    [SerializeField] private float punch_TimeToActAgain;
    [SerializeField] private float block_DurationOfBlock;
    [SerializeField] private float block_TimeToActAgain;
    [SerializeField] private float dodge_TimeToBeEffective;
    [SerializeField] private float dodge_DurationOfDodge;
    [SerializeField] private float dodge_TimeToActAgain;
    [SerializeField] private float stagger_staggerDuration;
    public UnityEvent onPunchStart;
    public UnityEvent onPunchDamageTime;
    public UnityEvent onPunchEnd;
    public UnityEvent onBlockStart;
    public UnityEvent onBlockLowerGuard;
    public UnityEvent onBlockEnd;
    public UnityEvent onLeftDodgeStart;
    public UnityEvent onLeftDodgeFull;
    public UnityEvent onLeftDodgeReturn;
    public UnityEvent onLeftDodgeEnd;
    public UnityEvent onRightDodgeStart;
    public UnityEvent onRightDodgeFull;
    public UnityEvent onRightDodgeReturn;
    public UnityEvent onRightDodgeEnd;
    public UnityEvent onDownDodgeStart;
    public UnityEvent onDownDodgeFull;
    public UnityEvent onDownDodgeReturn;
    public UnityEvent onDownDodgeEnd;
    public UnityEvent onStaggerStart;
    public UnityEvent onStaggerEnd;


    //punch--------------------------------------------------------------------------
    public void Punch()
    {
        if(canAct == true)
        {
            onPunchStart.Invoke();
            canAct = false;
            isPunching = true;
            StartCoroutine(PunchRotine());
        }
    }
    private IEnumerator PunchRotine()
    {
        yield return new WaitForSeconds(punch_TimeToDamage);
        onPunchDamageTime.Invoke();
        yield return new WaitForSeconds(punch_TimeToActAgain);
        onPunchEnd.Invoke();
        canAct = true;
        isPunching =false;
        StopCoroutine(PunchRotine());
    }
    public void CancelPunch()
    {
        StopCoroutine(PunchRotine());
        isPunching = false;
    }
    //block-------------------------------------------------------------------------
    public void Block()
    {
        if(canAct == true)
        {
            onBlockStart.Invoke();
            isBlocking = true;
            canAct = false;
            StartCoroutine(BlockRotine());
        }
    }
    private IEnumerator BlockRotine()
    {
        yield return new WaitForSeconds(block_DurationOfBlock);
        onBlockLowerGuard.Invoke();
        isBlocking = false;
        yield return new WaitForSeconds(block_TimeToActAgain);
        onBlockEnd.Invoke();
        canAct = true;
        StopCoroutine(BlockRotine());
    }
    public void cancelBlock()
    {
        isBlocking = false;
        StopCoroutine(BlockRotine());
    }
    //dodge--------------------------------------------------------------------------
    public void DodgeLeft()
    {
        if(canAct == true)
        {
            onLeftDodgeStart.Invoke();
            canAct = false;
            isDodging = true;
            StartCoroutine(DodgeLeftRotine());
        }
    }
    private IEnumerator DodgeLeftRotine()
    {
        yield return new WaitForSeconds(dodge_TimeToBeEffective);
        onLeftDodgeFull.Invoke();
        isLeft = true;
        yield return new WaitForSeconds(dodge_DurationOfDodge);
        onLeftDodgeReturn.Invoke();
        isLeft = false;
        yield return new WaitForSeconds(dodge_TimeToActAgain);
        onLeftDodgeEnd.Invoke();
        canAct = true;
        isDodging = false;
        StopCoroutine(DodgeLeftRotine());
    }
    public void cancelLeftDodge()
    {
        StopCoroutine(DodgeLeftRotine());
        isDodging = false;
        isLeft = false;
    }
    public void DodgeRight()
    {
        if(canAct == true)
        {
            onRightDodgeStart.Invoke();
            canAct = false;
            isDodging = true;
            StartCoroutine(DodgeRightRotine());
        }
    }
    private IEnumerator DodgeRightRotine()
    {
        yield return new WaitForSeconds(dodge_TimeToBeEffective);
        onRightDodgeFull.Invoke();
        isRight = true;
        yield return new WaitForSeconds(dodge_DurationOfDodge);
        onRightDodgeReturn.Invoke();
        isRight = false;
        yield return new WaitForSeconds(dodge_TimeToActAgain);
        onRightDodgeEnd.Invoke();
        canAct = true;
        isDodging = false;
        StopCoroutine(DodgeRightRotine());
    }
    public void cancelRightDodge()
    {
        StopCoroutine(DodgeRightRotine());
        isDodging = false;
        isRight = false;
    }
    public void DodgeDown()
    {
        if(canAct == true)
        {
            onDownDodgeStart.Invoke();
            canAct = false;
            isDodging = true;
            StartCoroutine(DodgeDownRotine());
        }
    }
    private IEnumerator DodgeDownRotine()
    {
        yield return new WaitForSeconds(dodge_TimeToBeEffective);
        onDownDodgeFull.Invoke();
        isDown = true;
        yield return new WaitForSeconds(dodge_DurationOfDodge);
        onDownDodgeReturn.Invoke();
        isDown = false;
        yield return new WaitForSeconds(dodge_TimeToActAgain);
        onDownDodgeEnd.Invoke();
        canAct = true;
        isDodging = false;
        StopCoroutine(DodgeDownRotine());
    }
    public void cancelDownDodge()
    {
        StopCoroutine(DodgeDownRotine());
        isDodging = false;
        isDown = false;
    }
    //stagger-------------------------------------------------------------------------------
    public void stagger()
    {
        StopCoroutine(staggerRotine());
        onStaggerStart.Invoke();
        CancelPunch();
        cancelBlock();
        cancelDownDodge();
        cancelLeftDodge();
        cancelRightDodge();
        canAct = false;
        isStaggered = true;
        StartCoroutine(staggerRotine());
    }
    private IEnumerator staggerRotine()
    {
        yield return new WaitForSeconds(stagger_staggerDuration);
        onStaggerEnd.Invoke();
        canAct = true;
        isStaggered = false;
        StopCoroutine(staggerRotine());
    }
}
