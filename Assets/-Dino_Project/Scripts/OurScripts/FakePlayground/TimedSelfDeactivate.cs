using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSelfDeactivate : MonoBehaviour
{
    public float timer;
    private float time;
    void Update()
    {
        time = time + 1 * Time.deltaTime;
        if(time >= timer)
        {
            time = 0;
            gameObject.SetActive(false);
        }
    }
}
