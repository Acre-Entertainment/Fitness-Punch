using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAsLongAsButtonIsPressed : MonoBehaviour
{
    public float moveSpeed;
    private bool isMovingUp;
    private bool isMovingRight;
    private bool isMovingLeft;
    private bool isMovingDown;
    private Rigidbody2D rb;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(isMovingDown == true){rb.velocity = new Vector2(rb.velocity.x, -moveSpeed);}
        if(isMovingUp == true){rb.velocity = new Vector2(rb.velocity.x, moveSpeed);}
        if(isMovingUp == false && isMovingDown == false){rb.velocity = new Vector2(rb.velocity.x, 0);}
        if(isMovingLeft == true){rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);}
        if(isMovingRight == true){rb.velocity = new Vector2(moveSpeed, rb.velocity.y);}
        if(isMovingRight == false && isMovingLeft == false){rb.velocity = new Vector2(0, rb.velocity.y);}

        // animation transition
        if(isMovingDown || isMovingUp || isMovingLeft || isMovingRight == true)
        {
            anim.SetBool("isRunning", true);
        } else
        {
            anim.SetBool("isRunning", false);
        }
           
    }

    public void moveLeft()
    {
        isMovingLeft = true;
    }
    public void stopLeft()
    {
        isMovingLeft = false;
    }
    public void moveRight()
    {
        isMovingRight = true;
    }
    public void stopRight()
    {
        isMovingRight = false;
    }
    public void moveUp()
    {
        isMovingUp = true;
    }
    public void stopUp()
    {
        isMovingUp = false;
    }
    public void moveDown()
    {
        isMovingDown = true;
    }
    public void stopDown()
    {
        isMovingDown = false;
    }

    private void FootstepSound1()
    {
        FindObjectOfType<AudioManager>().Play("Walk1");
    }

    private void FootstepSound2()
    {
        FindObjectOfType<AudioManager>().Play("Walk2");
    }

}
