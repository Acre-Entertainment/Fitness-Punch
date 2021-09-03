using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaitTime : MonoBehaviour
{
    [SerializeField] private float timeUntilEvent;
    [SerializeField] private UnityEvent onTimerReachingZero;
    void Update()
    {
        timeUntilEvent = timeUntilEvent - 1 * Time.deltaTime;
        if(timeUntilEvent <= 0)
        {
            onTimerReachingZero.Invoke();
        }
    }
}
