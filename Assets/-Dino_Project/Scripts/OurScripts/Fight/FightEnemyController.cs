using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FightEnemyController : MonoBehaviour
{
    public PlayerFightStatus playerFightStatus;
    public FightingGameMaster fightingGameMaster;
    [SerializeField] private bool isRegularPunching;
    [SerializeField] private bool isUltraPunching;
    [SerializeField] private bool isSwiping;
    [SerializeField] private bool isBlocking;
    [SerializeField] private bool isDodging;
    [SerializeField] private bool isStaggered;
    [SerializeField] private float punch_TimeToDamage;
    [SerializeField] private float punch_TimeToActAgain;
    [SerializeField] private float block_DurationOfBlock;
    [SerializeField] private float dodge_TimeToBeEffective;
    [SerializeField] private float dodge_DurationOfDodge;
    [SerializeField] private float dodge_TimeToActAgain;
    [SerializeField] private float stagger_staggerDuration;
    [SerializeField] private float ai_IdleTime_VeryShort;
    [SerializeField] private float ai_IdleTime_Short;
    [SerializeField] private float ai_IdleTime_Long;
    public UnityEvent onPunchStart;
    public UnityEvent onPunchDamageTime;
    public UnityEvent onPunchEnd;
    public UnityEvent onPunchStartOther;
    public UnityEvent onPunchDamageTimeOther;
    public UnityEvent onPunchEndOther;
    public UnityEvent onSuperPunchStart;
    public UnityEvent onSuperPunchDamageTime;
    public UnityEvent onSuperPunchEnd;
    public UnityEvent onSwipeStart;
    public UnityEvent onSwipeDamageTime;
    public UnityEvent onSwipeEnd;
    public UnityEvent onBlockStart;
    public UnityEvent onBlockEnd;
    public UnityEvent onStaggerStart;
    public UnityEvent onStaggerEnd;
    private int randy;
    
    void Start()
    {
        StartCoroutine(WaitAtStart());
    }
    //ai--------------------------------------------------------------------
    private IEnumerator WaitAtStart()
    {
        yield return new WaitForSeconds(ai_IdleTime_Long);

        //RandomBehaviorSelect();
        StopCoroutine(WaitAtStart());
    }
    public void RandomBehaviorSelect()
    {
        randy = Random.Range(1, 16);
        switch(randy)
        {
            case 1:
                //StartCoroutine(ThreePunchCombo());
                break;
            case 2:
                //StartCoroutine(SinglePunch());
                break;
            case 3:
                //StartCoroutine(SinglePunch());
                break;
            case 4:
                //StartCoroutine(SinglePunch());
                break;
            case 5:
                //StartCoroutine(Blocking());
                break;
        }
    }
    //moves---------------------------------------------------------------
    private IEnumerator ThreePunchCombo()
    {
        onPunchStart.Invoke();
        isRegularPunching = true;
        yield return new WaitForSeconds(ai_IdleTime_Short);
        onPunchDamageTime.Invoke();
        enemyPunchConnects();
        yield return new WaitForSeconds(punch_TimeToActAgain);
        onPunchEnd.Invoke();
        isRegularPunching = false;

        yield return new WaitForSeconds(ai_IdleTime_VeryShort);

        onPunchStartOther.Invoke();
        isRegularPunching = true;
        yield return new WaitForSeconds(punch_TimeToDamage);
        onPunchDamageTimeOther.Invoke();
        enemyPunchConnects();
        yield return new WaitForSeconds(punch_TimeToActAgain);
        onPunchEndOther.Invoke();
        isRegularPunching = false;

        yield return new WaitForSeconds(ai_IdleTime_VeryShort);

        onPunchStart.Invoke();
        isRegularPunching = true;
        yield return new WaitForSeconds(punch_TimeToDamage);
        onPunchDamageTime.Invoke();
        enemyPunchConnects();
        yield return new WaitForSeconds(punch_TimeToActAgain);
        onPunchEnd.Invoke();
        isRegularPunching = false;

        yield return new WaitForSeconds(ai_IdleTime_Long);

        RandomBehaviorSelect();
        StopCoroutine(ThreePunchCombo());
    }
    //move results----------------------------------------------------------------
    private void enemyPunchConnects()
    {
        //
    }

}
