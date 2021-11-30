using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    
    void voosh_enemy()
    {
        FindObjectOfType<AudioManager>().Play("Voosh_enemy1");
    }


}
