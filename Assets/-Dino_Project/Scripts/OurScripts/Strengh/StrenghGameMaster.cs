using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class StrenghGameMaster : MonoBehaviour
{
    private DataHolder dt;
    public int points;
    public int pointsForPunch;
    public int pointsForBlock;
    public int pointsPenaltyForNotBlocking;
    [SerializeField] private int pointsNeededForSmallReward;
    [SerializeField] private int smallRewardToStrengh;
    [SerializeField] private int pointsNeededForMediumReward;
    [SerializeField] private int mediumRewardToStrengh;
    [SerializeField] private int pointsNeededForBigReward;
    [SerializeField] private int bighRewardToStrengh;
    private int reward;
    [SerializeField] private float timeDuration;
    private float time;
    [SerializeField] private GameObject uiTimer;
    private Text uiTimerText;
    [SerializeField] private GameObject uiPoints;
    private Text uiPointsText;
    [SerializeField] private GameObject finalMenuPoints;
    [SerializeField] private GameObject finalMenuText;
    public UnityEvent onGameEnd;
    public UnityEvent onGameEndNoReward;
    public UnityEvent onGameEndLowReward;
    public UnityEvent onGameEndMediumReward;
    public UnityEvent onGameEndHighReward;
    public UnityEvent onPlayerBlockedAttack;
    public UnityEvent onPlayerNotBlockedAttack;
    public UnityEvent onEnemyBlockedAttack;
    public UnityEvent onEnemyNotBlockedAttack;
    private bool gameOver;
    void Start()
    {
        time = timeDuration;
        uiTimerText = uiTimer.GetComponent<Text>();
        uiPointsText = uiPoints.GetComponent<Text>();
    }
    void Update()
    {
        if(gameOver == false)
        {
            time = time - 1 * Time.deltaTime;
        }
        uiTimerText.text = "Time: " + (int)time;
        if(time <= 0)
        {
            gameOver = true;
            onGameEnd.Invoke();
            if(points >= pointsNeededForBigReward)
            {
                reward = bighRewardToStrengh;
                onGameEndHighReward.Invoke();
            }
            else
            {
                if(points >= pointsNeededForMediumReward)
                {
                    reward = mediumRewardToStrengh;
                    onGameEndMediumReward.Invoke();
                }
                else
                {
                    if(points >= pointsNeededForSmallReward)
                    {
                        reward = smallRewardToStrengh;
                        onGameEndLowReward.Invoke();
                    }
                    else
                    {
                        reward = 0;
                        onGameEndNoReward.Invoke();
                    }
                }
            }
            dt = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
            int forcaAntiga = dt.forca;
            dt.forca = dt.forca + reward;
            if(dt.forca > 10)
            {
                dt.forca = 10;
            }
            finalMenuPoints.GetComponent<Text>().text = "Points: " + points;
            finalMenuText.GetComponent<Text>().text = "Your strength increased in " + (dt.forca - forcaAntiga) + "!";
        }
    }
    public void updatPointUI()
    {
        uiPointsText.text = "Points: " + points;
    }
}
