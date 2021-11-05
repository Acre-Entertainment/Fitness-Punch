using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
  public int maxHealth = 3;
  public int currentHealth;
  private Rigidbody2D rb;
  public float jumpForce = 600f;

  private void Start() 
  {
      rb = GetComponent<Rigidbody2D>();
      currentHealth = maxHealth;
  }

  private void FixedUpdate() 
  {
      if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
         {
             rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Force);
             FindObjectOfType<AudioManager>().Play("ninjaJump");
        } 
  }

  public void TakeDamage(int amount)
  {
      if(currentHealth <= 0)
      { 
          GameControl.instance.DinoHit ();
          //FindObjectOfType<AudioManager>().Play("ninjaFail");
        }
  }
}
