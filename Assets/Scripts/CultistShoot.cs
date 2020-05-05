using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultistShoot : State
{



    public CultistShoot(CultistStateMachine sm) : base(sm)
    { }

    public override void OnStateEnter()
    {
        Vector3 pos = clStateMachine.transform.position;
        Vector3 plr_pos = GameObject.Find("player").transform.position;
        Vector3 dir = (pos - plr_pos).normalized * -1;
    }

    public override void OnStateExit()
    {

    }

    public override void Tick()
    {
        
    }
}
