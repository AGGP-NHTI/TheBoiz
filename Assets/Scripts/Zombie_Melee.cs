using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Melee : State
{

    private float myTime = 0f;
    private float coolDown;

    public Zombie_Melee(ZombieStateMachine sm) : base(sm)
    { }

    public override void OnStateEnter()
    {
        coolDown = 1f;

        PlayerStateMachine plr = GameObject.Find("player").GetComponentInParent<PlayerStateMachine>();
        plr.SetState(new TakeDamage(plr));
    }

    public override void OnStateExit()
    {

    }

    public override void Tick()
    {
        myTime = myTime + Time.deltaTime;

        if(myTime > coolDown)
        {
            zmStateMachine.SetState(new Attack(zmStateMachine));
        }
    }
}
