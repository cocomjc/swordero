using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : StateMachineBehaviour
{
    bool canAttack = false;
    GameObject parentObject;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        parentObject = animator.transform.parent.gameObject;
        canAttack = true;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player)
        {
            if (canAttack)
            {
                canAttack = false;
            }
        }
        if (Vector3.Distance(animator.transform.position, player.transform.position) > EnemyIdleState.range)
        {
            //Cancel attack
            animator.SetTrigger(EnemyIdleState.MOVE_STATE);
        }
    }

    public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player)
        {
            parentObject.transform.LookAt(player.transform);
//            parentObject.transform.rotation = Quaternion.Euler(0, parentObject.transform.rotation.eulerAngles.y + 180, 0);

        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTrigger(EnemyRunState.IDLE_STATE);
    }
}
