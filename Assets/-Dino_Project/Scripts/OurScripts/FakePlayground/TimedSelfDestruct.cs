using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSelfDestruct : MonoBehaviour
{
    //coloque um tempo dai o objeto vai bye bye
    private float _time;
    [SerializeField]private float timeToDestruct;
    void Update()
    {
        _time = _time + 1 * Time.deltaTime;
        if(_time >= timeToDestruct)
        {
            Destroy(gameObject);
        }
    }
}
