using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroParameters : Singleton<HeroParameters>
{
    [SerializeField] private float attackSpeed = 1.0f;
    [SerializeField] private float moveSpeed = 2.0f;
    //public float damages;
    //public float damageAfterTime;

    void Start()
    {
        Animator animator = transform.GetChild(0).GetComponent<Animator>();
        animator.SetFloat("AttackSpeed", attackSpeed);
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
}
