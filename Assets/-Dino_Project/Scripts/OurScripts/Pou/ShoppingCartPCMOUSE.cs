using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingCartPCMOUSE : MonoBehaviour
//move o carrinho com o mouse do PC
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
        if(fixedXPosition == false)
        {
            _xPosition = Input.mousePosition.x;
        }
        if(fixedYPosition == false)
        {
            _yPosition = Input.mousePosition.y;
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