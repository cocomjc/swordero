using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : Singleton<HeroController>
{
    private HeroControls heroInput;

    protected override void Awake()
    {
        base.Awake();
        heroInput = new HeroControls();
/*        HeroFightController fightController = GetComponent<HeroFightController>();
        heroInput.Hero.Move.started += ctx => fightController.SetStill(false);
        heroInput.Hero.Move.canceled += ctx => fightController.SetStill(true);*/
    }

    private void OnEnable()
    {
        heroInput.Enable();
    }

    private void OnDisable()
    {
        heroInput.Disable();
    }

    public Vector2 GetDirection()
    {
        return heroInput.Hero.Move.ReadValue<Vector2>();
    }
}
