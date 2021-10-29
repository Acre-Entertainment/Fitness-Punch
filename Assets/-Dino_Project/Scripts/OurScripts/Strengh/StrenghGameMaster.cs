using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class StrenghGameMaster : MonoBehaviour
{
    [SerializeField] private bool isVulnerableToPunch;
    [SerializeField] private int points;
    [SerializeField] private int pointsForPunch;
    [SerializeField] private int pointsForBlock;
    [SerializeField] private int pointsPenaltyForNotBlocking;
    [SerializeField] private float timeDuration;
    [SerializeField] private GameObject uiTimer;
    [SerializeField] private GameObject uiPoints;
    [SerializeField] private GameObject finalMenuPoints;

    void Start()
    {
        
    }

    private void callRandomMove()
    {

    }
    public void playerPunchConnects()
    {
        if(isVulnerableToPunch == true)
        {
            hitByPlayerPunch();
        }
    }
    private void hitByPlayerPunch()
    {
        points = points + pointsForPunch;
    }
}
