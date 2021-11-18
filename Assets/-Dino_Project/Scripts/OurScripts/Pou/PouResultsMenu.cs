using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PouResultsMenu : MonoBehaviour
{
    private DataHolder dh;
    private PouGameMaster pgm;
    public Sprite[] foodSprites;

    [SerializeField] private GameObject iten1Button;
    [SerializeField] private Image iten1Image;
    [SerializeField] private GameObject iten1Glow;
    [SerializeField] private GameObject iten2Button;
    [SerializeField] private Image iten2Image;
    [SerializeField] private GameObject iten2Glow;
    [SerializeField] private GameObject iten3Button;
    [SerializeField] private Image iten3Image;
    [SerializeField] private GameObject iten3Glow;
    [SerializeField] private GameObject iten4Button;
    [SerializeField] private Image iten4Image;
    [SerializeField] private GameObject iten4Glow;
    [SerializeField] private GameObject inventoryFullText;
    [SerializeField] private GameObject uSuckText;

    private int iten1id;
    private int iten2id;
    private int iten3id;
    private int iten4id;

    void Start()
    {
        dh = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        pgm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<PouGameMaster>();

        iten1id = dh.selectedGrocerFood[0] + pgm.turn1Result * 10 ;
        iten2id = dh.selectedGrocerFood[1] + pgm.turn2Result * 10 ;
        iten3id = dh.selectedGrocerFood[2] + pgm.turn3Result * 10 ;
        iten4id = dh.selectedGrocerFood[3] + pgm.turn4Result * 10 ;

        setFoodSprite(1);
        setFoodSprite(2);
        setFoodSprite(3);
        setFoodSprite(4);

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
    private void setFoodSprite(int whichButton)
    {
        Image imageToChange = iten1Image;
        GameObject glowToChange = iten1Glow;
        int foodIDToChange = iten1id;
        switch(whichButton)
        {
            case 1:
                break;
            case 2:
                imageToChange = iten2Image;
                glowToChange = iten2Glow;
                foodIDToChange = iten2id;
                break;
            case 3:
                imageToChange = iten3Image;
                glowToChange = iten3Glow;
                foodIDToChange = iten3id;
                break;
            case 4:
                imageToChange = iten4Image;
                glowToChange = iten4Glow;
                foodIDToChange = iten4id;
                break;
        }
        switch(foodIDToChange)
        {
            case 101:
                imageToChange.sprite = foodSprites[0];
                break;
            case 102:
                imageToChange.sprite = foodSprites[1];
                break;
            case 103:
                imageToChange.sprite = foodSprites[2];
                break;
            case 104:
                imageToChange.sprite = foodSprites[3];
                break;
            case 105:
                imageToChange.sprite = foodSprites[4];
                break;
            case 106:
                imageToChange.sprite = foodSprites[5];
                break;
            case 107:
                imageToChange.sprite = foodSprites[6];
                break;
            case 108:
                imageToChange.sprite = foodSprites[7];
                break;
            case 109:
                imageToChange.sprite = foodSprites[8];
                break;
            case 110:
                imageToChange.sprite = foodSprites[9];
                break;
            case 111:
                imageToChange.sprite = foodSprites[10];
                break;
            case 112:
                imageToChange.sprite = foodSprites[11];
                break;
            case 113:
                imageToChange.sprite = foodSprites[12];
                break;
            case 114:
                imageToChange.sprite = foodSprites[13];
                break;
            case 115:
                imageToChange.sprite = foodSprites[14];
                break;
            
            case 201:
                imageToChange.sprite = foodSprites[15];
                break;
            case 202:
                imageToChange.sprite = foodSprites[16];
                break;
            case 203:
                imageToChange.sprite = foodSprites[17];
                break;
            case 204:
                imageToChange.sprite = foodSprites[18];
                break;
            case 205:
                imageToChange.sprite = foodSprites[19];
                break;
            case 206:
                imageToChange.sprite = foodSprites[20];
                break;
            case 207:
                imageToChange.sprite = foodSprites[21];
                break;
            case 208:
                imageToChange.sprite = foodSprites[22];
                break;
            case 209:
                imageToChange.sprite = foodSprites[23];
                break;
            case 210:
                imageToChange.sprite = foodSprites[24];
                break;
            case 211:
                imageToChange.sprite = foodSprites[25];
                break;
            case 212:
                imageToChange.sprite = foodSprites[26];
                break;
            case 213:
                imageToChange.sprite = foodSprites[27];
                break;
            case 214:
                imageToChange.sprite = foodSprites[28];
                break;
            case 215:
                imageToChange.sprite = foodSprites[29];
                break;
            
            case 301:
                imageToChange.sprite = foodSprites[15];
                glowToChange.SetActive(true);
                break;
            case 302:
                imageToChange.sprite = foodSprites[16];
                glowToChange.SetActive(true);
                break;
            case 303:
                imageToChange.sprite = foodSprites[17];
                glowToChange.SetActive(true);
                break;
            case 304:
                imageToChange.sprite = foodSprites[18];
                glowToChange.SetActive(true);
                break;
            case 305:
                imageToChange.sprite = foodSprites[19];
                glowToChange.SetActive(true);
                break;
            case 306:
                imageToChange.sprite = foodSprites[20];
                glowToChange.SetActive(true);
                break;
            case 307:
                imageToChange.sprite = foodSprites[21];
                glowToChange.SetActive(true);
                break;
            case 308:
                imageToChange.sprite = foodSprites[22];
                glowToChange.SetActive(true);
                break;
            case 309:
                imageToChange.sprite = foodSprites[23];
                glowToChange.SetActive(true);
                break;
            case 310:
                imageToChange.sprite = foodSprites[24];
                glowToChange.SetActive(true);
                break;
            case 311:
                imageToChange.sprite = foodSprites[25];
                glowToChange.SetActive(true);
                break;
            case 312:
                imageToChange.sprite = foodSprites[26];
                glowToChange.SetActive(true);
                break;
            case 313:
                imageToChange.sprite = foodSprites[27];
                glowToChange.SetActive(true);
                break;
            case 314:
                imageToChange.sprite = foodSprites[28];
                glowToChange.SetActive(true);
                break;
            case 315:
                imageToChange.sprite = foodSprites[29];
                glowToChange.SetActive(true);
                break;
            
        }
    }
}
