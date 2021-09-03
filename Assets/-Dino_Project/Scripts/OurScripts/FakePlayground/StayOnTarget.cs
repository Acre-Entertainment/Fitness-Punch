using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayOnTarget : MonoBehaviour
//faz com que o game object siga outro
{
    public GameObject objectToFollow;
    [SerializeField] private float xOffset;
    [SerializeField] private float yOffset;
    [SerializeField] private float zOffset;
    void Update()
    {
        gameObject.transform.position = new Vector3(objectToFollow.transform.position.x + xOffset, objectToFollow.transform.position.y + yOffset, objectToFollow.transform.position.z + zOffset);
    }
}
