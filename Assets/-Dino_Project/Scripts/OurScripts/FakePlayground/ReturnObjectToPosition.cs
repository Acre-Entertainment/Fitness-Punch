using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnObjectToPosition : MonoBehaviour
{
    [SerializeField] private float maxY;
    [SerializeField] private float minY;
    void Update()
    {
        Vector3 localTransformPosition = gameObject.transform.localPosition;
        if(localTransformPosition.y > maxY)
        {
            gameObject.transform.localPosition = new Vector3(localTransformPosition.x, maxY, localTransformPosition.z);
        }
        if(localTransformPosition.y < minY)
        {
            gameObject.transform.localPosition = new Vector3(localTransformPosition.x, minY, localTransformPosition.z);
        }
    }
}
