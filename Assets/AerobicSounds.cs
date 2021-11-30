using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerobicSounds : MonoBehaviour
{
    void dodge()
    {
        FindObjectOfType<AudioManager>().Play("Esquiva");
    }

    void voosh_enemy()
    {
        FindObjectOfType<AudioManager>().Play("Voosh_enemy1");
    }

    void block()
    {
        FindObjectOfType<AudioManager>().Play("Block");
    }

    void voosh_player()
    {
        FindObjectOfType<AudioManager>().Play("Voosh_player");
    }

    void take_damage()
    {
        FindObjectOfType<AudioManager>().Play("Soco_fraco");
    }

    void soco()
    {
        FindObjectOfType<AudioManager>().Play("Soco_medio");
    }

}
