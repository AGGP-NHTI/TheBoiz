using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : State
{

    private Color damagedColor, normalColor;
    private bool damaged;
    private float delay = 0.25f;
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
                zmStateMachine.sprite_renderer.color = damagedColor;

                if (!deliver_damage)
                {
                    deliver_damage = true;
                    //zmStateMachine.health -= zmStateMachine.lastDamageAmt;
                }
                
                

                if(zmStateMachine.health <= 0)
                {
                    zmStateMachine.isAlive = false;
                }

                if (Time.time > currentDelay)
                {
                    zmStateMachine.sprite_renderer.color = normalColor;
                    damaged = false;
                    zmStateMachine.SetState(new Attack(zmStateMachine));
                }
            }
            if (isBlemmey)
            {
                blStateMachine.sprite_renderer.color = damagedColor;
                if (!deliver_damage)
                {
                    deliver_damage = true;
                    //blStateMachine.health -= blStateMachine.lastDamageAmt;
                }



                if (blStateMachine.health <= 0)
                {
                    blStateMachine.isAlive = false;
                }

                if (Time.time > currentDelay)
                {
                    blStateMachine.sprite_renderer.color = normalColor;
                    damaged = false;
                    blStateMachine.SetState(new Attack(blStateMachine));
                }
            }
            if(isCultist)
            {
                clStateMachine.sprite_renderer.color = damagedColor;

                if(clStateMachine.health <= 0)
                {
                    clStateMachine.isAlive = false;
                }

                if (Time.time > currentDelay)
                {
                    clStateMachine.sprite_renderer.color = normalColor;
                    damaged = false;
                    clStateMachine.SetState(new Attack(clStateMachine));
                }
            }
            if(isPride)
            {
                prStateMachine.sprite_renderer.color = damagedColor;

                if(prStateMachine.health <= 0)
                {
                    prStateMachine.isAlive = false;
                }

                if (Time.time > currentDelay)
                {
                    prStateMachine.sprite_renderer.color = normalColor;
                    damaged = false;
                    prStateMachine.SetState(new Attack(prStateMachine));
                }
            }
        }
    }
}