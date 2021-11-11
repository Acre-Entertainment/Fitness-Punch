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
        
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (isGrounded == true)
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }

    }

    void FixedUpdate() 
    {
        

    }

    public void Jump()
    {
        if (canJump == true)
        {
            anim.SetTrigger("takeOf");
            rb.velocity = new Vector2(0, JumpForce);
            FindObjectOfType<AudioManager>().Play("ninjaJump");
        }
        

    }

    public void TakeDamage(int amount)
      {
          if(currentHealth <= 0)
          { 
              GameControl.instance.DinoHit ();
              FindObjectOfType<AudioManager>().Play("ninjaFail");
          }
      }

    private void Landing()
    {
        FindObjectOfType<AudioManager>().Play("ninjaLand");
    }
}
