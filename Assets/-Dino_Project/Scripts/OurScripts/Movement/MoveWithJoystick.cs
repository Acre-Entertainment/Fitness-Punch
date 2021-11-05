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
        rb.velocity = new Vector2(joystick.Horizontal * moveSpeed, joystick.Vertical * moveSpeed);

        if(joystick.Horizontal < 0 && facingRight == true)
        {
            facingRight = false;
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if(joystick.Horizontal > 0 && facingRight == false)
        {
            facingRight = true;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if(joystick.Horizontal != 0 || joystick.Vertical != 0)
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
