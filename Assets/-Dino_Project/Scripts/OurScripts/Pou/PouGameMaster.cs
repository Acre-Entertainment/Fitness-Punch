using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PouGameMaster : MonoBehaviour
{
    public int turn = 1;
    [SerializeField] private float turnDuration;
    [SerializeField] private int foodPerTurn;
    [SerializeField] private int lowQualityPointWorth;
    [SerializeField] private int mediumQualityPointWorth;
    [SerializeField] private int highQualityPointWorth;
    [SerializeField] private int rottenQualityPointWorth;
    [SerializeField] private int pointsNeededForLowReward;
    [SerializeField] private int pointsNeededForMediumReward;
    [SerializeField] private int pointsNeededForHighReward;


    public int lowQualityFoodCatched;
    public int mediumQualityFoodCatched;
    public int highQualityFoodCatched;
    public int rottenFoodCatched;

    private int _currentTurnResult;

    public int turn1Result;
    public int turn2Result;
    public int turn3Result;
    public int turn4Result;

    private float time;

    [SerializeField] private GameObject round1Text;
    private Text _round1Text;
    [SerializeField] private GameObject round2Text;
    private Text _round2Text;
    [SerializeField] private GameObject round3Text;
    private Text _round3Text;
    [SerializeField] private GameObject round4Text;
    private Text _round4Text;
    [SerializeField] private GameObject timeText;
    private Text _timeText;
    [SerializeField] private GameObject itensText;
    private Text _itensText;
    [SerializeField] private GameObject turnText;
    private Text _turnText;

    private int _roundedTime, _roundedTurnDuration; private int _objectQuantity;

    public UnityEvent onStart;
    public UnityEvent onTurn1End;
    public UnityEvent onTurn2End;
    public UnityEvent onTurn3End;
    public UnityEvent onTurn4End;

    private bool gameRunning = true;

    void Start()
    {
        _round1Text = round1Text.GetComponent<Text>();
        _round2Text = round2Text.GetComponent<Text>();
        _round3Text = round3Text.GetComponent<Text>();
        _round4Text = round4Text.GetComponent<Text>();
        _timeText = timeText.GetComponent<Text>();
        _itensText = itensText.GetComponent<Text>();
        _turnText = turnText.GetComponent<Text>();

        onStart.Invoke();
    }

    void Update()
    {
        time = time + 1 * Time.deltaTime;

        if(gameRunning == true)
        {
            _currentTurnResult = lowQualityFoodCatched * lowQualityPointWorth + mediumQualityFoodCatched * mediumQualityPointWorth + highQualityFoodCatched * highQualityPointWorth + rottenFoodCatched * -rottenQualityPointWorth;
            _objectQuantity = lowQualityFoodCatched + mediumQualityFoodCatched + highQualityFoodCatched + rottenFoodCatched;
            switch (turn)
            {
                case 1:
                    _round1Text.text = _currentTurnResult + " points";
                    break;
                case 2:
                    _round2Text.text = _currentTurnResult + " points";
                    break;
                case 3:
                    _round3Text.text = _currentTurnResult + " points";
                    break;
                case 4:
                    _round4Text.text = _currentTurnResult + " points";
                    break;
            }
            _roundedTime = (int) time; _roundedTurnDuration = (int) turnDuration;
            _timeText.text = "Time: " + _roundedTime + "/" + _roundedTurnDuration;
            _itensText.text = "Itens: " + _objectQuantity +"/" + foodPerTurn;
            _turnText.text = "Turn: " + turn;
        }

        if(time >= turnDuration || _objectQuantity >= foodPerTurn && gameRunning == true)
        {
            switch (turn)
            {
                case 1:
                    if(_currentTurnResult < pointsNeededForLowReward){turn1Result = 0;}
                    if(_currentTurnResult >= pointsNeededForLowReward){turn1Result = 1;}
                    if(_currentTurnResult >= pointsNeededForMediumReward){turn1Result = 2;}
                    if(_currentTurnResult >= pointsNeededForHighReward){turn1Result = 3;}
                    time = 0; lowQualityFoodCatched = 0; mediumQualityFoodCatched = 0; highQualityFoodCatched = 0; _objectQuantity = 0; turn++;
                    onTurn1End.Invoke();
                    break;
                case 2:
                    if(_currentTurnResult < pointsNeededForLowReward){turn2Result = 0;}
                    if(_currentTurnResult >= pointsNeededForLowReward){turn2Result = 1;}
                    if(_currentTurnResult >= pointsNeededForMediumReward){turn2Result = 2;}
                    if(_currentTurnResult >= pointsNeededForHighReward){turn2Result = 3;}
                    time = 0; lowQualityFoodCatched = 0; mediumQualityFoodCatched = 0; highQualityFoodCatched = 0; _objectQuantity = 0; turn++;
                    onTurn2End.Invoke();
                    break;
                case 3:
                    if(_currentTurnResult < pointsNeededForLowReward){turn3Result = 0;}
                    if(_currentTurnResult >= pointsNeededForLowReward){turn3Result = 1;}
                    if(_currentTurnResult >= pointsNeededForMediumReward){turn3Result = 2;}
                    if(_currentTurnResult >= pointsNeededForHighReward){turn3Result = 3;}
                    time = 0; lowQualityFoodCatched = 0; mediumQualityFoodCatched = 0; highQualityFoodCatched = 0; _objectQuantity = 0; turn++;
                    onTurn3End.Invoke();
                    break;
                case 4:
                    if(_currentTurnResult < pointsNeededForLowReward){turn4Result = 0;}
                    if(_currentTurnResult >= pointsNeededForLowReward){turn4Result = 1;}
                    if(_currentTurnResult >= pointsNeededForMediumReward){turn4Result = 2;}
                    if(_currentTurnResult >= pointsNeededForHighReward){turn4Result = 3;}
                    time = 0; lowQualityFoodCatched = 0; mediumQualityFoodCatched = 0; highQualityFoodCatched = 0; _objectQuantity = 0; turn++;
                    onTurn4End.Invoke();
                    gameRunning = false;
                    break;
            }
        }
    }
}
