using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InativeInTIme : MonoBehaviour
{
    [SerializeField] GameObject obj;
    private void OnEnable()
    {
        StartCoroutine(Inative());
    }
    private IEnumerator Inative()
    {
        yield return new WaitForSeconds(0.34f);
        obj.SetActive(false);
    }

}
