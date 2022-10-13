using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyComponent : MonoBehaviour
{
    private EnemyManager enemyManager;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float range = 1.5f;
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

    public float GetSpeed()
    {
        return speed;
    }

    public float GetRange()
    {
        return range;
    }

    public void Attack(float range)
    {
        StartCoroutine(AttackDelayed(0.2f, range));
    }

    private IEnumerator AttackDelayed(float _delay, float range)
    {
        yield return new WaitForSeconds(_delay);
        GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
        if (Vector3.Distance(transform.position, player.transform.position) <= range) {
            player.GetComponent<HeroComponent>().TakeDamage(10f);
        }
    }
}
