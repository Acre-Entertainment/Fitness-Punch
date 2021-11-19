using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBox : MonoBehaviour
{
    public Transform box;
    public CanvasGroup shadow;


    public void OnEnable()
    {
        shadow.alpha = 0;
        shadow.LeanAlpha(1, 0.5f);

        box.localPosition = new Vector2(0, -Screen.height);
        box.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.1f;
    }

    public void CloseMenu()
    {
        shadow.LeanAlpha(0, 0.5f);
        box.LeanMoveLocalY(-Screen.height, 0.5f).setOnComplete(OnComplete);
    }

    void OnComplete()
    {
        gameObject.SetActive(false);
    }
   
}
