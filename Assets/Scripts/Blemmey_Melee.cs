using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blemmey_Melee : State
{

    private float myTime = 0f;
    private float coolDown;

    public Blemmey_Melee(BlemmeyStateMachine sm) : base(sm)
    { }

    public override void OnStateEnter()
    {
        myTime = 0f;
        coolDown = 1f;

        Debug.Log("!");

        PlayerStateMachine plr = GameObject.Find("player").GetComponentInParent<PlayerStateMachine>();
        plr.lastDamageAmt = blStateMachine.blem.damage; // Set Vinny's last taken damage value to be the zombie's hands
        plr.SetState(new TakeDamage(plr));
    }

    public override void OnStateExit()
    {

    }

    public override void Tick()
    {
        myTime = myTime + Time.deltaTime;

        if (myTime > coolDown)
        {
            blStateMachine.SetState(new Attack(blStateMachine));
        }
    }
}
