using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : State
{

    private bool isZombie;
    private bool isBlemmey;
    private bool isCultist;
    private bool isPride;

    private float myTime = 0f;
    private Vector2 dir;
    private float dist;

    public Attack(ZombieStateMachine sm) : base(sm)
    {
        isZombie = true;
    }

    public Attack(BlemmeyStateMachine sm) : base(sm)
    {
        isBlemmey = true;
    }

    public Attack(CultistStateMachine sm) : base(sm)
    {
        isCultist = true;
    }

    public Attack(PrideStateMachine sm) : base(sm)
    {
        isPride = true;
    }

    public override void OnStateEnter()
    {

    }

    public override void OnStateExit()
    {
        
    }

    public override void Tick()
    {

        if(isZombie)
        {
            Vector2 pos = zmStateMachine.transform.position;
            Vector2 plr_pos = GameObject.Find("player").transform.position;
            Vector2 dir = (pos - plr_pos).normalized * -1;

            float dist = Vector2.Distance(GameObject.Find("player").transform.position, zmStateMachine.transform.position);

            if (dist < 1)
            {
                zmStateMachine.SetState(new Zombie_Melee(zmStateMachine));
            }

            zmStateMachine.GetComponent<Rigidbody2D>().velocity = dir * zmStateMachine.zom.speed;
        }

        if(isBlemmey)
        {
            Vector2 pos = blStateMachine.transform.position;
            Vector2 plr_pos = GameObject.Find("player").transform.position;
            Vector2 dir = (pos - plr_pos).normalized * -1;

            float dist = Vector2.Distance(GameObject.Find("player").transform.position, blStateMachine.transform.position);

            if (dist < 1)
            {
                blStateMachine.SetState(new Blemmey_Melee(blStateMachine));
            }

            blStateMachine.GetComponent<Rigidbody2D>().velocity = dir * blStateMachine.blem.speed;
        }

        if(isCultist)
        {
            myTime = myTime + Time.deltaTime;

            Vector2 pos = clStateMachine.transform.position;
            Vector2 plr_pos = GameObject.Find("player").transform.position;
            Vector2 dir = (pos - plr_pos).normalized;
            Vector2 shootDir = (pos - plr_pos).normalized * -1;

            float dist = Vector2.Distance(GameObject.Find("player").transform.position, clStateMachine.transform.position);

            if(dist < clStateMachine.cult.retreat_dist)
            {
                clStateMachine.GetComponent<Rigidbody2D>().velocity = dir * clStateMachine.cult.speed;
            }

            if (myTime >= 3f)
            {
                clStateMachine.shoot(shootDir);
                myTime = 0f;
            }

        }

        if(isPride)
        {
            myTime = myTime + Time.deltaTime;

            Vector2 pos = prStateMachine.transform.position;
            Vector2 plr_pos = GameObject.Find("player").transform.position;
            Vector2 dir = (pos - plr_pos).normalized * -1;

            float dist = Vector2.Distance(GameObject.Find("player").transform.position, prStateMachine.transform.position);

        

            if (myTime >= prStateMachine.pride.cooldown)
            {
                int rng = Random.Range(1, 3);

                if(rng == 1)
                {
                    prStateMachine.SetState(new Pride_Charge(prStateMachine));
                }
                else if(rng == 2)
                {
                    prStateMachine.SetState(new Pride_Slam(prStateMachine));
                }

                myTime = 0f;
            }

            prStateMachine.GetComponent<Rigidbody2D>().velocity = dir * prStateMachine.pride.speed;
        }
        
    }

    

}
