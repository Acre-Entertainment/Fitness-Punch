using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
  private Rigidbody2D rb;
  private float jumpForce = 600f;

  private void Start() 
  {
      rb = GetComponent<Rigidbody2D>();
  }

  private void Update() 
  {
      if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
         {
             rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Force);
         }
  }
}
