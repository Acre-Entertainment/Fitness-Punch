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
    [SerializeField] private bool isSidePunching;
    [SerializeField] private bool isBlocking;
    [SerializeField] private bool isDodging;
    [SerializeField] private bool isStaggered;
    [SerializeField] private float punch_TimeFromStartToDamage;
    [SerializeField] private float punch_TimeFromDamageToEnd;
    [SerializeField] private float superPunch_TimeFromStartToDamage;
    [SerializeField] private float superPunch_TimeFromDamageToEnd;
    [SerializeField] private float swipe_TimeFromStartToDamage;
    [SerializeField] private float swipe_TimeFromDamageToEnd;
    [SerializeField] private float sidePunch_TimeFromStartToDoding;
    [SerializeField] private float sidePunch_TimeFromDodginToDamage;
    [SerializeField] private float sidePunch_TimeFromDamageToEnd;
    [SerializeField] private float block_DurationOfBlock;
    [SerializeField] private float stagger_staggerDuration;
    [SerializeField] private float ai_IdleTime_VeryShort; //usado quando o AI vai executar varios movemntos muitos rapidos, tipo o tempo entre socos de um combo
    [SerializeField] private float ai_IdleTime_Long; //usado quando o AI fica idle entre movimentos
    [SerializeField] private float special_SuperPunchWindupTime;
    [SerializeField] private float special_SidePunchWindupTime;
    [SerializeField] private float special_SwipeWindupTime;
    private int overrideStaggerCombo;
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
    public UnityEvent onLeftDodgeRightPunchStart;
    public UnityEvent onLeftDodgeRightPunchWindup;
    public UnityEvent onLeftDodgeRightPunchDamageTime;
    public UnityEvent onLeftDodgeRightPunchEnd;
    public UnityEvent onRightDodgeLeftPunchStart;
    public UnityEvent onRightDodgeLeftPunchWindup;
    public UnityEvent onRightDodgeLeftPunchDamageTime;
    public UnityEvent onRightDodgeLeftPunchEnd;
    public UnityEvent onBlockStart;
    public UnityEvent onBlockEnd;
    public UnityEvent onStaggerStart;
    public UnityEvent onStaggerEnd;
    public UnityEvent onEnemyKnockout;
    private int randy;
    
    void Start()
    {
        StartCoroutine(WaitAtStart());
    }
    //ai------------------------------------------------------------------------------------------------
    private IEnumerator WaitAtStart()
    {
        yield return new WaitForSeconds(ai_IdleTime_Long);

        RandomBehaviorSelect();
        StopCoroutine(WaitAtStart());
    }
    public void RandomBehaviorSelect()
    {
        if(fightingGameMaster.FightIsOver == true)
        {
            return;
            //acaba o AI do enemigo quando acaba a luta
        }
        randy = Random.Range(1, 13);
        switch(randy)
        {
            case 1:
                StartCoroutine(ThreePunchCombo());
                break;
            case 2:
                StartCoroutine(SingleRegularPunch());
                break;
            case 3:
                StartCoroutine(SingleRegularPunch());
                break;
            case 4:
                StartCoroutine(SingleRegularPunch());
                break;
            case 5:
                StartCoroutine(DoNothing());
                break;
            case 6:
                StartCoroutine(DoNothing());
                break;
            case 7:
                StartCoroutine(SingleSuperPunch());
                break;
            case 8:
                StartCoroutine(SingleSwipe());
                break;
            case 9:
                StartCoroutine(DodgeLeftThenStrikeRight());
                break;
            case 10:
                StartCoroutine(DodgeRightThenStrikeLeft());
                break;
            case 11:
                StartCoroutine(Block());
                break;
            case 12:
                StartCoroutine(Block());
                break;
        }
    }
    //enemy moves-------------------------------------------------------------------------------
    private IEnumerator DoNothing()
    {
        yield return new WaitForSeconds(ai_IdleTime_Long);

        RandomBehaviorSelect();
        StopCoroutine(DoNothing());
    }
    private IEnumerator ThreePunchCombo()
    {
        onPunchStart.Invoke();
        isRegularPunching = true;
        yield return new WaitForSeconds(punch_TimeFromStartToDamage);
        onPunchDamageTime.Invoke();
        enemyRegularPunchConnects();
        yield return new WaitForSeconds(punch_TimeFromDamageToEnd);
        onPunchEnd.Invoke();
        isRegularPunching = false;

        yield return new WaitForSeconds(ai_IdleTime_VeryShort);

        onPunchStartOther.Invoke();
        isRegularPunching = true;
        yield return new WaitForSeconds(punch_TimeFromStartToDamage);
        onPunchDamageTimeOther.Invoke();
        enemyRegularPunchConnects();
        yield return new WaitForSeconds(punch_TimeFromDamageToEnd);
        onPunchEndOther.Invoke();
        isRegularPunching = false;

        yield return new WaitForSeconds(ai_IdleTime_VeryShort);

        onPunchStart.Invoke();
        isRegularPunching = true;

        yield return new WaitForSeconds(punch_TimeFromStartToDamage);

        onPunchDamageTime.Invoke();
        enemyRegularPunchConnects();

        yield return new WaitForSeconds(punch_TimeFromDamageToEnd);

        onPunchEnd.Invoke();
        isRegularPunching = false;

        yield return new WaitForSeconds(ai_IdleTime_Long);

        RandomBehaviorSelect();
        StopCoroutine(ThreePunchCombo());
    }
    private IEnumerator SingleRegularPunch()
    {
        onPunchStart.Invoke();
        isRegularPunching = true;
        yield return new WaitForSeconds(punch_TimeFromStartToDamage);
        onPunchDamageTime.Invoke();
        enemyRegularPunchConnects();
        yield return new WaitForSeconds(punch_TimeFromDamageToEnd);
        onPunchEnd.Invoke();
        isRegularPunching = false;

        yield return new WaitForSeconds(ai_IdleTime_Long);

        RandomBehaviorSelect();
        StopCoroutine(SingleRegularPunch());
    }
    private IEnumerator SingleSuperPunch()
    {
        onSuperPunchStart.Invoke();
        isUltraPunching = true;
        yield return new WaitForSeconds(superPunch_TimeFromStartToDamage);
        onSuperPunchDamageTime.Invoke();
        enemySuperPunchConnects();
        yield return new WaitForSeconds(superPunch_TimeFromDamageToEnd);
        onSuperPunchEnd.Invoke();
        isUltraPunching = false;

        yield return new WaitForSeconds(ai_IdleTime_Long);

        RandomBehaviorSelect();
        StopCoroutine(SingleSuperPunch());
    }
    private IEnumerator SingleSwipe()
    {
        onSwipeStart.Invoke();
        isSwiping = true;

        yield return new WaitForSeconds(swipe_TimeFromStartToDamage);

        onSwipeDamageTime.Invoke();
        enemySwipeConnects();
        yield return new WaitForSeconds(swipe_TimeFromDamageToEnd);

        onSwipeEnd.Invoke();
        isSwiping = false;

        yield return new WaitForSeconds(ai_IdleTime_Long);

        RandomBehaviorSelect();
        StopCoroutine(SingleSwipe());

    }
    private IEnumerator DodgeRightThenStrikeLeft()
    {
        onRightDodgeLeftPunchStart.Invoke();
        isSidePunching = true;

        yield return new WaitForSeconds(sidePunch_TimeFromStartToDoding);

        onRightDodgeLeftPunchWindup.Invoke();
        isDodging = true;

        yield return new WaitForSeconds(sidePunch_TimeFromDodginToDamage);

        onRightDodgeLeftPunchDamageTime.Invoke();
        isDodging = false;
        enemyLeftPunchConnects();

        yield return new WaitForSeconds(sidePunch_TimeFromDamageToEnd);

        onRightDodgeLeftPunchEnd.Invoke();
        isSidePunching = false;

        yield return new WaitForSeconds(ai_IdleTime_Long);

        RandomBehaviorSelect();
        StopCoroutine(DodgeRightThenStrikeLeft());
    }
    private IEnumerator DodgeLeftThenStrikeRight()
    {
        onLeftDodgeRightPunchStart.Invoke();
        isSidePunching = true;

        yield return new WaitForSeconds(sidePunch_TimeFromStartToDoding);

        onLeftDodgeRightPunchWindup.Invoke();
        isDodging = true;

        yield return new WaitForSeconds(sidePunch_TimeFromDodginToDamage);

        onLeftDodgeRightPunchDamageTime.Invoke();
        isDodging = false;
        enemyRightPunchConnects();

        yield return new WaitForSeconds(sidePunch_TimeFromDamageToEnd);

        onLeftDodgeRightPunchEnd.Invoke();
        isSidePunching = false;

        yield return new WaitForSeconds(ai_IdleTime_Long);

        RandomBehaviorSelect();
        StopCoroutine(DodgeLeftThenStrikeRight());
    }
    //reaction to player moves-----------------------------------------------------------------------
    public void playerPunchConnects()
    {
        if(isDodging == false && isBlocking == false && fightingGameMaster.FightIsOver == false)
        {
            fightingGameMaster.playerPunchDoesDamage();
            //overrideStaggerCombo++;
            //if(overrideStaggerCombo >= 3)
            //{
            //    overrideStaggerCombo = 0;
            //    StopAllCoroutines();
            //    StopCoroutine(staggerOverride());
            //}
            //else
            //{
            //    StopAllCoroutines();
            //    StartCoroutine(stagger());
            //}
        }
        if(isBlocking == true && fightingGameMaster.FightIsOver == false)
        {
            //ataque do jogador foi blokeado
        }
    }
    private IEnumerator stagger()
    {
        onStaggerStart.Invoke();

        isBlocking = false;
        isDodging = false;
        isRegularPunching = false;
        isUltraPunching = false;
        isSidePunching = false;
        isSwiping = false;

        isStaggered = true;

        yield return new WaitForSeconds(stagger_staggerDuration);

        isStaggered = false;
        onStaggerEnd.Invoke();

        yield return new WaitForSeconds(ai_IdleTime_Long);

        RandomBehaviorSelect();
        StopCoroutine(stagger());
    }
    private IEnumerator staggerOverride()
    {
        onStaggerStart.Invoke();

        isBlocking = false;
        isDodging = false;
        isRegularPunching = false;
        isUltraPunching = false;
        isSidePunching = false;
        isSwiping = false;

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
        StopCoroutine(staggerOverride());
    }
    private IEnumerator Block()
    {
        onBlockStart.Invoke();
        isBlocking = true;

        yield return new WaitForSeconds(block_DurationOfBlock);

        onBlockEnd.Invoke();
        isBlocking = false;

        yield return new WaitForSeconds(ai_IdleTime_Long);

        RandomBehaviorSelect();
        StopCoroutine(Block());
    }
    public void Knockout()
    {
        StopAllCoroutines();
        onEnemyKnockout.Invoke();
    }

    //enemy move results------------------------------------------------------------------------------
    private void enemyRegularPunchConnects()
    {
        if(playerFightStatus.isBlocking == false && playerFightStatus.isLeft == false && playerFightStatus.isRight == false && playerFightStatus.isDown == false && fightingGameMaster.FightIsOver == false)
        {
            fightingGameMaster.enemyRegularPunchDoesDamage();
            playerFightStatus.stagger();
        }
        else
        {
            //falhou ataque
        }
    }
    private void enemySuperPunchConnects()
    {
        if(playerFightStatus.isLeft == false && playerFightStatus.isRight == false && fightingGameMaster.FightIsOver == false)
        {
            fightingGameMaster.enemySuperPunchDoesDamage();
            playerFightStatus.stagger();
        }
        else
        {
            //falhou ataque
        }
    }
    private void enemySwipeConnects()
    {
        if(playerFightStatus.isDown == false && fightingGameMaster.FightIsOver == false)
        {
        fightingGameMaster.enemySuperPunchDoesDamage();
        playerFightStatus.stagger();
        }
        else
        {
            //falhou ataque
        }
    }
    private void enemyLeftPunchConnects()
    {
        if(playerFightStatus.isRight == false && playerFightStatus.isDown == false && isBlocking == false && fightingGameMaster.FightIsOver == false)
        {
            fightingGameMaster.enemyRegularPunchDoesDamage();
            playerFightStatus.stagger();
        }
        else
        {
            //falhou ataque
        }
    }
    private void enemyRightPunchConnects()
    {
        if(playerFightStatus.isLeft == false && playerFightStatus.isDown == false && isBlocking == false && fightingGameMaster.FightIsOver == false)
        {
            fightingGameMaster.enemyRegularPunchDoesDamage();
            playerFightStatus.stagger();
        }
        else
        {
            //falhou ataque
        }
    }
}
