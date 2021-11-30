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
    void Start()
    {
        time = timeDuration;
        uiTimerText = uiTimer.GetComponent<Text>();
        uiPointsText = uiPoints.GetComponent<Text>();
    }
    void Update()
    {
        time = time - 1 * Time.deltaTime;
        uiTimerText.text = "Tempo: " + (int)time;
        if(time <= 0)
        {
            onGameEnd.Invoke();
            if(points >= pointsNeededForBigReward)
            {
                reward = bighRewardToStrengh;
                onGameEndHighReward.Invoke();
                FindObjectOfType<AudioManager>().Play("Victory");
            }
            else
            {
                if(points >= pointsNeededForMediumReward)
                {
                    reward = mediumRewardToStrengh;
                    onGameEndMediumReward.Invoke();
                    FindObjectOfType<AudioManager>().Play("Victory");
                }
                else
                {
                    if(points >= pointsNeededForSmallReward)
                    {
                        reward = smallRewardToStrengh;
                        onGameEndLowReward.Invoke();
                        FindObjectOfType<AudioManager>().Play("Victory");
                    }
                    else
                    {
                        reward = 0;
                        onGameEndNoReward.Invoke();
                        FindObjectOfType<AudioManager>().Play("Defeat");
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
            finalMenuPoints.GetComponent<Text>().text = "Pontos: " + points;
            finalMenuText.GetComponent<Text>().text = "Sua força aumentou em " + (dt.forca - forcaAntiga) + "!";
        }
    }
    public void updatPointUI()
    {
        uiPointsText.text = "Pontos: " + points;
    }
}
