using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_Animation : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    public void button_touch()
    {
        GetComponent<Animation>().Play("Button_click");
    }
    
    public void button_play()
    {
        GetComponent<Animation>().Play("Play_click");
    }
   
}
