using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
//Faz o objeto andar em uma pattern de Grid
{
    private float xLocation, yLocation;

    [SerializeField] private float moveSpeed;
    [SerializeField] private int gridSize;
    private bool _isMoving = false;
    private int _moveDirection;
    private Rigidbody2D _rb;
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        xLocation = transform.position.x;
        yLocation = transform.position.y;
    }
    void Update()
    {
        if(_isMoving == true)
        {
            switch(_moveDirection)
            {
                case 1:
                    if(transform.position.x >= xLocation)
                    {
                        _rb.velocity = new Vector2(0, 0);
                        transform.position = new Vector3(xLocation, yLocation, 0);
                        _isMoving = false;
                    }
                    break;
                case 2:
                    if(transform.position.x <= xLocation)
                    {
                        _rb.velocity = new Vector2(0, 0);
                        transform.position = new Vector3(xLocation, yLocation, 0);
                        _isMoving = false;
                    }
                    break;
                case 3:
                    if(transform.position.y >= yLocation)
                    {
                        _rb.velocity = new Vector2(0, 0);
                        transform.position = new Vector3(xLocation, yLocation, 0);
                        _isMoving = false;
                    }
                    break;
                case 4:
                    if(transform.position.y <= yLocation)
                    {
                        _rb.velocity = new Vector2(0, 0);
                        transform.position = new Vector3(xLocation, yLocation, 0);
                        _isMoving = false;
                    }
                    break;
            }
        }
    }
    public void moveRight()
    {
        if(_isMoving == false)
        {
            xLocation = xLocation + gridSize;
            _rb.velocity = new Vector2(moveSpeed, 0);
            _isMoving = true;
            _moveDirection = 1;
        }
    }
    public void moveLeft()
    {
      if(_isMoving == false)
        {
            xLocation = xLocation - gridSize;
            _rb.velocity = new Vector2(-moveSpeed, 0);
            _isMoving = true;
            _moveDirection = 2;
        }  
    }
    public void moveUp()
    {
        if(_isMoving == false)
        {
            yLocation = yLocation + gridSize;
            _rb.velocity = new Vector2(0, moveSpeed);
            _isMoving = true;
            _moveDirection = 3;
        }
    }
    public void moveDown()
    {
        if(_isMoving == false)
        {
            yLocation = yLocation - gridSize;
            _rb.velocity = new Vector2(0, -moveSpeed);
            _isMoving = true;
            _moveDirection = 4;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(_isMoving == true)
        {
            switch(_moveDirection)
            {
                case 1:
                    _rb.velocity = new Vector2(-moveSpeed, 0);
                    _moveDirection = 2;
                    xLocation = xLocation - gridSize;
                    break;
                case 2:
                    _rb.velocity = new Vector2(moveSpeed, 0);
                    _moveDirection = 1;
                    xLocation = xLocation + gridSize;
                    break;
                case 3:
                    _rb.velocity = new Vector2(0, -moveSpeed);
                    _moveDirection = 4;
                    yLocation = yLocation - gridSize;
                    break;
                case 4:
                    _rb.velocity = new Vector2(0, moveSpeed);
                    _moveDirection = 3;
                    yLocation = yLocation + gridSize;
                    break;
                }
            }
    }
}
