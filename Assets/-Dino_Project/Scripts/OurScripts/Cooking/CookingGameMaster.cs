using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CookingGameMaster : MonoBehaviour
{
    public int phase = 0;
    [HideInInspector] public bool goingToNextPhase;
    [HideInInspector] public int foodsThrownInPhaseOne;
    [HideInInspector] public bool waitingAfterThrowingFood;
    public int[] selectedFoodsID = new int[3];
    public int points;
    [SerializeField] private float timeForPopUps;
    [SerializeField] private float timeForShortPopUps;
    [SerializeField] private float timeToStir;
    [SerializeField] private float timeToThrow;
    [SerializeField] private float timeToBalance;
    [SerializeField] private float timeBetweenChecks;
    [HideInInspector] public bool isInContact;
    [SerializeField] private int pointsNeededForNormal;
    [SerializeField] private int pointsNeededForExtra;
    private float timeForChecks;
    public int pointsForCenterThrow, pointsForNearThrow, pointsForCloseThrow, pointsForInsideThrow;
    public UnityEvent onPhaseZeroEnd;
    public UnityEvent onPhaseOneEnd;
    public UnityEvent onPhaseTwoEnd;
    public UnityEvent onPhaseThreeEnd;
    public UnityEvent onPhaseFourEnd;
    public UnityEvent onPhaseFiveEnd;

    public GameObject aim;
    public GameObject pointsUI;
    private Text pointsUIText;
    public GameObject startingText;
    public GameObject startingCounter;
    private Text startingCounterText;
    public GameObject centerText;
    public GameObject nearText;
    public GameObject closeText;
    public GameObject insideText;
    public GameObject outsideText;
    public GameObject throwButton;
    private AimThingy at;
    
    [HideInInspector] public float time;

    void Start()
    {
        startingCounterText = startingCounter.GetComponent<Text>();
        pointsUIText = pointsUI.GetComponent<Text>();
        timeForChecks = timeBetweenChecks;
    }

    void Update()
    {
        time = time + 1 * Time.deltaTime;
        switch (phase)
        {
            case 5:
                if(time >= timeForChecks)
                {
                    timeForChecks = timeForChecks + timeBetweenChecks;
                    if(isInContact == true)
                    {
                        points++;
                        pointsUIText.text = "Points: " + points;
                    }
                }
                if(time >= timeToBalance)
                {
                    time = 0;
                    phase++;
                    onPhaseFiveEnd.Invoke();
                    caulculateResults();
                }
                break;
            case 4:
                startingCounterText.text = "" + (timeForPopUps - (int)time);
                if(time >= timeForPopUps)
                {
                    time = 0;
                    phase++;
                    onPhaseFourEnd.Invoke();
                }
                break;
            case 3:
                startingCounterText.text = "" + (int)(timeToStir - time);
                if(time >= timeToStir)
                {
                    time = 0;
                    phase++;
                    onPhaseThreeEnd.Invoke();
                }
                break;
            case 2:
                startingCounterText.text = "" + (timeForPopUps - (int)time);
                if(time >= timeForPopUps)
                {
                    time = 0;
                    phase++;
                    onPhaseTwoEnd.Invoke();
                }
                break;
            case 1:
                if(waitingAfterThrowingFood == true && time >= timeForShortPopUps)
                {
                    time = 0;
                    waitingAfterThrowingFood = false;
                    aim.GetComponent<AimThingy>().setToStartingX();
                    throwButton.SetActive(true);
                }
                if(goingToNextPhase == true && time >= timeForShortPopUps)
                {
                    phase++;
                    onPhaseOneEnd.Invoke();
                }
                break;
            case 0:
                startingCounterText.text = "" + (timeForPopUps - (int)time);
                if(time >= timeForPopUps)
                {
                    time = 0;
                    phase++;
                    onPhaseZeroEnd.Invoke();
                }
                break;
        }
    }



    public void centerHit()
    {
        centerText.SetActive(true);
        points = points + pointsForCenterThrow;
        pointsUIText.text = "Points: " + points;
    }
    public void nearHit()
    {
        nearText.SetActive(true);
        points = points + pointsForNearThrow;
        pointsUIText.text = "Points: " + points;
    }
    public void closeHit()
    {
        closeText.SetActive(true);
        points = points + pointsForCloseThrow;
        pointsUIText.text = "Points: " + points;
    }
    public void insideHit()
    {
        insideText.SetActive(true);
        points = points + pointsForInsideThrow;
        pointsUIText.text = "Points: " + points;
    }
    public void outsideHit()
    {
        outsideText.SetActive(true);
        pointsUIText.text = "Points: " + points;
    }
    public void stirRight()
    {
        points++;
        pointsUIText.text = "Points: " + points;
    }
    public void stirLeft()
    {
        points++;
        pointsUIText.text = "Points: " + points;
    }
    private void caulculateResults()
    {

    }
}
