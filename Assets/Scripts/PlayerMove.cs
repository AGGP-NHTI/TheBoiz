using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : State
{

    

    private int stepAmt = 0;
    
    

    public PlayerMove(PlayerStateMachine sm) : base(sm)
    {

    }

    public override void OnStateEnter()
    {
        
    }

    public override void OnStateExit()
    {
        stateMachine.anim_frame = 1;

        stateMachine.sprite_renderer.sprite = stateMachine.plr_sprites[stateMachine.AnimateRunBaseIndex + stateMachine.anim_frame];

        Debug.Log("State Left");
    }

    public override void Tick()
    {

        if (stateMachine.moveVertical != 0 || stateMachine.moveHorizontal != 0)
        {
            if (step())
            {
                stateMachine.anim_frame += 1;

                if (stateMachine.anim_frame > 2)
                {
                    stateMachine.anim_frame = 0;
                }
            }
        }
        else
        {
            stateMachine.anim_frame = 1;
        }

        stateMachine.sprite_renderer.sprite = stateMachine.plr_sprites[stateMachine.AnimateRunBaseIndex + stateMachine.anim_frame];
    }

    bool step()
    {
        stepAmt += 1;

        Debug.Log(stepAmt);

        if (stepAmt > 30)
        {

            stepAmt = 0;
            return true;

        }

        return false;
    }

}
