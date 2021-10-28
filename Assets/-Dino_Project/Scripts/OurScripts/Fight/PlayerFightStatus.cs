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
    UnityEvent onPunchDamageTime;
    [SerializeField] private float punch_TimeToActAgain;
    [SerializeField] private float block_DurationOfBlock;
    [SerializeField] private float block_TimeToActAgain;
    [SerializeField] private float dodge_TimeToBeEffective;
    [SerializeField] private float dodge_DurationOfDodge;
    [SerializeField] private float dodge_TimeToActAgain;
    [SerializeField] private float stagger_staggerDuration;

    //punch--------------------------------------------------------------------------
    public void Punch()
    {
        if(canAct == true)
        {
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
        canAct = true;
        isPunching =false;
        StopCoroutine(PunchRotine());
    }
    public void CancelPunch()
    {
        StopCoroutine(PunchRotine());
        isPunching = false;
    }
    //dodge--------------------------------------------------------------------------
    public void DodgeLeft()
    {
        if(canAct == true)
        {
            canAct = false;
            isDodging = true;
            StartCoroutine(DodgeLeftRotine());
        }
    }
    private IEnumerator DodgeLeftRotine()
    {
        yield return new WaitForSeconds(dodge_TimeToBeEffective);
        isLeft = true;
        yield return new WaitForSeconds(dodge_DurationOfDodge);
        isLeft = false;
        yield return new WaitForSeconds(dodge_TimeToActAgain);
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
            canAct = false;
            isDodging = true;
            StartCoroutine(DodgeRightRotine());
        }
    }
    private IEnumerator DodgeRightRotine()
    {
        yield return new WaitForSeconds(dodge_TimeToBeEffective);
        isRight = true;
        yield return new WaitForSeconds(dodge_DurationOfDodge);
        isRight = false;
        yield return new WaitForSeconds(dodge_TimeToActAgain);
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
            canAct = false;
            isDodging = true;
            StartCoroutine(DodgeDownRotine());
        }
    }
    private IEnumerator DodgeDownRotine()
    {
        yield return new WaitForSeconds(dodge_TimeToBeEffective);
        isDown = true;
        yield return new WaitForSeconds(dodge_DurationOfDodge);
        isDown = false;
        yield return new WaitForSeconds(dodge_TimeToActAgain);
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
}
