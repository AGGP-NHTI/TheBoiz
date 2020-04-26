using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : State
{

    private float myTime = 0f;

    public PlayerShoot(PlayerStateMachine sm) : base(sm)
    {

    }

    public override void OnStateEnter()
    {
        stateMachine.playerShoot();
    }

    public override void OnStateExit()
    {
        //Debug.Log("Reload");
    }

    public override void Tick()
    {

        myTime = myTime + Time.deltaTime;

        if(myTime > stateMachine.plr_weapon.fireRate)
        {
            stateMachine.canShoot = true;
        }

    }


}
