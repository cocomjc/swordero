using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    private HeroControls heroInput;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField]
    private float playerSpeed = 2.0f;

    private void Awake()
    {
        heroInput = new HeroControls();
        controller = GetComponent<CharacterController>();
        HeroAnimationController animationController = GetComponent<HeroAnimationController>();
        heroInput.Hero.Move.started += ctx => animationController.TriggerRun(true);
        heroInput.Hero.Move.canceled += ctx => animationController.TriggerRun(false);
        HeroFightController fightController = GetComponent<HeroFightController>();
        heroInput.Hero.Move.started += ctx => fightController.SetStill(true);
        heroInput.Hero.Move.canceled += ctx => fightController.SetStill(false);
    }

    private void OnEnable()
    {
        heroInput.Enable();
    }

    private void OnDisable()
    {
        heroInput.Disable();
    }

    void Update()
    {
        Vector2 movementInput = -heroInput.Hero.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(movementInput.x, 0f, movementInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = -move;
        }

        controller.Move(playerVelocity * Time.deltaTime);
    }
}
