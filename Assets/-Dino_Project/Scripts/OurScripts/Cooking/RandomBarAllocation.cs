using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBarAllocation : MonoBehaviour
{
    public GameObject[] bars;
    public float startingHeight;
    private float currentHeight;
    void Start()
    {
        currentHeight = startingHeight;
        for(int x = bars.Length - 1; x > 0; x--)
        {
            float randy = Random.Range(0, 0.999f) * (x + 1);
            int y = (int)randy;
            GameObject temporary = bars[x];
            bars[x] = bars[y];
            bars[y] = temporary;
        }
        foreach(GameObject go in bars)
        {
            go.transform.position = new Vector3(go.transform.position.x, currentHeight, 0);
            currentHeight = currentHeight + go.GetComponent<Bar>().height;
        }
    }
}
