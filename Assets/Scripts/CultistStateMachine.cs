using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultistStateMachine : MonoBehaviour
{

    public float health;
    public bool isAlive;

    public float lastDamageAmt;

    public State currentState;

    void Start()
    {
        currentState = null;
        health = 100;
        isAlive = true;
    }

    
    void Update()
    {
        if (currentState != null)
        {
            currentState.Tick();
        }

        if (!isAlive)
        {
            Destroy(gameObject);
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
