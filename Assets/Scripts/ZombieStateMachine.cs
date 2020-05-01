using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStateMachine : MonoBehaviour
{
    public float health;
    public bool isAlive;

    public float lastDamageAmt; // Value of the last amount of damage taken -- so we can pass in proper weapon damage

    public State currentState;
    public Zombie zom;

    private void Start()
    {
        zom = new Zombie();
        currentState = null;
        health = 100;
        isAlive = true;
        lastDamageAmt = 0;

        SetState(new Attack(this));
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.Tick();
        }

        if(!isAlive)
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
