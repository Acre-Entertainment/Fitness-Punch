using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeStuffBlue : MonoBehaviour
{
    public SpriteRenderer[] spriteRenderers;
    public void makeBlue()
    {
        foreach(SpriteRenderer sp in spriteRenderers)
        {
            sp.color = Color.blue;
        }
    }
    public void makeNotBlue()
    {
        foreach(SpriteRenderer sp in spriteRenderers)
        {
            sp.color = Color.white;
        }
    }
}
