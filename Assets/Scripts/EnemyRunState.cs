using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class EnemyRunState : StateMachineBehaviour
{
    public const string IDLE_STATE = "Idle";

    private GameObject player;
    private GameObject parentObject;
    private EnemyComponent enemyComponent;

    private void Awake()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        parentObject = animator.transform.parent.gameObject;
        enemyComponent = parentObject.GetComponent<EnemyComponent>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //        Debug.Log("Distance weetween player and " + animator.transform.name + " is " + Vector3.Distance(animator.transform.position, player.transform.position));
        if (Vector3.Distance(animator.transform.position, player.transform.position) < enemyComponent.GetRange())
        {
            //Debug.Log("Idle");
            animator.SetTrigger(IDLE_STATE);
        }
        if (player)
        {
            Vector3 direction = player.transform.position;
            direction.y = parentObject.transform.position.y;
            parentObject.transform.LookAt(direction);
        }
    }

    public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player)
        {
            parentObject.transform.Translate(Vector3.forward * enemyComponent.GetSpeed() * Time.deltaTime);
        }
    }
}