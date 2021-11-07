using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    private Rigidbody2D rb;
    public bool canJump = true;

    bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;

    [SerializeField]
    float JumpForce;

    private Animator anim;

    void Start() 
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        
        if (isGrounded)
          {
            Jump();
            anim.SetBool("isJumping", false);
        }     
    }

    private void Update() 
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        float moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput == 0)
        {
            anim.SetBool("isRunning", true);
        }
         else
         {
            anim.SetBool("isRunning", false);
         }

    }

    public void Jump()
    {
        if (canJump == true)
        {
            //anim.SetTrigger("takeOf");
            rb.velocity = new Vector2(0, JumpForce);
            FindObjectOfType<AudioManager>().Play("ninjaJump");
        }
        //else
        //{
            //anim.SetBool("isJumping", true);
        //}

    }

    public void TakeDamage(int amount)
      {
          if(currentHealth <= 0)
          { 
              GameControl.instance.DinoHit ();
              FindObjectOfType<AudioManager>().Play("ninjaFail");
          }
      }
}
