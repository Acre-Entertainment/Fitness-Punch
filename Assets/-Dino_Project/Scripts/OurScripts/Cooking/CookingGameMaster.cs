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
    [SerializeField] private int disposicaoDebuffForSuck;
    [SerializeField] private int pointsNeededForNormal;
    [SerializeField] private int pointsNeededForExtra;
    [SerializeField] private int disposicaoBuffForExtra;
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
    private DataHolder dataHolder;
    private int startingCar, startingPro, startingLip, startingMin, startingVit, startingFib, startingDis;

    void Start()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        startingCounterText = startingCounter.GetComponent<Text>();
        pointsUIText = pointsUI.GetComponent<Text>();
        timeForChecks = timeBetweenChecks;

        selectedFoodsID[0] = dataHolder.selectedCookingFood[0];
        selectedFoodsID[1] = dataHolder.selectedCookingFood[1];
        selectedFoodsID[2] = dataHolder.selectedCookingFood[2];

        startingCar = dataHolder.carboidrato;
        startingPro = dataHolder.proteina;
        startingLip = dataHolder.lipidio;
        startingMin = dataHolder.mineral;
        startingVit = dataHolder.vitamina;
        startingFib = dataHolder.fibra;
        startingDis = dataHolder.disposicao;
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
                        pointsUIText.text = "Pontos: " + points;
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
        pointsUIText.text = "Pontos: " + points;
    }
    public void nearHit()
    {
        nearText.SetActive(true);
        points = points + pointsForNearThrow;
        pointsUIText.text = "Pontos: " + points;
    }
    public void closeHit()
    {
        closeText.SetActive(true);
        points = points + pointsForCloseThrow;
        pointsUIText.text = "Pontos: " + points;
    }
    public void insideHit()
    {
        insideText.SetActive(true);
        points = points + pointsForInsideThrow;
        pointsUIText.text = "Pontos: " + points;
    }
    public void outsideHit()
    {
        outsideText.SetActive(true);
        pointsUIText.text = "Pontos: " + points;
    }
    public void stirRight()
    {
        points++;
        pointsUIText.text = "Pontos: " + points;
    }
    public void stirLeft()
    {
        points++;
        pointsUIText.text = "Pontos: " + points;
    }
    private int proToBeAdd, carToBeAdd, lipToBeAdd, minToBeAdd, vitToBeAdd, fibToBeAdd, disToBeAdd;
    [HideInInspector]public int changingCar, changingPro, changingLip, changingMin, changingVit,changingFib, changingDis;
    private void caulculateResults()
    {
        //primeiro ingrediente
        if(selectedFoodsID[0] < 200)
        {
            if(selectedFoodsID[0] == 101){proToBeAdd += 1; fibToBeAdd += 1;}
            if(selectedFoodsID[0] == 102){proToBeAdd += 1; vitToBeAdd += 1;}
            if(selectedFoodsID[0] == 103){proToBeAdd += 1; lipToBeAdd += 1;}
            if(selectedFoodsID[0] == 104){proToBeAdd += 1; carToBeAdd += 1;}
            if(selectedFoodsID[0] == 105){proToBeAdd += 1; minToBeAdd += 1;}
            if(selectedFoodsID[0] == 106){vitToBeAdd += 1; fibToBeAdd += 1;}
            if(selectedFoodsID[0] == 107){minToBeAdd += 1; vitToBeAdd += 1;}
            if(selectedFoodsID[0] == 108){carToBeAdd += 1; lipToBeAdd += 1;}
            if(selectedFoodsID[0] == 109){lipToBeAdd += 1; minToBeAdd += 1;}
            if(selectedFoodsID[0] == 110){lipToBeAdd += 1; vitToBeAdd += 1;}
            if(selectedFoodsID[0] == 111){lipToBeAdd += 1; fibToBeAdd += 1;}
            if(selectedFoodsID[0] == 112){carToBeAdd += 1; vitToBeAdd += 1;}
            if(selectedFoodsID[0] == 113){carToBeAdd += 1; fibToBeAdd += 1;}
            if(selectedFoodsID[0] == 114){carToBeAdd += 1; minToBeAdd += 1;}
            if(selectedFoodsID[0] == 115){minToBeAdd += 1; fibToBeAdd += 1;}
        }
        if(selectedFoodsID[0] > 200 && selectedFoodsID[0] < 300)
        {
            if(selectedFoodsID[0] == 201){proToBeAdd += 2; fibToBeAdd += 2;}
            if(selectedFoodsID[0] == 202){proToBeAdd += 2; vitToBeAdd += 2;}
            if(selectedFoodsID[0] == 203){proToBeAdd += 2; lipToBeAdd += 2;}
            if(selectedFoodsID[0] == 204){proToBeAdd += 2; carToBeAdd += 2;}
            if(selectedFoodsID[0] == 205){proToBeAdd += 2; minToBeAdd += 2;}
            if(selectedFoodsID[0] == 206){vitToBeAdd += 2; fibToBeAdd += 2;}
            if(selectedFoodsID[0] == 207){minToBeAdd += 2; vitToBeAdd += 2;}
            if(selectedFoodsID[0] == 208){carToBeAdd += 2; lipToBeAdd += 2;}
            if(selectedFoodsID[0] == 209){lipToBeAdd += 2; minToBeAdd += 2;}
            if(selectedFoodsID[0] == 210){lipToBeAdd += 2; vitToBeAdd += 2;}
            if(selectedFoodsID[0] == 211){lipToBeAdd += 2; fibToBeAdd += 2;}
            if(selectedFoodsID[0] == 212){carToBeAdd += 2; vitToBeAdd += 2;}
            if(selectedFoodsID[0] == 213){carToBeAdd += 2; fibToBeAdd += 2;}
            if(selectedFoodsID[0] == 214){carToBeAdd += 2; minToBeAdd += 2;}
            if(selectedFoodsID[0] == 215){minToBeAdd += 2; fibToBeAdd += 2;}
        }
        if(selectedFoodsID[0] > 300)
        {
            if(selectedFoodsID[0] == 301){proToBeAdd += 3; fibToBeAdd += 3;}
            if(selectedFoodsID[0] == 302){proToBeAdd += 3; vitToBeAdd += 3;}
            if(selectedFoodsID[0] == 303){proToBeAdd += 3; lipToBeAdd += 3;}
            if(selectedFoodsID[0] == 304){proToBeAdd += 3; carToBeAdd += 3;}
            if(selectedFoodsID[0] == 305){proToBeAdd += 3; minToBeAdd += 3;}
            if(selectedFoodsID[0] == 306){vitToBeAdd += 3; fibToBeAdd += 3;}
            if(selectedFoodsID[0] == 307){minToBeAdd += 3; vitToBeAdd += 3;}
            if(selectedFoodsID[0] == 308){carToBeAdd += 3; lipToBeAdd += 3;}
            if(selectedFoodsID[0] == 309){lipToBeAdd += 3; minToBeAdd += 3;}
            if(selectedFoodsID[0] == 310){lipToBeAdd += 3; vitToBeAdd += 3;}
            if(selectedFoodsID[0] == 311){lipToBeAdd += 3; fibToBeAdd += 3;}
            if(selectedFoodsID[0] == 312){carToBeAdd += 3; vitToBeAdd += 3;}
            if(selectedFoodsID[0] == 313){carToBeAdd += 3; fibToBeAdd += 3;}
            if(selectedFoodsID[0] == 314){carToBeAdd += 3; minToBeAdd += 3;}
            if(selectedFoodsID[0] == 315){minToBeAdd += 3; fibToBeAdd += 3;}
        }
        //segundo ingrediente
        if(selectedFoodsID[1] < 200)
        {
            if(selectedFoodsID[1] == 101){proToBeAdd += 1; fibToBeAdd += 1;}
            if(selectedFoodsID[1] == 102){proToBeAdd += 1; vitToBeAdd += 1;}
            if(selectedFoodsID[1] == 103){proToBeAdd += 1; lipToBeAdd += 1;}
            if(selectedFoodsID[1] == 104){proToBeAdd += 1; carToBeAdd += 1;}
            if(selectedFoodsID[1] == 105){proToBeAdd += 1; minToBeAdd += 1;}
            if(selectedFoodsID[1] == 106){vitToBeAdd += 1; fibToBeAdd += 1;}
            if(selectedFoodsID[1] == 107){minToBeAdd += 1; vitToBeAdd += 1;}
            if(selectedFoodsID[1] == 108){carToBeAdd += 1; lipToBeAdd += 1;}
            if(selectedFoodsID[1] == 109){lipToBeAdd += 1; minToBeAdd += 1;}
            if(selectedFoodsID[1] == 110){lipToBeAdd += 1; vitToBeAdd += 1;}
            if(selectedFoodsID[1] == 111){lipToBeAdd += 1; fibToBeAdd += 1;}
            if(selectedFoodsID[1] == 112){carToBeAdd += 1; vitToBeAdd += 1;}
            if(selectedFoodsID[1] == 113){carToBeAdd += 1; fibToBeAdd += 1;}
            if(selectedFoodsID[1] == 114){carToBeAdd += 1; minToBeAdd += 1;}
            if(selectedFoodsID[1] == 115){minToBeAdd += 1; fibToBeAdd += 1;}
        }
        if(selectedFoodsID[1] > 200 && selectedFoodsID[1] < 300)
        {
            if(selectedFoodsID[1] == 201){proToBeAdd += 2; fibToBeAdd += 2;}
            if(selectedFoodsID[1] == 202){proToBeAdd += 2; vitToBeAdd += 2;}
            if(selectedFoodsID[1] == 203){proToBeAdd += 2; lipToBeAdd += 2;}
            if(selectedFoodsID[1] == 204){proToBeAdd += 2; carToBeAdd += 2;}
            if(selectedFoodsID[1] == 205){proToBeAdd += 2; minToBeAdd += 2;}
            if(selectedFoodsID[1] == 206){vitToBeAdd += 2; fibToBeAdd += 2;}
            if(selectedFoodsID[1] == 207){minToBeAdd += 2; vitToBeAdd += 2;}
            if(selectedFoodsID[1] == 208){carToBeAdd += 2; lipToBeAdd += 2;}
            if(selectedFoodsID[1] == 209){lipToBeAdd += 2; minToBeAdd += 2;}
            if(selectedFoodsID[1] == 210){lipToBeAdd += 2; vitToBeAdd += 2;}
            if(selectedFoodsID[1] == 211){lipToBeAdd += 2; fibToBeAdd += 2;}
            if(selectedFoodsID[1] == 212){carToBeAdd += 2; vitToBeAdd += 2;}
            if(selectedFoodsID[1] == 213){carToBeAdd += 2; fibToBeAdd += 2;}
            if(selectedFoodsID[1] == 214){carToBeAdd += 2; minToBeAdd += 2;}
            if(selectedFoodsID[1] == 215){minToBeAdd += 2; fibToBeAdd += 2;}
        }
        if(selectedFoodsID[1] > 300)
        {
            if(selectedFoodsID[1] == 301){proToBeAdd += 3; fibToBeAdd += 3;}
            if(selectedFoodsID[1] == 302){proToBeAdd += 3; vitToBeAdd += 3;}
            if(selectedFoodsID[1] == 303){proToBeAdd += 3; lipToBeAdd += 3;}
            if(selectedFoodsID[1] == 304){proToBeAdd += 3; carToBeAdd += 3;}
            if(selectedFoodsID[1] == 305){proToBeAdd += 3; minToBeAdd += 3;}
            if(selectedFoodsID[1] == 306){vitToBeAdd += 3; fibToBeAdd += 3;}
            if(selectedFoodsID[1] == 307){minToBeAdd += 3; vitToBeAdd += 3;}
            if(selectedFoodsID[1] == 308){carToBeAdd += 3; lipToBeAdd += 3;}
            if(selectedFoodsID[1] == 309){lipToBeAdd += 3; minToBeAdd += 3;}
            if(selectedFoodsID[1] == 310){lipToBeAdd += 3; vitToBeAdd += 3;}
            if(selectedFoodsID[1] == 311){lipToBeAdd += 3; fibToBeAdd += 3;}
            if(selectedFoodsID[1] == 312){carToBeAdd += 3; vitToBeAdd += 3;}
            if(selectedFoodsID[1] == 313){carToBeAdd += 3; fibToBeAdd += 3;}
            if(selectedFoodsID[1] == 314){carToBeAdd += 3; minToBeAdd += 3;}
            if(selectedFoodsID[1] == 315){minToBeAdd += 3; fibToBeAdd += 3;}
        }
        //terceiro ingrediente
        if(selectedFoodsID[2] < 200)
        {
            if(selectedFoodsID[2] == 101){proToBeAdd += 1; fibToBeAdd += 1;}
            if(selectedFoodsID[2] == 102){proToBeAdd += 1; vitToBeAdd += 1;}
            if(selectedFoodsID[2] == 103){proToBeAdd += 1; lipToBeAdd += 1;}
            if(selectedFoodsID[2] == 104){proToBeAdd += 1; carToBeAdd += 1;}
            if(selectedFoodsID[2] == 105){proToBeAdd += 1; minToBeAdd += 1;}
            if(selectedFoodsID[2] == 106){vitToBeAdd += 1; fibToBeAdd += 1;}
            if(selectedFoodsID[2] == 107){minToBeAdd += 1; vitToBeAdd += 1;}
            if(selectedFoodsID[2] == 108){carToBeAdd += 1; lipToBeAdd += 1;}
            if(selectedFoodsID[2] == 109){lipToBeAdd += 1; minToBeAdd += 1;}
            if(selectedFoodsID[2] == 110){lipToBeAdd += 1; vitToBeAdd += 1;}
            if(selectedFoodsID[2] == 111){lipToBeAdd += 1; fibToBeAdd += 1;}
            if(selectedFoodsID[2] == 112){carToBeAdd += 1; vitToBeAdd += 1;}
            if(selectedFoodsID[2] == 113){carToBeAdd += 1; fibToBeAdd += 1;}
            if(selectedFoodsID[2] == 114){carToBeAdd += 1; minToBeAdd += 1;}
            if(selectedFoodsID[2] == 115){minToBeAdd += 1; fibToBeAdd += 1;}
        }
        if(selectedFoodsID[2] > 200 && selectedFoodsID[2] < 300)
        {
            if(selectedFoodsID[2] == 201){proToBeAdd += 2; fibToBeAdd += 2;}
            if(selectedFoodsID[2] == 202){proToBeAdd += 2; vitToBeAdd += 2;}
            if(selectedFoodsID[2] == 203){proToBeAdd += 2; lipToBeAdd += 2;}
            if(selectedFoodsID[2] == 204){proToBeAdd += 2; carToBeAdd += 2;}
            if(selectedFoodsID[2] == 205){proToBeAdd += 2; minToBeAdd += 2;}
            if(selectedFoodsID[2] == 206){vitToBeAdd += 2; fibToBeAdd += 2;}
            if(selectedFoodsID[2] == 207){minToBeAdd += 2; vitToBeAdd += 2;}
            if(selectedFoodsID[2] == 208){carToBeAdd += 2; lipToBeAdd += 2;}
            if(selectedFoodsID[2] == 209){lipToBeAdd += 2; minToBeAdd += 2;}
            if(selectedFoodsID[2] == 210){lipToBeAdd += 2; vitToBeAdd += 2;}
            if(selectedFoodsID[2] == 211){lipToBeAdd += 2; fibToBeAdd += 2;}
            if(selectedFoodsID[2] == 212){carToBeAdd += 2; vitToBeAdd += 2;}
            if(selectedFoodsID[2] == 213){carToBeAdd += 2; fibToBeAdd += 2;}
            if(selectedFoodsID[2] == 214){carToBeAdd += 2; minToBeAdd += 2;}
            if(selectedFoodsID[2] == 215){minToBeAdd += 2; fibToBeAdd += 2;}
        }
        if(selectedFoodsID[2] > 300)
        {
            if(selectedFoodsID[2] == 301){proToBeAdd += 3; fibToBeAdd += 3;}
            if(selectedFoodsID[2] == 302){proToBeAdd += 3; vitToBeAdd += 3;}
            if(selectedFoodsID[2] == 303){proToBeAdd += 3; lipToBeAdd += 3;}
            if(selectedFoodsID[2] == 304){proToBeAdd += 3; carToBeAdd += 3;}
            if(selectedFoodsID[2] == 305){proToBeAdd += 3; minToBeAdd += 3;}
            if(selectedFoodsID[2] == 306){vitToBeAdd += 3; fibToBeAdd += 3;}
            if(selectedFoodsID[2] == 307){minToBeAdd += 3; vitToBeAdd += 3;}
            if(selectedFoodsID[2] == 308){carToBeAdd += 3; lipToBeAdd += 3;}
            if(selectedFoodsID[2] == 309){lipToBeAdd += 3; minToBeAdd += 3;}
            if(selectedFoodsID[2] == 310){lipToBeAdd += 3; vitToBeAdd += 3;}
            if(selectedFoodsID[2] == 311){lipToBeAdd += 3; fibToBeAdd += 3;}
            if(selectedFoodsID[2] == 312){carToBeAdd += 3; vitToBeAdd += 3;}
            if(selectedFoodsID[2] == 313){carToBeAdd += 3; fibToBeAdd += 3;}
            if(selectedFoodsID[2] == 314){carToBeAdd += 3; minToBeAdd += 3;}
            if(selectedFoodsID[2] == 315){minToBeAdd += 3; fibToBeAdd += 3;}
        }
        //modifica o DataHolder e salva o valor da mundança
        dataHolder.proteina += proToBeAdd;
        if(dataHolder.proteina > 10)
        {
            dataHolder.proteina = 10;
        }
        changingPro = dataHolder.proteina - startingPro;

        dataHolder.carboidrato += carToBeAdd;
        if(dataHolder.carboidrato > 10)
        {
            dataHolder.carboidrato = 10;
        }
        changingCar = dataHolder.carboidrato - startingCar;

        dataHolder.lipidio += lipToBeAdd;
        if(dataHolder.lipidio > 10)
        {
            dataHolder.carboidrato = 10;
        }
        changingLip = dataHolder.lipidio - startingLip;

        dataHolder.mineral += minToBeAdd;
        if(dataHolder.mineral > 10)
        {
            dataHolder.mineral = 10;
        }
        changingMin = dataHolder.mineral - startingMin;

        dataHolder.vitamina += vitToBeAdd;
        if(dataHolder.vitamina > 10)
        {
            dataHolder.vitamina = 10;
        }
        changingVit = dataHolder.vitamina - startingVit;

        dataHolder.fibra += fibToBeAdd;
        if(dataHolder.fibra > 10)
        {
            dataHolder.fibra = 10;
        }
        changingFib = dataHolder.fibra - startingFib;

        if(points >= pointsNeededForExtra)
        {
            dataHolder.disposicao += disposicaoBuffForExtra;
            if(dataHolder.disposicao > 10)
            {
                dataHolder.disposicao = 10;
            }
            changingDis = dataHolder.disposicao - startingDis;
        }
        else
        {
            if(points < pointsNeededForNormal)
            {
                dataHolder.disposicao -= disposicaoDebuffForSuck;
                if(dataHolder.disposicao < 0)
                {
                    dataHolder.disposicao = 0;
                }
                changingDis = startingDis - dataHolder.disposicao;
            }
        }
    }
}
