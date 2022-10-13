using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroComponent : Singleton<HeroComponent>
{
    [SerializeField] private float attackSpeed = 1.0f;
    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private float maxHealth = 40f;
    private float health;
    public Slider healthBar;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.GetInstance();
        Animator animator = transform.GetChild(0).GetComponent<Animator>();
        animator.SetFloat("AttackSpeed", attackSpeed);
        health = maxHealth;
    }

    public float GetAttackSpeed()
    {
        return attackSpeed;
    }

    public void SetAttackSpeed(float _attackSpeed)
    {
        attackSpeed = _attackSpeed;
    }

    public float GetMoveSpeed()
    {
            return moveSpeed;
    }

    public void SetMoveSpeed(float _moveSpeed)
    {
        moveSpeed = _moveSpeed;
    }
    public void TakeDamage(float _damage)
    {
        health -= _damage;
        if (health <= 0)
        {
            //LOSE
            Debug.Log("LOSE");
            gameManager.EndGame();
        }
        healthBar.value = health / maxHealth;
    }

}
