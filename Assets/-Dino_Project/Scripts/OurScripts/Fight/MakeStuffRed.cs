using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeStuffRed : MonoBehaviour
{
    public SpriteRenderer[] stuffToMakeRed;
    public float durationOfRed;
    public void makerRed()
    {
        StopAllCoroutines();
        foreach(SpriteRenderer sp in stuffToMakeRed)
        {
            sp.color = Color.red;
        }
        StartCoroutine(makeStuffNormal());
    }
    private IEnumerator makeStuffNormal()
    {
        yield return new WaitForSeconds(durationOfRed);
        foreach(SpriteRenderer sp in stuffToMakeRed)
        {
            sp.color = Color.white;
        }
    }
}
