using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingCartMover : MonoBehaviour
//Move o jogador de acordo com o dedo (so funciona em celular, não em PC)
{
    [SerializeField] private bool fixedXPosition = false;
    [SerializeField] private bool fixedYPosition = false;
    private float _xPosition, _yPosition;
    void Start()
    {
        _xPosition = gameObject.transform.position.x;
        _yPosition = gameObject.transform.position.y;
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(fixedXPosition == false)
            {
                _xPosition = touch.position.x;
            }
            if(fixedYPosition == false)
            {
                _yPosition = touch.position.y;
            }
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(_xPosition, _yPosition, -Camera.main.transform.position.z));
            if(fixedXPosition == true)
            {
                gameObject.transform.position = new Vector3(_xPosition, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            if(fixedYPosition == true)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, _yPosition, gameObject.transform.position.z);
            }
        }
    }
}
