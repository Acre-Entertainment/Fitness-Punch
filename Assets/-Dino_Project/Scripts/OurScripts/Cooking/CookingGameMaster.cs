using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CookingGameMaster : MonoBehaviour
{
    [HideInInspector] public int phase = 0;
    [HideInInspector] public bool goingToNextPhase;
    [HideInInspector] public int foodsThrownInPhaseOne;
    [HideInInspector] public bool waitingAfterThrowingFood;
    public int[] selectedFoodsID = new int[3];
    public int points;
    [SerializeField] private float timeForPopUps;
    [SerializeField] private float timeForShortPopUps;
    [SerializeField] private float timeToStir;
    [SerializeField] private float timeToThrow;
    public int pointsForCenterThrow, pointsForNearThrow, pointsForCloseThrow, pointsForInsideThrow;
    public UnityEvent onPhaseZeroEnd;
    public UnityEvent onPhaseOneEnd;
    public UnityEvent onPhaseTwoEnd;
    public UnityEvent onPhaseThreeEnd;

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
    }

    void Update()
    {
        time = time + 1 * Time.deltaTime;
        switch (phase)
        {
            case 3:
                startingCounterText.text = "" + (timeForPopUps - (int)time);
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
        pointsUIText.text = "" + points;
    }
    public void nearHit()
    {
        nearText.SetActive(true);
        points = points + pointsForNearThrow;
        pointsUIText.text = "" + points;
    }
    public void closeHit()
    {
        closeText.SetActive(true);
        points = points + pointsForCloseThrow;
        pointsUIText.text = "" + points;
    }
    public void insideHit()
    {
        insideText.SetActive(true);
        points = points + pointsForInsideThrow;
        pointsUIText.text = "" + points;
    }
    public void outsideHit()
    {
        outsideText.SetActive(true);
        pointsUIText.text = "" + points;
    }
    public void stirRight()
    {
        points++;
        pointsUIText.text = "" + points;
    }
    public void stirLeft()
    {
        points++;
        pointsUIText.text = "" + points;
    }
}
