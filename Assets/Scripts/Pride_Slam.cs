using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pride_Slam : State
{

    private float myTime = 0f;
    private bool attacked = false;

    public Pride_Slam(PrideStateMachine sm) : base(sm)
    {

    }

    public override void OnStateEnter()
    {
        Debug.Log("Slam Start");
        prStateMachine.sprite_renderer.sprite = prStateMachine.pride_sprites[7];
    }

    public override void OnStateExit()
    {

    }

    public override void Tick()
    {
        myTime = myTime + Time.deltaTime;

        if(myTime >= prStateMachine.pride.slam_buildup && attacked == false)
        {
            Debug.Log("SLAM");

            prStateMachine.sprite_renderer.sprite = prStateMachine.pride_sprites[6];

            float dist = Vector2.Distance(GameObject.Find("player").transform.position, prStateMachine.transform.position);

            if(dist < prStateMachine.pride.slam_AOE)
            {
                PlayerStateMachine plr = GameObject.Find("player").GetComponentInParent<PlayerStateMachine>();
                plr.lastDamageAmt = prStateMachine.pride.slam_damage;
                plr.SetState(new TakeDamage(plr));
            }

            attacked = true;
            myTime = 0f;
        }

        if (myTime >= 1f && attacked == true)
        {
            prStateMachine.SetState(new Attack(prStateMachine));
        }
    }
}
