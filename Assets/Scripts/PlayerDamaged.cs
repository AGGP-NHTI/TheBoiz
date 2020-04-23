using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamaged : State
{
    private Color damagedColor, normalColor;

    public PlayerDamaged(PlayerStateMachine sm) : base(sm)
    {

    }

    public override void OnStateEnter()
    {
        normalColor = stateMachine.sprite_renderer.color;
        damagedColor = new Color(1.0f, 0.24f, 0.24f); // Red
    }

    public override void Tick()
    {
        Color currentColor = Color.Lerp(normalColor, damagedColor, 0.2f);
        stateMachine.sprite_renderer.color = currentColor;

        // Now go back
        currentColor = Color.Lerp(damagedColor, normalColor, 0.2f);
        stateMachine.sprite_renderer.color = currentColor;

        stateMachine.SetState(null);
    }
}
