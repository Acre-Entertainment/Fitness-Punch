using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuItenSet : MonoBehaviour
{
    private DataHolder dataHolder;
    public Sprite[] foodSprites;
    public GameObject[] foodImageGameObject;
    public GameObject[] foodGlow;
    private Image[] foodImages = new Image[15];
    private int r;
    void Start()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        foreach(GameObject go in foodImageGameObject)
        {
            foodImages[r] = go.GetComponent<Image>();
            r++;
        }
        setImageOfSlot(0);
        setImageOfSlot(1);
        setImageOfSlot(2);
        setImageOfSlot(3);
        setImageOfSlot(4);
        setImageOfSlot(5);
        setImageOfSlot(6);
        setImageOfSlot(7);
        setImageOfSlot(8);
        setImageOfSlot(9);
    }
    void setImageOfSlot(int slot)
    {
        foodImages[slot].sprite = giveImageOfFoodID(dataHolder.inventorySlots[slot]);
        if(dataHolder.inventorySlots[slot] != 0)
        {
            foodImageGameObject[slot].SetActive(true);
        }
        if(dataHolder.inventorySlots[slot] > 300)
        {
            foodGlow[slot].SetActive(true);
        }
    }
    Sprite giveImageOfFoodID(int foodID)
    {
        switch(foodID)
        {
            case 101:
                return foodSprites[15];
            case 102:
                return foodSprites[16];
            case 103:
                return foodSprites[17];
            case 104:
                return foodSprites[18];
            case 105:
                return foodSprites[19];
            case 106:
                return foodSprites[20];
            case 107:
                return foodSprites[21];
            case 108:
                return foodSprites[22];
            case 109:
                return foodSprites[23];
            case 110:
                return foodSprites[24];
            case 111:
                return foodSprites[25];
            case 112:
                return foodSprites[26];
            case 113:
                return foodSprites[27];
            case 114:
                return foodSprites[28];
            case 115:
                return foodSprites[29];
            case 201:
                return foodSprites[0];
            case 202:
                return foodSprites[1];
            case 203:
                return foodSprites[2];
            case 204:
                return foodSprites[3];
            case 205:
                return foodSprites[4];
            case 206:
                return foodSprites[5];
            case 207:
                return foodSprites[6];
            case 208:
                return foodSprites[7];
            case 209:
                return foodSprites[8];
            case 210:
                return foodSprites[9];
            case 211:
                return foodSprites[10];
            case 212:
                return foodSprites[11];
            case 213:
                return foodSprites[12];
            case 214:
                return foodSprites[13];
            case 215:
                return foodSprites[14];
            case 301:
                return foodSprites[0];
            case 302:
                return foodSprites[1];
            case 303:
                return foodSprites[2];
            case 304:
                return foodSprites[3];
            case 305:
                return foodSprites[4];
            case 306:
                return foodSprites[5];
            case 307:
                return foodSprites[6];
            case 308:
                return foodSprites[7];
            case 309:
                return foodSprites[8];
            case 310:
                return foodSprites[9];
            case 311:
                return foodSprites[10];
            case 312:
                return foodSprites[11];
            case 313:
                return foodSprites[12];
            case 314:
                return foodSprites[13];
            case 315:
                return foodSprites[14];
            default:
                return foodSprites[0];
        }
    }
}
