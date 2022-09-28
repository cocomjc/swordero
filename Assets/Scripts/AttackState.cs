using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    bool canFire = false;
    HeroController heroController;
    EnemyManager enemyManager;
    WeaponController weaponController;
    GameObject parentObject;

    private void Awake()
    {
        if (heroController == null)
        {
            heroController = HeroController.GetInstance();
        }

        if (enemyManager == null)
        {
            enemyManager = EnemyManager.GetInstance();
        }
        if(weaponController == null)
        {
            weaponController = GameObject.FindGameObjectsWithTag("WeaponSlot")[0].GetComponent<WeaponController>();
        }
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        parentObject = animator.transform.parent.gameObject;
        canFire = true;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 target = enemyManager.GetClosestEnemy(animator.transform.position).transform.position;
        if(target != null)
        {
            if (canFire)
            {
                target.y = GameObject.FindGameObjectsWithTag("FirePoint")[0].transform.position.y;
                weaponController.Fire(target);
                canFire = false;
            }
            else {
                animator.SetTrigger(RunState.IDLE_STATE);
            }
        }
        if (heroController.GetDirection() != Vector2.zero)
        {
            animator.SetTrigger(IdleState.MOVE_STATE);
        }
    }

    public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject target = enemyManager.GetClosestEnemy(parentObject.transform.position);
        if (target != null)
        {
            parentObject.transform.LookAt(target.transform);
            parentObject.transform.rotation = Quaternion.Euler(0, parentObject.transform.rotation.eulerAngles.y + 180, 0);

        }
    }
}
