using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBars : MonoBehaviour
{
    public FightingGameMaster fightingGameMaster;
    public Slider PlayerBar;
    public Slider EnemyBar;
    public void setBarStart()
    {
        PlayerBar.maxValue = fightingGameMaster.playerHealth;
        PlayerBar.value = fightingGameMaster.playerHealth;
        EnemyBar.maxValue = fightingGameMaster.enemyHealth;
        EnemyBar.value = fightingGameMaster.enemyHealth;
    }
    public void setPlayerBar()
    {
        PlayerBar.value = fightingGameMaster.playerHealth;
    }
    public void setEnemyBar()
    {
        EnemyBar.value = fightingGameMaster.playerHealth;
    }
}
