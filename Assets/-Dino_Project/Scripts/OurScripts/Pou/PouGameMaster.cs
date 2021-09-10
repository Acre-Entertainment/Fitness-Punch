using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouGameMaster : MonoBehaviour
{
    [SerializeField] private int PouTurn;
    [SerializeField] private float turnDuration;
    [SerializeField] private int lowQualityPointWorth;
    [SerializeField] private int mediumQualityPointWorth;
    [SerializeField] private int highQualityPointWorth;
    [SerializeField] private int pointsNeededForMediumReward;
    [SerializeField] private int pointsNeededForHighReward;


    public int lowQualityFoodCatched;
    public int mediumQualityFoodCatched;
    public int highQualityFoodCatched;

    public int turn1Result;
    public int turn2Result;
    public int turn3Result;
    public int turn4Result;

    private int _time;
}
