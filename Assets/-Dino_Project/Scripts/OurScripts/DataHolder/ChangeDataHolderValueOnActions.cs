using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLoadingOverworld : MonoBehaviour
{
    private DataHolder dataHolder;
    void Start()
    {
        dataHolder = gameObject.GetComponent<DataHolder>();
        if(dataHolder.removeActionUponReturnToOverworld == true)
        {
            dataHolder.actions--;
        }
    }
    void Update()
    {
        
    }
}
