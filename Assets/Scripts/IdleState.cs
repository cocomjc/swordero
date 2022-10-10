using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    public const string MOVE_STATE = "Run";
    const string ATTACK_STATE = "Attack";

    HeroController heroController;
    EnemyManager enemyManager;

    private void Awake()
    {
        heroController = HeroController.GetInstance();
        enemyManager = EnemyManager.GetInstance();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (heroController.GetDirection() != Vector2.zero)
        {
            //Debug.Log("Moving");
            animator.SetTrigger(MOVE_STATE);
        }
        else if (enemyManager.EnemyExists())
        {
            //Debug.Log("Attack");
            animator.SetTrigger(ATTACK_STATE);
        }
    }
}
