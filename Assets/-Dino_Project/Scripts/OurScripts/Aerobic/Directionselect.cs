using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Directionselect : MonoBehaviour
{
    [SerializeField] private Text feedback;
    [SerializeField] GameObject controler;
    private int controlerNumber;
    private void Start()
    {
        // controlerNumber = GameObject.FindGameObjectsWithTag("Activator").
    }
    public void DirSelectRigth()
    {
        if (controlerNumber == 3)
        {
            feedback.text = "BOOYA!!!";
        }
        else { feedback.text = "OOOOOH!"; }
        return;
    }
    public void DirSelectDown()
    {
        if (controlerNumber == 2)
        {
            feedback.text = "BOOYA!!!";
        }
        else { feedback.text = "OOOOOH!"; }
        return;
    }
    public void DirSelectLeft()
    {
        if (controlerNumber == 1)
        {
            feedback.text = "BOOYA!!!";
        }
        else { feedback.text = "OOOOOH!"; }
        return;
    }
}
