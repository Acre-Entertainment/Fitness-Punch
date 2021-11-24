using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerobicStart : MonoBehaviour
{
    private GameObject Dc;
    private GameObject StartMenu;
    private void Start()
    {
        StartMenu = GameObject.Find("StartMenu");
        Dc = GameObject.FindGameObjectWithTag("Activator");
    }
    public void StartGame()
    {
        Dc.SetActive(true);
        StartMenu.SetActive(false);
    }
}
