using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Directioncontroler : MonoBehaviour
{
    [SerializeField] private SpriteRenderer activator;
    private bool intime = false;
    private int direction;
    private float timeControler = 1.5f;
    void Start()
    {
        activator = GetComponent<SpriteRenderer>();
        Default();
    }
    void Update()
    {
        TimeControler();
        if (intime == true)
        {
            Direction();
        }
    }

    protected int Right()
    {
        activator.color = Color.green;
        return 3;
    }

    protected int Down()
    {
        activator.color = Color.yellow;
        return 2;
    }

    protected int Left()
    {
        activator.color = Color.red;
        return 1;
    }
    private void Default()
    {
        activator.color = Color.blue;
    }
    public int Direction()
    {
        direction = (int)Random.Range(0, 4);
        if (direction == 3)
        {
            Right();
            intime = false;
        }
        if (direction == 2)
        {
            Down();
            intime = false;
        }
        if (direction == 1)
        {
            Left();
            intime = false;
        }
        return direction;
    }
    private void TimeControler()
    {
        if (timeControler > 0f)
        {
            timeControler -= Time.deltaTime;
        }
        else
        {
            timeControler = 1.5f;
            intime = true;
        }
    }

    //internal class Direction
    //{
    //}
}
