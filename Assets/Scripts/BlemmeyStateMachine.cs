using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlemmeyStateMachine : MonoBehaviour
{
    public float health;
    public bool isAlive;

    public float lastDamageAmt; // Value of the last amount of damage taken -- so we can pass in proper weapon damage

    public State currentState;
    public Blemmey blem;

    private void Start()
    {
        currentState = null;
        health = 100;
        isAlive = true;
        lastDamageAmt = 0;

        blem = new Blemmey();

        SetState(new Attack(this));
    }

    private void Update()
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
