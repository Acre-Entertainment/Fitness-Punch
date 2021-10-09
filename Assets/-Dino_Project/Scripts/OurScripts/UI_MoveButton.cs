using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UI_MoveButton : MonoBehaviour
{
    private bool isBeingMoved;
    private bool correctCourse;
    [SerializeField] private float maximumButtonMoveSize;
    private RectTransform rt;
    private float x, y;

    public UnityEvent onLeftTouch;
    public UnityEvent onRightTouch;
    public UnityEvent onUpTouch;
    public UnityEvent onDownTouch;

    void Start()
    {
        rt = gameObject.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(2, 2);
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(isBeingMoved == false && EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                isBeingMoved = true;
                gameObject.transform.position = Camera.main.ScreenToWorldPoint(touch.position);
                x = rt.anchoredPosition.x;
                y = rt.anchoredPosition.y;
                if(x <= -maximumButtonMoveSize){x = -maximumButtonMoveSize; correctCourse = true; onLeftTouch.Invoke();}
                if(x >= maximumButtonMoveSize){x = maximumButtonMoveSize; correctCourse = true; onRightTouch.Invoke();}
                if(y <= -maximumButtonMoveSize){y = -maximumButtonMoveSize; correctCourse = true; onDownTouch.Invoke();}
                if(y >= maximumButtonMoveSize){y = maximumButtonMoveSize; correctCourse = true; onUpTouch.Invoke();}
                if(correctCourse == true)
                {
                    rt.anchoredPosition = new Vector2(x, y);
                    correctCourse = false;
                }
            }
            if(isBeingMoved == true)
            {
                gameObject.transform.position = Camera.main.ScreenToWorldPoint(touch.position);
                x = rt.anchoredPosition.x;
                y = rt.anchoredPosition.y;
                if(x <= -maximumButtonMoveSize){x = -maximumButtonMoveSize; correctCourse = true; onLeftTouch.Invoke();}
                if(x >= maximumButtonMoveSize){x = maximumButtonMoveSize; correctCourse = true; onRightTouch.Invoke();}
                if(y <= -maximumButtonMoveSize){y = -maximumButtonMoveSize; correctCourse = true; onDownTouch.Invoke();}
                if(y >= maximumButtonMoveSize){y = maximumButtonMoveSize; correctCourse = true; onUpTouch.Invoke();}
                if(correctCourse == true)
                {
                    rt.anchoredPosition = new Vector2(x, y);
                    correctCourse = false;
                }
            }
        }
        if(Input.touchCount == 0 && isBeingMoved == true)
        {
            isBeingMoved = false;
            
        }
    }
}
