using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : State
{

    public float myTime = 0f;

    public Reload(PlayerStateMachine sm) : base(sm)
    {

    }

    public override void OnStateEnter()
    {
        
    }

    public override void OnStateExit()
    {
        
    }

    public override void Tick()
    {
        myTime += Time.deltaTime;

        if(myTime > stateMachine.plr_weapon.reloadSpeed)
        {
            stateMachine.plr_weapon.currentAmmo = stateMachine.plr_weapon.maxMag;
            stateMachine.canShoot = true;
            stateMachine.SetState(null);
        }
    }
}
