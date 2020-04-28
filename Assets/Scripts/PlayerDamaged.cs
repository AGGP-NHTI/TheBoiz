using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamaged : State
{
    private Color damagedColor, normalColor;
    private bool damaged;
    private float delay = 0.5f;
    float currentDelay = 0f;

    public PlayerDamaged(PlayerStateMachine sm) : base(sm)
    {

    }

    public override void OnStateEnter()
    {
        normalColor = new Color(1.0f, 1.0f, 1.0f);
        damagedColor = new Color(1.0f, 0.24f, 0.24f); // Red
        damaged = true;
        currentDelay = Time.time + delay;
    }

    public override void Tick()
    {
        CheckPlayerStatus();
    }

    void CheckPlayerStatus()
    {
        if (damaged)
        {
            stateMachine.sprite_renderer.color = damagedColor;

            if (Time.time > currentDelay)
            {
                stateMachine.sprite_renderer.color = normalColor;
                damaged = false;
                stateMachine.SetState(null);
            }
        }
    }
}
