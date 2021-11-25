using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InactiveInTime : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] float timeTillInactive;
    private void OnEnable()
    {
        StartCoroutine(Inative());
    }
    private IEnumerator Inative()
    {
        yield return new WaitForSeconds(timeTillInactive);
        obj.SetActive(false);
    }
}
