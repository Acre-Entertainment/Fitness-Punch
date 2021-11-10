using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithJoystick : MonoBehaviour
{
    public float moveSpeed;
    public float inputSensibility;
    private float verticalInput, horizontalInput;
    private bool facingRight = true;
    public Joystick joystick;
    public GameObject[] bodyParts;
    private Rigidbody2D rb;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        horizontalInput = joystick.Horizontal;
        verticalInput = joystick.Vertical;
        if(Mathf.Abs(joystick.Horizontal) < Mathf.Abs(inputSensibility) && Mathf.Abs(joystick.Vertical) < Mathf.Abs(inputSensibility))
        {
            horizontalInput = 0;
            verticalInput = 0;
        }


        rb.velocity = new Vector2(horizontalInput * moveSpeed, verticalInput * moveSpeed);

        if(horizontalInput < 0 && facingRight == true)
        {
            facingRight = false;
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        if(horizontalInput > 0 && facingRight == false)
        {
            facingRight = true;
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }

        if(horizontalInput != 0 || verticalInput != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
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
