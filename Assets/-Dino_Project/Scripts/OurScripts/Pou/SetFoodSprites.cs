using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFoodSprites : MonoBehaviour
{
    public PouGameMaster pouGameMaster;
    public SpriteRenderer[] lowFoods;
    public SpriteRenderer[] mediumFoods;
    public SpriteRenderer[] highFoods;
    [SerializeField] private Sprite[] foodSprite;
    private DataHolder dataHolder;
    private int currentFoodSort;
    void Start()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
    }
    public void changeSprites()
    {
        currentFoodSort = dataHolder.selectedGrocerFood[pouGameMaster.turn - 1];
        foreach(SpriteRenderer spriteRenderer in lowFoods)
        {
            spriteRenderer.sprite = foodSprite[currentFoodSort];
        }
        foreach(SpriteRenderer spriteRenderer in mediumFoods)
        {
            spriteRenderer.sprite = foodSprite[currentFoodSort];
        }
        foreach(SpriteRenderer spriteRenderer in highFoods)
        {
            spriteRenderer.sprite = foodSprite[currentFoodSort];
        }
    }

    
}
