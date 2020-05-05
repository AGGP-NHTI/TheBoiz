using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : State
{

    private Color damagedColor, normalColor;
    private bool damaged;
    private float delay = 0.5f;
    float currentDelay = 0f;

    private bool deliver_damage;

    public bool isPlayer;
    public bool isZombie;
    public bool isBlemmey;
    public bool isCultist;
    public bool isPride;

    public TakeDamage(PlayerStateMachine sm) : base(sm)
    {
        isPlayer = true;
    }

    public TakeDamage(ZombieStateMachine sm) : base(sm)
    {
        isZombie = true;
        zmStateMachine.health -= zmStateMachine.lastDamageAmt;
    }

    public TakeDamage(BlemmeyStateMachine sm) : base(sm)
    {
        isBlemmey = true;
        blStateMachine.health -= blStateMachine.lastDamageAmt;
    }

    public TakeDamage(CultistStateMachine sm) : base(sm)
    {
        isCultist = true;
        clStateMachine.health -= clStateMachine.lastDamageAmt;
    }

    public TakeDamage(PrideStateMachine sm) : base(sm)
    {
        isPride = true;
        prStateMachine.health -= prStateMachine.lastDamageAmt;
    }

    public override void OnStateEnter()
    {
        normalColor = new Color(1.0f, 1.0f, 1.0f);
        damagedColor = new Color(1.0f, 0.24f, 0.24f); // Red
        damaged = true;
        currentDelay = Time.time + delay;
        deliver_damage = false;
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
                

                if(!deliver_damage)
                {
                    deliver_damage = true;
                    stateMachine.health -= stateMachine.lastDamageAmt;
                    Debug.Log("Vinny's Health: " + stateMachine.health);
                }

                if (stateMachine.health <= 0)
                {
                    stateMachine.isAlive = false;
                }

                

                if (Time.time > currentDelay)
                {
                    stateMachine.sprite_renderer.color = normalColor;
                    damaged = false;
                    stateMachine.SetState(null);
                }
            }
            if(isZombie)
            {

                if (!deliver_damage)
                {
                    deliver_damage = true;
                    //zmStateMachine.health -= zmStateMachine.lastDamageAmt;
                }
                
                

                if(zmStateMachine.health <= 0)
                {
                    zmStateMachine.isAlive = false;
                }

                damaged = false;
                zmStateMachine.SetState(new Attack(zmStateMachine));
            }
            if (isBlemmey)
            {

                if (!deliver_damage)
                {
                    deliver_damage = true;
                    //blStateMachine.health -= blStateMachine.lastDamageAmt;
                }



                if (blStateMachine.health <= 0)
                {
                    blStateMachine.isAlive = false;
                }

                damaged = false;
                blStateMachine.SetState(new Attack(blStateMachine));
            }
            if(isCultist)
            {
                if(clStateMachine.health <= 0)
                {
                    clStateMachine.isAlive = false;
                }

                damaged = false;
                clStateMachine.SetState(new Attack(clStateMachine));
            }
            if(isPride)
            {
                if(prStateMachine.health <= 0)
                {
                    prStateMachine.isAlive = false;
                }

                damaged = false;
                prStateMachine.SetState(new Attack(prStateMachine));
            }
        }
    }
}