using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : State
{

    private Color damagedColor, normalColor;
    private bool damaged;
    private float delay = 0.5f;
    float currentDelay = 0f;

    public bool isPlayer;
    public bool isZombie;

    public TakeDamage(PlayerStateMachine sm) : base(sm)
    {
        isPlayer = true;
    }

    public TakeDamage(ZombieStateMachine sm) : base(sm)
    {
        isZombie = true;
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
        CheckTargetStatus();
    }

    void CheckTargetStatus()
    {
        if (damaged)
        {
            if(isPlayer)
            {
                stateMachine.sprite_renderer.color = damagedColor;
                stateMachine.health -= stateMachine.lastDamageAmt;

                if (Time.time > currentDelay)
                {
                    stateMachine.sprite_renderer.color = normalColor;
                    damaged = false;
                    stateMachine.SetState(null);
                }
            }
            if(isZombie)
            {
                zmStateMachine.health -= zmStateMachine.lastDamageAmt;

                if(zmStateMachine.health <- 0)
                {
                    zmStateMachine.isAlive = false;
                }

                damaged = false;
                zmStateMachine.SetState(new Attack(zmStateMachine));
            }
            
        }
    }
}