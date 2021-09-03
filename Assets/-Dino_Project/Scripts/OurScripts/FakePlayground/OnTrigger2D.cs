using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTrigger2D : MonoBehaviour
{
    public string objectTag;
    public UnityEvent onTriggerEnter;
    public UnityEvent onTriggerStay;
    public UnityEvent onTriggerExit;
    void OnTriggerEnter2D(Collider2D other)
    {
        onTriggerEnter.Invoke();
    }
    void OnTriggerStay2D(Collider2D other)
    {
        onTriggerStay.Invoke();
    }
    void OnTriggerExit2D(Collider2D other)
    {
        onTriggerExit.Invoke();
    }
}
