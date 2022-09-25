using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    //bool canFire = false;

    HeroController heroController;
    EnemyManager enemyManager;

    private void Awake()
    {
        heroController = HeroController.Instance;
        enemyManager = EnemyManager.Instance;
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //canFire = true;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject target = enemyManager.GetClosestEnemy(animator.transform.position);
    }
}
