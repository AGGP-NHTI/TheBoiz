using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStateMachine : MonoBehaviour
{
    public float health;
    public bool isAlive;

    public float lastDamageAmt; // Value of the last amount of damage taken -- so we can pass in proper weapon damage

    public State currentState;

    private void Start()
    {
        currentState = null;
        health = 100;
        isAlive = true;
        lastDamageAmt = 0;

        SetState(new Wander(this));
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.Tick();
        }
    }

    public void SetState(State state)
    {
        if (state != null)
        {
            state.OnStateExit();
        }
        currentState = state;
        //currentStateType = currentState.GetType().Name;
        if (currentState != null)
        {
            currentState.OnStateEnter();
        }
    }

}
