using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStateMachine : MonoBehaviour
{
    public int health;
    public bool isAlive;

    public State currentState;

    private void Start()
    {
        health = 100;
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
