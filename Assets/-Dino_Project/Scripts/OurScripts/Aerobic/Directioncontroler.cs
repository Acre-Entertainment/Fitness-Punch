using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Directioncontroler : MonoBehaviour
{
    [SerializeField] private Text feedback;
    private int controlerNumber;

    [SerializeField] private SpriteRenderer activator;
    public bool intime = false;
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
            controlerNumber = Direction();
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
        direction = (int)Random.Range(1, 4);
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
        if (timeControler > 0f && intime == false)
        {
            timeControler -= Time.deltaTime;
        }
        else
        {
            timeControler = 1.5f;
            intime = true;
        }
    }

    public void DirSelectRigth()
    {
        if (controlerNumber == 3)
        {
            feedback.text = "BOOYA!!!";
        }
        else { feedback.text = "OOOOOH!"; }
        return;
    }
    public void DirSelectDown()
    {
        if (controlerNumber == 2)
        {
            feedback.text = "BOOYA!!!";
        }
        else { feedback.text = "OOOOOH!"; }
        return;
    }
    public void DirSelectLeft()
    {
        if (controlerNumber == 1)
        {
            feedback.text = "BOOYA!!!";
        }
        else { feedback.text = "OOOOOH!"; }
        return;
    }
}
