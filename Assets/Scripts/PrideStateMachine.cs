using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrideStateMachine : MonoBehaviour
{

    public float health;
    public bool isAlive;

    public float lastDamageAmt;

    public State currentState;

    public Pride pride;

    public SpriteRenderer sprite_renderer;
    public Sprite[] pride_sprites;
    public int AnimateRunBaseIndex;
    public int anim_frame = 0;

    void Start()
    {
        pride = new Pride();
        isAlive = true;
        health = pride.health;
        currentState = null;
        lastDamageAmt = 0;

        sprite_renderer = GetComponent<SpriteRenderer>();
        pride_sprites = Resources.LoadAll<Sprite>("boss");

        SetState(new Attack(this));
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
