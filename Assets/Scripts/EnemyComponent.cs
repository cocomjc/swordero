using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyComponent : MonoBehaviour
{
    private EnemyManager enemyManager;
    [SerializeField] private float maxHealth = 40f;
    private float health;
    public Slider healthBar;

    private void Start()
    {
        health = maxHealth;
        enemyManager = EnemyManager.GetInstance();
        enemyManager.AddEnemy(gameObject);
    }

    private void OnDestroy()
    {
        Debug.Log("Enemy Destroyed");
        enemyManager.RemoveEnemy(gameObject);
    }

    public void TakeDamage(float _damage)
    {
        health -= _damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        healthBar.value = health / maxHealth;
    }
}
