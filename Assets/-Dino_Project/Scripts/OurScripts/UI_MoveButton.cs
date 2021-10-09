using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UI_MoveButton : MonoBehaviour
{
    private bool isBeingMoved;
    private float startingXPosition, startingYPosition;
    [SerializeField] private float rectTransformXSize;
    [SerializeField] private float rectTransformYSize;
    private Vector3 touchPosition;
    private float x, y;
    public UnityEvent onLeftTouch;
    public UnityEvent onRightTouch;
    public UnityEvent onUpTouch;
    public UnityEvent onDownTouch;

    void Start()
    {
        startingXPosition = gameObject.transform.position.x;
        startingYPosition = gameObject.transform.position.y;
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            if(isBeingMoved == false && touchPosition.x >= startingXPosition - rectTransformXSize/2 && touchPosition.x <= startingXPosition + rectTransformXSize/2 && touchPosition.y >= startingYPosition - rectTransformYSize/2 && touchPosition.y <= startingYPosition + rectTransformYSize/2)
            {
                isBeingMoved = true;
                x = touchPosition.x;
                y = touchPosition.y;
                gameObject.transform.position = new Vector3 (x, y, 0);
            }
            if(isBeingMoved == true)
            {
                x = touchPosition.x;
                y = touchPosition.y;
                if(x >= startingXPosition + rectTransformXSize/2){x = startingXPosition + rectTransformXSize/2; onLeftTouch.Invoke();}
                if(x <= startingXPosition - rectTransformXSize/2){x = startingXPosition - rectTransformXSize/2; onRightTouch.Invoke();}
                if(y >= startingXPosition + rectTransformYSize/2){y = startingYPosition + rectTransformYSize/2; onDownTouch.Invoke();}
                if(x <= startingYPosition - rectTransformYSize/2){y = startingYPosition - rectTransformYSize/2; onUpTouch.Invoke();}

                gameObject.transform.position = new Vector3 (x, y, 0);
            }
        }
        if(Input.touchCount == 0 && isBeingMoved == true)
        {
            isBeingMoved = false;
            gameObject.transform.position = new Vector3 (startingXPosition, startingYPosition, 0);
        }
    }
}
