using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : State
{
    private float myTime = 0f;
    private float walkDist;
    private Vector2 walkDir;
    private float waitTime;
    private float waitMin, waitMax;

    public Wander(ZombieStateMachine sm) : base(sm)
    { }

    public override void OnStateEnter()
    {
        waitMin = 2f;
        waitMax = 6f;
        waitTime = Random.Range(waitMin, waitMax);

        idle();
    }

    public override void OnStateExit()
    {
        
    }

    public override void Tick()
    {
        myTime = myTime + Time.deltaTime;

        if(myTime >= waitTime)
        {
            move();
            waitTime = Random.Range(waitMin, waitMax);
            myTime = 0f;
        }
    }

    private void idle()
    {
        walkDir.x = Random.Range(-1f, 1f);
        walkDir.y = Random.Range(-1f, 1f);
        walkDist = Random.Range(1, 3);
    }

    private void move()
    {
        Debug.Log(walkDir);
        Debug.Log(waitTime);
        zmStateMachine.GetComponent<Rigidbody2D>().velocity = walkDir.normalized * walkDist;
        idle();
    }

}