using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InativeInTime : MonoBehaviour
{
    [SerializeField]private float time;
    private void Start()
    {
        time = 0.3f;
    }
    private void OnEnable()
    {
        StartCoroutine(DisablenTime());
    }
    private IEnumerator DisablenTime()
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}