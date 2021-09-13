using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PouResultsMenu : MonoBehaviour
{
    private DataHolder dh;
    private PouGameMaster pgm;

    [SerializeField] private GameObject iten1Button;
    [SerializeField] private GameObject iten1Text;
    private Text _iten1Text;
    [SerializeField] private GameObject iten2Button;
    [SerializeField] private GameObject iten2Text;
    private Text _iten2Text;
    [SerializeField] private GameObject iten3Button;
    [SerializeField] private GameObject iten3Text;
    private Text _iten3Text;
    [SerializeField] private GameObject iten4Button;
    [SerializeField] private GameObject iten4Text;
    private Text _iten4Text;
    [SerializeField] private GameObject inventoryFullText;
    [SerializeField] private GameObject uSuckText;

    private int iten1id;
    private int iten2id;
    private int iten3id;
    private int iten4id;

    public UnityEvent OnNoInventory;

    void Start()
    {
        dh = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        pgm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<PouGameMaster>();

        _iten1Text = iten1Text.GetComponent<Text>();
        _iten2Text = iten2Text.GetComponent<Text>();
        _iten3Text = iten3Text.GetComponent<Text>();
        _iten4Text = iten4Text.GetComponent<Text>();

        iten1id = dh.selectedGrocerFood[0] * 10 + pgm.turn1Result;
        iten2id = dh.selectedGrocerFood[1] * 10 + pgm.turn2Result;
        iten3id = dh.selectedGrocerFood[2] * 10 + pgm.turn3Result;
        iten4id = dh.selectedGrocerFood[3] * 10 + pgm.turn4Result;

        _iten1Text.text = "" + iten1id;
        _iten2Text.text = "" + iten2id;
        _iten3Text.text = "" + iten3id;
        _iten4Text.text = "" + iten4id;

        if(pgm.turn1Result == 0){iten1Button.SetActive(false);}
        if(pgm.turn2Result == 0){iten2Button.SetActive(false);}
        if(pgm.turn3Result == 0){iten3Button.SetActive(false);}
        if(pgm.turn4Result == 0){iten4Button.SetActive(false);}
        if(pgm.turn1Result == 0 && pgm.turn2Result == 0 && pgm.turn3Result == 0 && pgm.turn4Result == 0){uSuckText.SetActive(true);}
    }

    public void addIten1ToInventory()
    {
        iten1Button.SetActive(false);
        dh.inventorySlots[9] = iten1id;
        dh.organizeInventory();
        if(dh.inventorySlots[9] != 0)
        {
            iten2Button.SetActive(false);
            iten3Button.SetActive(false);
            iten4Button.SetActive(false);
            inventoryFullText.SetActive(true);
        }
    }
    public void addIten2ToInventory()
    {
        iten2Button.SetActive(false);
        dh.inventorySlots[9] = iten2id;
        dh.organizeInventory();
        if(dh.inventorySlots[9] != 0)
        {
            iten1Button.SetActive(false);
            iten3Button.SetActive(false);
            iten4Button.SetActive(false);
            inventoryFullText.SetActive(true);
        }
    }
    public void addIten3ToInventory()
    {
        iten3Button.SetActive(false);
        dh.inventorySlots[9] = iten3id;
        dh.organizeInventory();
        if(dh.inventorySlots[9] != 0)
        {
            iten1Button.SetActive(false);
            iten2Button.SetActive(false);
            iten4Button.SetActive(false);
            inventoryFullText.SetActive(true);
        }
    }
    public void addIten4ToInventory()
    {
        iten4Button.SetActive(false);
        dh.inventorySlots[9] = iten4id;
        dh.organizeInventory();
        if(dh.inventorySlots[9] != 0)
        {
            iten1Button.SetActive(false);
            iten2Button.SetActive(false);
            iten3Button.SetActive(false);
            inventoryFullText.SetActive(true);
        }
    }
}
