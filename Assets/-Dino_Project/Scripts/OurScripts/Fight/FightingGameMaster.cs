using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FightingGameMaster : MonoBehaviour
{
    private DataHolder dataHolder;
    public int playerBaseHealth;
    public int playerHealthPerAerobic;
    private int playerHealth;
    public int playerBaseDamage;
    public int playerDamagePerStrengh;
    private int playerDamage;
    public int enemyHealth;
    public int enemyRegularAttackDamage;
    public int enemySuperAttackDamage;
    public UnityEvent onPlayerWin;
    public UnityEvent onEnemyWin;
    public bool FightIsOver;
    void Start()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        playerDamage = playerBaseDamage + playerDamagePerStrengh * dataHolder.forca;
        playerHealth = playerBaseHealth + playerHealthPerAerobic * dataHolder.resistencia;
    }
    public void playerPunchDoesDamage()
    {
        enemyHealth = enemyHealth - playerDamage;
        if(enemyHealth <= 0)
        {
            PlayerVictory();
        }
    }
    public void enemyRegularPunchDoesDamage()
    {
        playerHealth = playerHealth - enemyRegularAttackDamage;
        if(playerHealth <= 0)
        {
            EnemyVictory();
        }
    }
    public void enemySuperPunchDoesDamage()
    {
        playerHealth = playerHealth - enemySuperAttackDamage;
        if(playerHealth <= 0)
        {
            EnemyVictory();
        }
    }
    private void EnemyVictory()
    {
        onEnemyWin.Invoke();
        FightIsOver = true;
    }
    private void PlayerVictory()
    {
        onPlayerWin.Invoke();
        FightIsOver = true;
    }
}
