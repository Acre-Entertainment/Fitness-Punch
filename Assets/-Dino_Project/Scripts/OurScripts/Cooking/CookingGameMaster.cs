using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingGameMaster : MonoBehaviour
{
    private int phase = 0;
    public int[] selectedFoodsID = new int[3];
    public int points;
    public float timeForPopUps;
    public int pointsForCenterThrow, pointsForNearThrow, pointsForCloseThrow, pointsForInsideThrow;

    public GameObject aim;
    public GameObject centerText;
    public GameObject nearText;
    public GameObject closeText;
    public GameObject insideText;
    private AimThingy at;
    
    private float time;

    void Start()
    {
        
    }

    void Update()
    {
        time = time + 1 * Time.deltaTime;
        switch (phase)
        {
            case 0:
                if(time >= timeForPopUps)
                {
                    time = 0;
                    phase++;
                }
                break;
        }
    }
}
