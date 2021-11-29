using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    
    void dodge()
    {
        FindObjectOfType<AudioManager>().Play("Esquiva");
    }

    void voosh()
    {
        FindObjectOfType<AudioManager>().Play("Voosh_enemy1");
    }

}
