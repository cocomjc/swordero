using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : StateMachineBehaviour
{
    public const string MOVE_STATE = "Run";
    const string ATTACK_STATE = "Attack";
    private GameObject player;
    public const float range = 1.5f;

    private void Awake()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // if hero is not in range move toward him
        if (Vector3.Distance(animator.transform.position, player.transform.position) > range)
        {
            animator.SetTrigger(MOVE_STATE);
        }
        else
        {
            //Debug.Log("Attack");
            animator.SetTrigger(ATTACK_STATE);
        }
    }
}
