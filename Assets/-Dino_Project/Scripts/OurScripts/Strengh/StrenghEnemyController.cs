using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StrenghEnemyController : MonoBehaviour
{
    public StrenghGameMaster sgm;
    public PlayerFightStatus pfs;
    [SerializeField] private bool isPunching;
    [SerializeField] private bool isBlocking;
    [SerializeField] private bool isStaggered;
    [SerializeField] private float punch_TimeFromStartToDamage;
    [SerializeField] private float punch_TimeFromDamageToEnd;
    [SerializeField] private float block_DurationOfBlock;
    [SerializeField] private float stagger_staggerDuration;
    [SerializeField] private float ai_IdleTime_VeryShort;
    [SerializeField] private float ai_IdleTime_Long;
    public UnityEvent onPunchStart;
    public UnityEvent onPunchDamageTime;
    public UnityEvent onPunchEnd;
    public UnityEvent onPunchStartOther;
    public UnityEvent onPunchDamageTimeOther;
    public UnityEvent onPunchEndOther;
    public UnityEvent onBlockStart;
    public UnityEvent onBlockEnd;
    public UnityEvent onStaggerStart;
    public UnityEvent onStaggerEnd;
    private int overrideStaggerCombo;
    private int randy;
    void Start()
    {
        StartCoroutine(WaitAtStart());
    }
    //Artifical Intellgicence-------------------------------------------------------------------
    private IEnumerator WaitAtStart()
    {
        yield return new WaitForSeconds(ai_IdleTime_Long);

        RandomBehaviorSelect();
        StopCoroutine(WaitAtStart());
    }
    public void RandomBehaviorSelect()
    {
        randy = Random.Range(1, 7);
        switch(randy)
        {
            case 1:
                StartCoroutine(ThreePunchCombo());
                break;
            case 2:
                StartCoroutine(SinglePunch());
                break;
            case 3:
                StartCoroutine(SinglePunch());
                break;
            case 4:
                StartCoroutine(SinglePunch());
                break;
            case 5:
                StartCoroutine(Blocking());
                break;
            case 6:
                StartCoroutine(Blocking());
                break;
        }
    }
    //Moves---------------------------------------------------------------------------------------
    private IEnumerator ThreePunchCombo()
    {
        onPunchStart.Invoke();
        isPunching = true;
        yield return new WaitForSeconds(punch_TimeFromStartToDamage);
        onPunchDamageTime.Invoke();
        enemyPunchConnects();
        yield return new WaitForSeconds(punch_TimeFromDamageToEnd);
        onPunchEnd.Invoke();
        isPunching = false;

        yield return new WaitForSeconds(ai_IdleTime_VeryShort);

        onPunchStartOther.Invoke();
        isPunching = true;
        yield return new WaitForSeconds(punch_TimeFromStartToDamage);
        onPunchDamageTimeOther.Invoke();
        enemyPunchConnects();
        yield return new WaitForSeconds(punch_TimeFromDamageToEnd);
        onPunchEndOther.Invoke();
        isPunching = false;

        yield return new WaitForSeconds(ai_IdleTime_VeryShort);

        onPunchStart.Invoke();
        isPunching = true;
        yield return new WaitForSeconds(punch_TimeFromStartToDamage);
        onPunchDamageTime.Invoke();
        enemyPunchConnects();
        yield return new WaitForSeconds(punch_TimeFromDamageToEnd);
        onPunchEnd.Invoke();
        isPunching = false;

        yield return new WaitForSeconds(ai_IdleTime_Long);

        RandomBehaviorSelect();
        StopCoroutine(ThreePunchCombo());
    }
    private IEnumerator SinglePunch()
    {
        onPunchStart.Invoke();
        isPunching = true;
        yield return new WaitForSeconds(punch_TimeFromStartToDamage);
        onPunchDamageTime.Invoke();
        enemyPunchConnects();
        yield return new WaitForSeconds(punch_TimeFromDamageToEnd);
        onPunchEnd.Invoke();
        isPunching = false;

        yield return new WaitForSeconds(ai_IdleTime_Long);

        RandomBehaviorSelect();
        StopCoroutine(SinglePunch());
    }
    private IEnumerator Blocking()
    {
        onBlockStart.Invoke();
        isBlocking = false;

        yield return new WaitForSeconds(block_DurationOfBlock);

        onBlockEnd.Invoke();
        isBlocking = false;

        yield return new WaitForSeconds(ai_IdleTime_Long);

        RandomBehaviorSelect();
        StopCoroutine(Blocking());
    } 
    //Reactions to punches------------------------------------------------------------------------
    public void playerPunchConnects()
    {
        if(isBlocking == false)
        {
            sgm.onEnemyNotBlockedAttack.Invoke();
            sgm.points = sgm.points + sgm.pointsForPunch;
            sgm.updatPointUI();
            //overrideStaggerCombo++;
            //if(overrideStaggerCombo >= 3)
            //{
            //    overrideStaggerCombo = 0;
            //    StopAllCoroutines();
            //    StartCoroutine(StaggerOverride());
            //}
            //else
            //{
            //    StopAllCoroutines();
            //    StartCoroutine(Stagger());
            //}
        }
        else
        {
            sgm.onEnemyBlockedAttack.Invoke();
            //put sound here, I guess
        }
    }
    private IEnumerator ReturnStaggerComboToZero()
    {
        yield return new WaitForSeconds(ai_IdleTime_Long);
        overrideStaggerCombo = 0;
        StopCoroutine(ReturnStaggerComboToZero());
    }
    private IEnumerator Stagger()
    {
        onStaggerStart.Invoke();
        isPunching = false;
        isBlocking = false;
        isStaggered = true;

        yield return new WaitForSeconds(stagger_staggerDuration);

        isStaggered = false;
        onStaggerEnd.Invoke();

        yield return new WaitForSeconds(ai_IdleTime_Long);

        RandomBehaviorSelect();
        StopCoroutine(Stagger());
    }
    private IEnumerator StaggerOverride()
    {
        onStaggerStart.Invoke();
        isPunching = false;
        isBlocking = false;
        isStaggered = true;

        yield return new WaitForSeconds(ai_IdleTime_VeryShort);

        onStaggerEnd.Invoke();
        isStaggered = false;
        onBlockStart.Invoke();
        isBlocking = true;

        yield return new WaitForSeconds(block_DurationOfBlock);

        onBlockEnd.Invoke();
        isBlocking = false;

        yield return new WaitForSeconds(ai_IdleTime_VeryShort);

        RandomBehaviorSelect();
        StopCoroutine(StaggerOverride());
    }
    private void enemyPunchConnects()
    {
        if(pfs.isBlocking == false)
        {
            sgm.onPlayerNotBlockedAttack.Invoke();
            sgm.points = sgm.points - sgm.pointsPenaltyForNotBlocking;
            sgm.updatPointUI();
            pfs.stagger();
        }
        else
        {
            sgm.onPlayerBlockedAttack.Invoke();
            sgm.points = sgm.points + sgm.pointsForBlock;
            sgm.updatPointUI();
        }
    }
}
