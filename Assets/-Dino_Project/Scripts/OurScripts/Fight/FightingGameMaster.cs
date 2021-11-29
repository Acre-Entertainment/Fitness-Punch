using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FightingGameMaster : MonoBehaviour
{
    private DataHolder dataHolder;
    public HealthBars healthBars;
    public int playerBaseHealth;
    public int playerHealthPerAerobic;
    [HideInInspector] public int playerHealth;
    public int playerBaseDamage;
    public int playerDamagePerStrengh;
    [HideInInspector] public int playerDamage;
    public int enemyHealth;
    public int enemyRegularAttackDamage;
    public int enemySuperAttackDamage;
    public UnityEvent onPlayerWin;
    public UnityEvent onEnemyWin;
    public UnityEvent onPlayerDoesDamage;
    public UnityEvent onPlayerBlocksAttack;
    public UnityEvent onEnemyDoesRegularDamage;
    public UnityEvent onEnemyDoesBigDamage;
    public UnityEvent onEnemyBlocksAttack;
    public bool FightIsOver;
    void Start()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        playerDamage = playerBaseDamage + playerDamagePerStrengh * dataHolder.forca;
        playerHealth = playerBaseHealth + playerHealthPerAerobic * dataHolder.resistencia;
        healthBars.setBarStart();
    }
    public void playerPunchDoesDamage()
    {
        enemyHealth = enemyHealth - playerDamage;
        healthBars.setEnemyBar();
        onPlayerDoesDamage.Invoke();
        if(enemyHealth <= 0)
        {
            PlayerVictory();
        }
    }
    public void enemyRegularPunchDoesDamage()
    {
        playerHealth = playerHealth - enemyRegularAttackDamage;
        healthBars.setPlayerBar();
        onEnemyDoesRegularDamage.Invoke();
        if(playerHealth <= 0)
        {
            EnemyVictory();
        }
    }
    public void enemySuperPunchDoesDamage()
    {
        playerHealth = playerHealth - enemySuperAttackDamage;
        healthBars.setPlayerBar();
        onEnemyDoesBigDamage.Invoke();
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
