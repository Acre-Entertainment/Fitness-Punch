using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public float height;
    public float speed;
    private int randy;
    private Rigidbody2D rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        randy = Random.Range(1, 6);
        switch (randy)
        {
            case 1:
                gameObject.transform.position = new Vector3(-2, gameObject.transform.position.y, 0);
                break;
            case 2:
                gameObject.transform.position = new Vector3(-1, gameObject.transform.position.y, 0);
                break;
            case 3:
                gameObject.transform.position = new Vector3(0, gameObject.transform.position.y, 0);
                break;
            case 4:
                gameObject.transform.position = new Vector3(1, gameObject.transform.position.y, 0);
                break;
            case 5:
                gameObject.transform.position = new Vector3(2, gameObject.transform.position.y, 0);
                break;
        }
        rb.velocity = new Vector2(0, -speed);
    }
}
