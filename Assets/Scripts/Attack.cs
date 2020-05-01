using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : State
{

    private bool isZombie;
    private bool isBlemmey;

    public Attack(ZombieStateMachine sm) : base(sm)
    {
        isZombie = true;
    }

    public Attack(BlemmeyStateMachine sm) : base(sm)
    {
        isBlemmey = true;
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
            Vector3 pos = zmStateMachine.transform.position;
            Vector3 plr_pos = GameObject.Find("player").transform.position;
            Vector3 dir = (pos - plr_pos).normalized * -1;

            float dist = Vector2.Distance(GameObject.Find("player").transform.position, zmStateMachine.transform.position);

            if (dist < 1)
            {
                zmStateMachine.SetState(new Zombie_Melee(zmStateMachine));
            }

            zmStateMachine.GetComponent<Rigidbody2D>().velocity = dir * zmStateMachine.zom.speed;
        }

        if(isBlemmey)
        {
            Vector3 pos = blStateMachine.transform.position;
            Vector3 plr_pos = GameObject.Find("player").transform.position;
            Vector3 dir = (pos - plr_pos).normalized * -1;

            float dist = Vector2.Distance(GameObject.Find("player").transform.position, blStateMachine.transform.position);

            if (dist < 1)
            {
                blStateMachine.SetState(new Blemmey_Melee(blStateMachine));
            }

            blStateMachine.GetComponent<Rigidbody2D>().velocity = dir * blStateMachine.blem.speed;
        }
        
    }
}
