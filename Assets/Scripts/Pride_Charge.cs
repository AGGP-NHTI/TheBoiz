using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pride_Charge : State
{

    public float myTime = 0f;
    public bool charged = false;

    public Pride_Charge(PrideStateMachine sm) : base(sm)
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
        myTime = myTime + Time.deltaTime;

        Vector2 pos = prStateMachine.transform.position;
        Vector2 plr_pos = GameObject.Find("player").transform.position;
        Vector2 dir = (pos - plr_pos).normalized;
        Vector2 chargeDir = (pos - plr_pos).normalized * -1;

        float dist = Vector2.Distance(GameObject.Find("player").transform.position, prStateMachine.transform.position);

        if (myTime < prStateMachine.pride.charge_buildup && charged == false)
        {
            prStateMachine.GetComponent<Rigidbody2D>().velocity = dir * prStateMachine.pride.charge_buildup_speed;
        }
        if(myTime > prStateMachine.pride.charge_buildup && charged == false)
        {
            charged = true;
            myTime = 0f;
        }

        if(myTime < prStateMachine.pride.charge_duration && charged == true)
        {
            prStateMachine.GetComponent<Rigidbody2D>().velocity = chargeDir * prStateMachine.pride.charge_speed;
        }
        if(myTime > prStateMachine.pride.charge_duration && charged == true)
        {
            prStateMachine.SetState(new Attack(prStateMachine));
        }
        if(dist < 1 && charged == true)
        {
            PlayerStateMachine plr = GameObject.Find("player").GetComponentInParent<PlayerStateMachine>();
            plr.lastDamageAmt = prStateMachine.pride.charge_damage;
            plr.SetState(new TakeDamage(plr));
        }
    }
}
