using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : StateMachineBehaviour
{
    public const string IDLE_STATE = "Idle";
    public float playerSpeed = 2.0f;

    HeroController heroController;
    GameObject parentObject;

    private void Awake()
    {
        heroController = HeroController.GetInstance();
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        parentObject = animator.transform.parent.gameObject;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (heroController.GetDirection() == Vector2.zero) {
            //Debug.Log("Idle");
            animator.SetTrigger(IDLE_STATE); }
    }

    public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 movementInput = -heroController.GetDirection();
        Vector3 move = new Vector3(movementInput.x, 0f, movementInput.y);
        parentObject.GetComponent<CharacterController>().Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            parentObject.transform.forward = -move;
        }
    }
}
